using System.Collections.Generic;
using System.Linq;
using TrackerLib.Modele;
using TrackerLib.Wlasciwosci;
using TrackerLib;

namespace TrackerLib.Data
{
    public class TextConnector : IDataConnection
    {
        
        public void CreatePerson(Osoba model)
        {
            List<Osoba> people = GlobalConfig.OsobyFile.FullFilePath().LoadFile().ConvertToPersonModels();
            int currentId = 1;

            if (people.Count > 0)
            {
                currentId = people.OrderByDescending(x => x.ID).First().ID + 1;
            }
            model.ID = currentId;

            //ad new record with id+1
            people.Add(model);

            //save list to txt
            people.SaveToPeopleFile();

        }

        public void CreatePrize(Nagroda model)
        {
            //load txt file
            //convert txt to a list of prize model
            List<Nagroda> prizes = GlobalConfig.NagrodyFile.FullFilePath().LoadFile().ConvertToPrizeModels();

            //find id
            int currentId = 1;
            //currentId = prizes.OrderByDescending(x => x.Id).First().Id + 1;
            if (prizes.Count > 0)
            {
                currentId = prizes.OrderByDescending(x => x.ID).First().ID + 1;
            }
            model.ID = currentId;

            //ad new record with id+1
            prizes.Add(model);

            //save list to txt
            prizes.SaveToPrizesFile();
        }



        public List<Osoba> GetPerson_All()
        {
            return GlobalConfig.OsobyFile.FullFilePath().LoadFile().ConvertToPersonModels();
        }
        public void CreateTeam(Druzyna model)
        {
            List<Druzyna> teams = GlobalConfig.DruzynyFile.FullFilePath().LoadFile().ConvertToTeams();

            
            int currentId = 1;
            
            if (teams.Count > 0)
            {
                currentId = teams.OrderByDescending(x => x.ID).First().ID + 1;
            }
            model.ID = currentId;
            teams.Add(model);

            teams.SaveToTeamFile();
        }

        public List<Druzyna> GetTeam_All()
        {
            return GlobalConfig.DruzynyFile.FullFilePath().LoadFile().ConvertToTeams();
        }

        public void CreateTournament(Turniej model)
        
        {
            List<Turniej> tournaments = GlobalConfig.TurniejeFile.FullFilePath()
                .LoadFile()
                .ConvertToTournaments();

            int currentId = 1;
            if (tournaments.Count > 0)
            {
                currentId = tournaments.OrderByDescending(x => x.ID).First().ID + 1;
            }
            model.ID = currentId;

            model.SaveRoundsToFile();
            tournaments.Add(model);
            tournaments.SaveToTournamentFile();
            TournamentLogic.UpdateTournamentResults(model);
        }

        public List<Turniej> GetTournament_All()
        {
            return GlobalConfig.TurniejeFile.FullFilePath()
                .LoadFile()
                .ConvertToTournaments();
        }

        public void UpdateMatchup(Mecz model)
        {
            model.UpdateMatchupToFile();
        }

        public void CompleteTournament(Turniej model)
        {
            List<Turniej> tournaments = GlobalConfig.TurniejeFile.FullFilePath()
                .LoadFile()
                .ConvertToTournaments();

            tournaments.Remove(model);
            tournaments.SaveToTournamentFile();
            TournamentLogic.UpdateTournamentResults(model);
        }
    }
}
