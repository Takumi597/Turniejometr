using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TrackerLib.Modele;


namespace TrackerLib.Wlasciwosci
{
    public static class TournamentLogic
    {
        
        public static void CreateRounds(Turniej model)
        {
            List<Druzyna> randomizedTeams = RandomizeTeamOrder(model.AktywneDruzyny);
            int rounds = FindNumberOfRounds(randomizedTeams.Count);
            int byes = FindNumberOfBuys(randomizedTeams.Count);

            model.Rundy.Add(CreateFirstRound(byes, randomizedTeams));
            CreateOtherRounds(model, rounds);
            // UpdateTournamentResults(model);

        }

        public static void UpdateTournamentResults(Turniej model)
        {
            int startingRound = model.CheckCurrentRound();
            List<Mecz> toScore = new List<Mecz>();

            foreach (List<Mecz> round in model.Rundy)
            {
                foreach (Mecz rm in round)
                {
                    if (rm.Zwyciezca == null && (rm.Tura.Any(x => x.Wynik != 0) || rm.Tura.Count == 1))
                    {
                        toScore.Add(rm);
                    }
                }
            }

            

            MarkWinnersInMatchups(toScore);

            AdvanceZwyciezcas(toScore, model);

            toScore.ForEach(x => GlobalConfig.Connection.UpdateMatchup(x));
            int endingRound = model.CheckCurrentRound();

            
        }
       
       

        private static int CheckCurrentRound(this Turniej model)
        {
            int output = 1;
            foreach (List<Mecz> round in model.Rundy)
            {
                if (round.All(x => x.Zwyciezca != null))
                {
                    output += 1;
                }
                else
                {
                    return output;
                }
            }

            //tournament over!
            CompleteTournament(model);
            return output - 1;
        }

        private static void CompleteTournament(Turniej model)
        {
            GlobalConfig.Connection.CompleteTournament(model);
            Druzyna Zwyciezcas = model.Rundy.Last().First().Zwyciezca;
            Druzyna runnerUp = model.Rundy.Last().First().Tura.Where(x => x.DruzynaWalczaca != Zwyciezcas).First().DruzynaWalczaca;

            decimal WinnerPrize = 0;
            decimal runnerUpPrize = 0;

            if (model.Nagrody.Count > 0)
            {
                decimal totalIncome = model.AktywneDruzyny.Count * model.Opłata;
                Nagroda firstPlacePrize = model.Nagrody.Where(x => x.Miejsce == 1).FirstOrDefault();
                Nagroda secondPlacePrize = model.Nagrody.Where(x => x.Miejsce == 2).FirstOrDefault();

                if (firstPlacePrize != null)
                {
                    WinnerPrize = firstPlacePrize.CalculatePrizePayout(totalIncome);
                }
                if (secondPlacePrize != null)
                {
                    runnerUpPrize = secondPlacePrize.CalculatePrizePayout(totalIncome);
                }
            }
            model.CompleteTournament();
        }
        private static decimal CalculatePrizePayout(this Nagroda prize, decimal totalIncome)
        {
            decimal output = 0;
            if (prize.Kwota > 0)
            {
                output = prize.Kwota;
            }
            else
            {
                output = Decimal.Multiply(totalIncome, Convert.ToDecimal(prize.KwotaProc / 100));
            }
            return output;
        }

        private static void AdvanceZwyciezcas(List<Mecz> models, Turniej tournament)
        {
            foreach (Mecz m in models)
            {
                foreach (List<Mecz> round in tournament.Rundy)
                {
                    foreach (Mecz rm in round)
                    {
                        foreach (AktualnyMecz me in rm.Tura)
                        {
                            if (me.PoprzedzajacyMecz != null)
                            {

                                if (me.PoprzedzajacyMecz.ID == m.ID)
                                {
                                    me.DruzynaWalczaca = m.Zwyciezca;
                                    GlobalConfig.Connection.UpdateMatchup(rm);
                                }

                            }

                        }
                    }

                }
            }

        }

        private static void MarkWinnersInMatchups(List<Mecz> models)
        {
            
            string greaterWins = ConfigurationManager.AppSettings["greaterWins"];

            foreach (Mecz m in models)
            {
                if (m.Tura.Count == 1)
                {
                    m.Zwyciezca = m.Tura[0].DruzynaWalczaca;
                    continue;
                }
                
                if (greaterWins == "0")
                {
                    if (m.Tura[0].Wynik < m.Tura[1].Wynik)
                    {
                        m.Zwyciezca = m.Tura[0].DruzynaWalczaca;
                    }
                    else if (m.Tura[0].Wynik > m.Tura[1].Wynik)
                    {
                        m.Zwyciezca = m.Tura[1].DruzynaWalczaca;
                    }
                    else
                    {
                        throw new Exception("Tie result not allowed");
                    }
                }
                else
               
                {
                    if (m.Tura[0].Wynik > m.Tura[1].Wynik)
                    {
                        m.Zwyciezca = m.Tura[0].DruzynaWalczaca;
                    }
                    else if (m.Tura[0].Wynik < m.Tura[1].Wynik)
                    {
                        m.Zwyciezca = m.Tura[1].DruzynaWalczaca;
                    }
                    else
                    {
                        throw new Exception("Tie games not supported");
                    }
                }
            }
        }

        private static void CreateOtherRounds(Turniej model, int rounds)
        {
            int round = 2;
            List<Mecz> previousRound = model.Rundy[0];
            List<Mecz> currRound = new List<Mecz>();
            Mecz currMatchup = new Mecz();

            while (round <= rounds)
            {
                foreach (Mecz match in previousRound)
                {
                    currMatchup.Tura.Add(new AktualnyMecz { PoprzedzajacyMecz = match });

                    if (currMatchup.Tura.Count > 1)
                    {
                        currMatchup.AktualnaRunda = round;
                        currRound.Add(currMatchup);
                        currMatchup = new Mecz();

                    }

                }

                model.Rundy.Add(currRound);
                previousRound = currRound;

                currRound = new List<Mecz>();
                round += 1;
            }
        }
        private static List<Mecz> CreateFirstRound(int byes, List<Druzyna> teams)
        {
            List<Mecz> output = new List<Mecz>();
            Mecz curr = new Mecz();

            foreach (Druzyna team in teams)
            {
                curr.Tura.Add(new AktualnyMecz { DruzynaWalczaca = team });

                if (byes > 0 || curr.Tura.Count > 1)
                {
                    curr.AktualnaRunda = 1;
                    output.Add(curr);
                    curr = new Mecz();

                    if (byes > 0)
                    {
                        byes -= 1;
                    }

                }
            }
            return output;
        }
        private static int FindNumberOfBuys(int teamCount)
        {
            int j = 1;
            while (teamCount > j)
            {
                j *= 2; 
            }
            int buy = j - teamCount;
            return buy;

        }
        private static int FindNumberOfRounds(int teamCount)
        {
            int output = 0;
           
            int j = 1;
            while (teamCount > j)
            {
                j *= 2; 
                output += 1;
            }
            
            return output;

        }
        public static List<Druzyna> RandomizeTeamOrder(List<Druzyna> teams)
        {
            //var shuffledcards = teams.OrderBy(a => Guid.NewGuid()).ToList();
            return teams.OrderBy(a => Guid.NewGuid()).ToList();
        }


    }
}

