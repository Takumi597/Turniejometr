using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerLib.Modele
{
    public class Turniej
    {
        public event EventHandler<DateTime> OnTournamentComplete;
        public int ID { get; set; }
        public string NazwaTurnieju { get; set; }
        public decimal Opłata { get; set; }
        public List<Druzyna> AktywneDruzyny { get; set; } = new List<Druzyna>();
        public List<List<Mecz>> Rundy { get; set; } = new List<List<Mecz>>();
        public List<Nagroda> Nagrody { get; set; } = new List<Nagroda>();
       
        public void CompleteTournament()
        {
            OnTournamentComplete?.Invoke(this, DateTime.Now);
        }
    }
}
