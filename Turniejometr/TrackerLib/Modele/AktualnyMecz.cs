using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerLib.Modele
{
    public class AktualnyMecz
    {
        public int ID { get; set; }
        public Druzyna DruzynaWalczaca { get; set; }
        public int DruzynaWalczacaID { get; set; }

        public double Wynik { get; set; }

        public Mecz PoprzedzajacyMecz { get; set; }
        public int PoprzedzajacyMeczID { get; set; }
    }
}
