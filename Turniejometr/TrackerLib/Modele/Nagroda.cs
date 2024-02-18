using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerLib.Modele
{
    public class Nagroda
    {
        public int ID { get; set; }
        public int Miejsce { get; set; }
        public string Tytul { get; set; }
        public decimal Kwota { get; set; }

        public double KwotaProc { get; set; }
        public Nagroda()
        {

        }
        public Nagroda(string miejsce, string tytul, string kwota, string kwotaProc)
        {
            int placeNumberValue = 0;
            int.TryParse(miejsce, out placeNumberValue);
            Miejsce = placeNumberValue;

            Tytul = tytul;

            decimal prizeAmountValue = 0;
            decimal.TryParse(kwota, out prizeAmountValue);
            Kwota = Convert.ToDecimal(kwota);

            double KwotaProcWartosc = 0;
            double.TryParse(kwotaProc, out KwotaProcWartosc);
            KwotaProc = KwotaProcWartosc;
        }
    }
}
