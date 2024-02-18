using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerLib.Modele
{
    public class Druzyna
    {

        public List<Osoba> CzlonkowieDruzyny { get; set; } = new List<Osoba>();
        public string NazwaDruzyny { get; set; }
        public int ID { get; set; }
    }
}
