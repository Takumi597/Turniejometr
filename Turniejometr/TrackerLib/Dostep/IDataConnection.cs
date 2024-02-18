using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerLib.Modele;
using TrackerLib;


namespace TrackerLib.Data
{
    public interface IDataConnection
    {
        void CreatePrize(Nagroda model);
        void CreatePerson(Osoba model);
        void CreateTeam(Druzyna model);
        void CreateTournament(Turniej model);
        void UpdateMatchup(Mecz model);
        void CompleteTournament(Turniej model);
        List<Osoba> GetPerson_All();
        List<Druzyna> GetTeam_All();
        List<Turniej> GetTournament_All();
    }
}
