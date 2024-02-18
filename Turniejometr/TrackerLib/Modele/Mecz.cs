using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerLib.Modele
{
    public class Mecz
    {
        public int ID {  get; set; }
        public int ZwyciezcaID { get; set; }
        public List<AktualnyMecz> Tura { get; set; } = new List<AktualnyMecz>();
        public Druzyna Zwyciezca { get; set; }
        public int AktualnaRunda { get; set; }

        public string WyswietlImie
        {
            get
            {
                string output = "";
                foreach (AktualnyMecz me in Tura)
                {
                    if (me.DruzynaWalczaca != null)
                    {
                        if (output.Length == 0)
                        {
                            output = me.DruzynaWalczaca.NazwaDruzyny;
                        }
                        else
                        {
                            output += $" vs. {me.DruzynaWalczaca.NazwaDruzyny}";
                        }
                    }
                    else
                    {
                        output = "Nie ma jeszcze zwycięzcy";
                        break;
                    }
                }
                return output;
            }
        }
    }
}
