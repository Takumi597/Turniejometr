using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerLib.Modele;
using TrackerLib.Wlasciwosci;
using TrackerLib.Data;

namespace TrackerLib.Data
{
    public static class TextConnectorProcessor
    {
        public static string FullFilePath(this string fileName)
        {
            return $"{ConfigurationManager.AppSettings["filePath"]}\\{fileName}";
        }
        public static List<string> LoadFile(this string file)
        {
            if (!File.Exists(file))
            {
                return new List<string>();
            }

            return File.ReadAllLines(file).ToList();
        }

        public static List<Nagroda> ConvertToPrizeModels(this List<string> lines)
        {
            List<Nagroda> output = new List<Nagroda>();

            foreach(string line in lines)
            {
                string[] cols = line.Split(',');

                Nagroda p = new Nagroda();
                p.ID = int.Parse(cols[0]);
                p.Miejsce = int.Parse(cols[1]);
                p.Tytul = cols[2];
                p.Kwota = int.Parse(cols[3]);
                p.KwotaProc = int.Parse(cols[4]);

                output.Add(p);
            }

            return output;
        }

       public static List<Druzyna> ConvertToTeams(this List<string> lines)
        {
            

            List<Druzyna> output = new List<Druzyna>();
            List<Osoba> people = GlobalConfig.DruzynyFile.FullFilePath().LoadFile().ConvertToPersonModels();

            foreach (string line in lines)
            {

                string[] cols = line.Split(',');

                Druzyna t = new Druzyna();
                t.ID = int.Parse(cols[0]);
                t.NazwaDruzyny = cols[1];

                string[] personIds = cols[2].Split('|');

                foreach (string id in personIds)
                {
                    t.CzlonkowieDruzyny.Add(people.Where(x => x.ID == int.Parse(id)).First());
                }

                output.Add(t);
                
            }

            return output;

        }

        public static List<Turniej> ConvertToTournaments(this List<string> lines)
        {
           
            List<Turniej> output = new List<Turniej>();
            List<Druzyna> teams = GlobalConfig.DruzynyFile.FullFilePath().LoadFile().ConvertToTeams();
            List<Nagroda> prizes = GlobalConfig.NagrodyFile.FullFilePath().LoadFile().ConvertToPrizeModels();
            List<Mecz> matchups = GlobalConfig.MeczeFile.FullFilePath().LoadFile().ConvertToMatchupModels();

            foreach (string line in lines)
            {
                string[] cols = line.Split(',');

                Turniej tm = new Turniej();
                tm.ID = int.Parse(cols[0]);
                tm.NazwaTurnieju = cols[1];
                tm.Opłata = decimal.Parse(cols[2]);

                string[] teamIds = cols[3].Split('|');
                foreach(string id in teamIds)
                {
                    tm.AktywneDruzyny.Add(teams.Where(x => x.ID == int.Parse(id)).First());
                }


                if (cols[4].Length > 0)
                {
                    string[] prizeIds = cols[4].Split('|');
                    foreach (string id in prizeIds)
                    {
                        tm.Nagrody.Add(prizes.Where(x => x.ID == int.Parse(id)).First());
                    }
                }

                //  Capture Rounds infomation
                string[] rounds = cols[5].Split('|');
                

                foreach (string round in rounds)
                {
                    string[] msText = round.Split('^');
                    List<Mecz> ms = new List<Mecz>();

                    foreach (string matchupModelTextId in msText)
                    {
                        ms.Add(matchups.Where(x => x.ID == int.Parse(matchupModelTextId)).First());
                    }

                    tm.Rundy.Add(ms);

                }

                output.Add(tm);
            }

            return output;
        }

        public static List<Osoba> ConvertToPersonModels(this List<string> lines)
        {
            List<Osoba> output = new List<Osoba>();

            foreach (string line in lines)
            {

                string[] cols = line.Split(',');

                Osoba p = new Osoba();
                p.ID = int.Parse(cols[0]);
                p.Imie = cols[1];
                p.Nazwisko = cols[2];
                

                output.Add(p);
            }

            return output;

        }

        public static void SaveToPrizesFile(this List<Nagroda> models)
        {
            List<string> lines = new List<string>();
            
            foreach (Nagroda p in models)
            {
                lines.Add($"{p.ID},{p.Miejsce},{p.Tytul},{p.Kwota},{p.KwotaProc}");
            }

            File.WriteAllLines(GlobalConfig.NagrodyFile.FullFilePath(), lines);
        }


        public static void SaveToPeopleFile(this List<Osoba> models)
        {
            List<string> lines = new List<string>();
            
            foreach (Osoba p in models)
            {
                lines.Add($"{p.ID},{p.Imie},{p.Nazwisko}");
            }

            File.WriteAllLines(GlobalConfig.OsobyFile.FullFilePath(), lines);
        }

        public static void SaveToTeamFile(this List<Druzyna> models)
        {
            List<string> lines = new List<string>();
           
            foreach (Druzyna t in models)
            {
                lines.Add($"{ t.ID},{t.NazwaDruzyny},{ConvertPeopleListToString(t.CzlonkowieDruzyny)}");
            }

            File.WriteAllLines(GlobalConfig.DruzynyFile.FullFilePath(), lines);
        }

        public static void SaveToTournamentFile(this List<Turniej> models)
        {
            List<string> lines = new List<string>();
           
            foreach (Turniej tm in models)
            {
                lines.Add($"{tm.ID},{tm.NazwaTurnieju},{tm.Opłata},{ConvertTeamListToString(tm.AktywneDruzyny)},{ConvertPrizeListToString(tm.Nagrody)},{ConvertRoundListToString(tm.Rundy)}");
            }
            File.WriteAllLines(GlobalConfig.TurniejeFile.FullFilePath(), lines);
        }

        public static void SaveRoundsToFile(this Turniej model)
        {
            

            foreach (List<Mecz> round in model.Rundy)
            {
                foreach (Mecz matchup in round)
                {
                    matchup.SaveMatchupToFile();
                   
                }
            }
        }

        private static List<AktualnyMecz> ConvertStringToMatchupEntryModels(string input)
        {
            string[] ids = input.Split('|');
            List<AktualnyMecz> output = new List<AktualnyMecz>();
            List<string> entries = GlobalConfig.AktualneMeczeFile.FullFilePath().LoadFile();
            List<string> matchingEntries = new List<string>();


            foreach (string id in ids)
            {
                foreach (string entry in entries)
                {
                    string[] cols = entry.Split(',');
                    if(cols[0] == id)
                    {
                        matchingEntries.Add(entry);
                    }
                }
            }
            output = matchingEntries.ConvertToMatchupEntryModels();
            return output;
        }

        private static Druzyna LookupTeamById(int id)
        {
            List<string> teams = GlobalConfig.DruzynyFile.FullFilePath().LoadFile();

            foreach (string team in teams)
            {
                string[] cols = team.Split(',');
                if (cols[0] == id.ToString())
                {
                    List<string> matchingTeams = new List<string>();
                    matchingTeams.Add(team);
                    return matchingTeams.ConvertToTeams().First();
                }
            }
            return null;
        }
       
        private static Mecz LookupMatchupById(int id)
        {
            List<string> matchups = GlobalConfig.MeczeFile.FullFilePath().LoadFile();
            foreach (string matchup in matchups)
            {
                string[] cols = matchup.Split(',');
                if (cols[0] == id.ToString())
                {
                    List<string> matchingMatchups = new List<string>();
                    matchingMatchups.Add(matchup);
                    return matchingMatchups.ConvertToMatchupModels().First();
                }
            }
            return null;
        }

        public static List<AktualnyMecz> ConvertToMatchupEntryModels(this List<string> lines)
        {
            // id = 0, teamcompeting = 1, score = 2, parentmatchup = 3
            List<AktualnyMecz> output = new List<AktualnyMecz>();

            foreach (string line in lines)
            {

                string[] cols = line.Split(',');

                AktualnyMecz me = new AktualnyMecz();

                me.ID = int.Parse(cols[0]);

                if(cols[1].Length == 0)
                {
                    me.DruzynaWalczaca = null;
                }
                else
                {
                    me.DruzynaWalczaca = LookupTeamById(int.Parse(cols[1]));
                }
             
                me.Wynik= double.Parse(cols[2]);

                int parentId = 0;

                if (int.TryParse(cols[3], out parentId)) 
                {
                    me.PoprzedzajacyMecz = LookupMatchupById(parentId);
                }
                else
                {
                    me.PoprzedzajacyMecz = null;
                }
                
             
                output.Add(me);
            }

            return output;
        }

        public static List<Mecz> ConvertToMatchupModels(this List<string> lines)
        {

            // id=0, entries = 1(pipe delimited by id), winner = 2, matchupRound = 3
            List<Mecz> output = new List<Mecz>();

            foreach (string line in lines)
            {

                string[] cols = line.Split(',');

                Mecz p = new Mecz();
                p.ID = int.Parse(cols[0]);
                p.Tura = ConvertStringToMatchupEntryModels(cols[1]);
                if(cols[2].Length == 0)
                {
                    p.Zwyciezca = null;
                }
                else
                {
                    p.Zwyciezca = LookupTeamById(int.Parse(cols[2]));
                }
               
                p.AktualnaRunda = int.Parse(cols[3]);


                output.Add(p);
            }

            return output;

        }

        public static void SaveMatchupToFile(this Mecz matchup)
        {
            List<Mecz> matchups = GlobalConfig.MeczeFile.FullFilePath().LoadFile().ConvertToMatchupModels();

            int currentId = 1;
            if (matchups.Count > 0)
            {
                currentId = matchups.OrderByDescending(x => x.ID).First().ID + 1;
            }

            matchup.ID = currentId;
            matchups.Add(matchup);
            

            foreach ( AktualnyMecz entry in matchup.Tura)
            {

                entry.SaveEntryToFile();
            }

            // save to files
            List<string> lines = new List<string>();

            foreach (Mecz m in matchups)
            { 
                string winner = "";
                if (m.Zwyciezca != null)
                {
                    winner = m.Zwyciezca.ID.ToString();
                }
                lines.Add($"{ m.ID},{ ConvertMatchupEntryListToString(m.Tura)},{ winner},{m.AktualnaRunda}");
            }

            File.WriteAllLines(GlobalConfig.MeczeFile.FullFilePath(), lines);

        }

        public static void UpdateMatchupToFile(this Mecz matchup)
        {
            List<Mecz> matchups = GlobalConfig.MeczeFile.FullFilePath().LoadFile().ConvertToMatchupModels();

            Mecz oldMatchup = new Mecz();
            foreach (Mecz m in matchups)
            {
                if(m.ID == matchup.ID)
                {
                    oldMatchup = m;
                    
                }
            }

            matchups.Remove(oldMatchup);
            matchups.Add(matchup);


            foreach (AktualnyMecz entry in matchup.Tura)
            {
                entry.UpdateEntryToFile();
            }

            // save to files
            List<string> lines = new List<string>();

            foreach (Mecz m in matchups)
            {
                string winner = "";
                if (m.Zwyciezca != null)
                {
                    winner = m.Zwyciezca.ID.ToString();
                }
                lines.Add($"{m.ID},{ ConvertMatchupEntryListToString(m.Tura)},{ winner},{m.AktualnaRunda}");
            }

            File.WriteAllLines(GlobalConfig.MeczeFile.FullFilePath(), lines);
        }

        public static void SaveEntryToFile(this AktualnyMecz entry)
        {
            List<AktualnyMecz> entries = GlobalConfig.AktualneMeczeFile.FullFilePath().LoadFile().ConvertToMatchupEntryModels();
           
            List<string> lines = new List<string>();

            int currentId = 1;
            if (entries.Count > 0)
            {
                currentId = entries.OrderByDescending(x => x.ID).First().ID + 1;
            }

            entry.ID = currentId;
            entries.Add(entry);

           
            foreach (AktualnyMecz e in entries)
            {
                string parent = "";

                if(e.PoprzedzajacyMecz != null)
                {
                    parent = e.PoprzedzajacyMecz.ID.ToString();
                }

                string teamCompeting = "";

                if(e.DruzynaWalczaca != null)
                {
                    teamCompeting = e.DruzynaWalczaca.ID.ToString();
                }

                lines.Add($"{ e.ID},{ teamCompeting},{ e.Wynik},{parent}");
            }

            File.WriteAllLines(GlobalConfig.AktualneMeczeFile.FullFilePath(), lines);

        }

        public static void UpdateEntryToFile(this AktualnyMecz entry)
        {
            List<AktualnyMecz> entries = GlobalConfig.AktualneMeczeFile.FullFilePath().LoadFile().ConvertToMatchupEntryModels();

            List<string> lines = new List<string>();

            AktualnyMecz oldEntry = new AktualnyMecz();
            foreach (AktualnyMecz e in entries)
            {
                if(e.ID == entry.ID)
                {
                    oldEntry = e;
                }
            }
            entries.Remove(oldEntry);
            entries.Add(entry);


            foreach (AktualnyMecz e in entries)
            {
                string parent = "";

                if (e.PoprzedzajacyMecz != null)
                {
                    parent = e.PoprzedzajacyMecz.ID.ToString();
                }

                string teamCompeting = "";

                if (e.DruzynaWalczaca != null)
                {
                    teamCompeting = e.DruzynaWalczaca.ID.ToString();
                }

                lines.Add($"{ e.ID},{ teamCompeting},{ e.Wynik},{parent}");
            }

            File.WriteAllLines(GlobalConfig.AktualneMeczeFile.FullFilePath(), lines);

        }

        private static string ConvertRoundListToString(List<List<Mecz>> rounds)
        {
           
            string output = "";

            if (rounds.Count == 0)
            {
                return "";
            }

            foreach (List<Mecz> r in rounds)
            {
                output += $"{CovertMatchupListToString(r) }|";
            }

            output = output.Substring(0, output.Length - 1);

            return output;
        }

        private static string CovertMatchupListToString(List<Mecz> matchups)
        {
            string output = "";

            if (matchups.Count == 0)
            {
                return "";
            }

            foreach (Mecz m in matchups)
            {
                output += $"{m.ID}^";
            }

            output = output.Substring(0, output.Length - 1);

            return output;
        }
        
        private static string ConvertMatchupEntryListToString(List<AktualnyMecz> entries)
        {
            string output = "";

            if (entries.Count == 0)
            {
                return "";
            }

            foreach (AktualnyMecz e in entries)
            {
                output += $"{e.ID}|";
            }

            output = output.Substring(0, output.Length - 1);

            return output;
        }

        private static string ConvertPrizeListToString(List<Nagroda> prizes)
        {
            string output = "";

            if (prizes.Count == 0)
            {
                return "";
            }

            foreach (Nagroda p in prizes)
            {
                output += $"{p.ID}|";
            }

            output = output.Substring(0, output.Length - 1);

            return output;
        }


        private static string ConvertTeamListToString(List<Druzyna> teams)
        {
            string output = "";

            if (teams.Count == 0)
            {
                return "";
            }

            foreach (Druzyna t in teams)
            {
                output += $"{t.ID}|";
            }

            output = output.Substring(0, output.Length - 1);

            return output;
        }

        private static string ConvertPeopleListToString(List<Osoba> people)
        {
            string output = "";

            if(people.Count == 0)
            {
                return "";
            }

            foreach (Osoba p in people)
            {
                output += $"{p.ID}|";
            }

            output = output.Substring(0, output.Length - 1);

            return output;
        }
    }


}
