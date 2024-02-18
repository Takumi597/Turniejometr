using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrackerLib.Modele;
using TrackerLib.Wlasciwosci;
using TrackerLib;

namespace UI
{
    public partial class TworzenieNagrod : Form
    {
        IPrizeRequester callingForm;
        public TworzenieNagrod(IPrizeRequester caller)
        {
            InitializeComponent();
            callingForm = caller;
        }

        

        private void DodajNagrodePrzycisk_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                Nagroda model = new Nagroda(
                    Wprowadzliczbenagrody.Text,
                    WprowadzNazwenagrody.Text,
                    Wprowadzkwotenagrody.Text,
                    WprowadzProcentnagrody.Text);

                GlobalConfig.Connection.CreatePrize(model);
                callingForm.PrizeComplete(model);
                Close();

                Wprowadzliczbenagrody.Text = "";
                WprowadzNazwenagrody.Text = "";
                Wprowadzkwotenagrody.Text = "0";
                WprowadzProcentnagrody.Text = "0";
            }
            else
            {
                MessageBox.Show("Wprowadzone niewłaściwe dane");
            }
        }
private bool ValidateForm()
        {
            bool output = true;
            int placeNumber = 0;

            if (!(int.TryParse(Wprowadzliczbenagrody.Text, out placeNumber)))
            {
                output = false;
            }
            if (placeNumber < 1)
            {
                output = false;
            }
            if (WprowadzNazwenagrody.Text.Length == 0)
            {
                output = false;
            }

            decimal prizeAmount = 0;
            double prizePercentage = 0;

            bool prizeAmountValid = decimal.TryParse(Wprowadzkwotenagrody.Text, out prizeAmount);
            bool prizePercentageValid = double.TryParse(WprowadzProcentnagrody.Text, out prizePercentage);

            if (!prizeAmountValid || !prizePercentageValid)
            {
                output = false;
            }

            if (prizeAmount <= 0 && prizePercentage <= 0)
            {
                output = false;
            }

            if (prizePercentage < 0 || prizePercentage > 100)
            {
                output = false;
            }

            return output;
        }
        
    }
}
