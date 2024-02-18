using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrackerLib;
using TrackerLib.Modele;
using TrackerLib.Wlasciwosci;

namespace UI
{
    public partial class TworzenieDruzyny : Form
    {
        private List<Osoba> availableTeamMembers = GlobalConfig.Connection.GetPerson_All();
        private List<Osoba> selectedTeamMembers = new List<Osoba>();
        private ITeamRequester callingForm;
        public TworzenieDruzyny(ITeamRequester caller)
        {
            InitializeComponent();
            WireUpLists();
            //CreateSampleData();
            callingForm = caller;

        }


        private void CreateSampleData()
        {
            availableTeamMembers.Add(new Osoba { Imie = "Bartosh", Nazwisko = "Kowal" });
            availableTeamMembers.Add(new Osoba { Imie = "Maria", Nazwisko = "Kowalska" });

            selectedTeamMembers.Add(new Osoba { Imie = "Wiktor", Nazwisko = "Kramer" });
            selectedTeamMembers.Add(new Osoba { Imie = "Cyprian", Nazwisko = "Fora" });
        }

        private void WireUpLists()
        {
            WybierzCzlonkaDruzyny.DataSource = null;

            WybierzCzlonkaDruzyny.DataSource = availableTeamMembers;
            WybierzCzlonkaDruzyny.DisplayMember = "FullName";

            CzlonkowieDruzyny.DataSource = null;

            CzlonkowieDruzyny.DataSource = selectedTeamMembers;
            CzlonkowieDruzyny.DisplayMember = "FullName";
        }

        private void DodajCzlonkaPrzycisk_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                Osoba p = new Osoba();

                p.Imie = WprowadzImie.Text;
                p.Nazwisko = WprowadzNazwisko.Text;


                GlobalConfig.Connection.CreatePerson(p);

                selectedTeamMembers.Add(p);

                WireUpLists();

                WprowadzImie.Text = "";
                WprowadzNazwisko.Text = "";

            }
            else
            {
                MessageBox.Show("Wypełnij wszystkie pola");
            }
        }

        private void DodajCzlonkaDruzynyPrzycisk_Click(object sender, EventArgs e)
        {
            Osoba p = (Osoba)WybierzCzlonkaDruzyny.SelectedItem;

            if (p != null)
            {
                availableTeamMembers.Remove(p);
                selectedTeamMembers.Add(p);

                WireUpLists();
            }
        }

        private void UsunCzlonka_Click(object sender, EventArgs e)
        {
            Osoba p = (Osoba)CzlonkowieDruzyny.SelectedItem;

            if (p != null)
            {
                selectedTeamMembers.Remove(p);
                availableTeamMembers.Add(p);

                WireUpLists();
            }
        }

        private void DodajDruzyne_Click(object sender, EventArgs e)
        {
            Druzyna t = new Druzyna();

            t.NazwaDruzyny = PoleNazwyDruzyny.Text;
            t.CzlonkowieDruzyny = selectedTeamMembers;

            GlobalConfig.Connection.CreateTeam(t);
            callingForm.TeamComplete(t);
            this.Close();


        }
        private bool ValidateForm()
        {
            if (WprowadzImie.Text.Length == 0)
            {
                return false;
            }

            if (WprowadzNazwisko.Text.Length == 0)
            {
                return false;
            }

            return true;
        }

        private void WybierzCzlonkaDruzyny_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void CzlonkowieDruzyny_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void PoleNazwyDruzyny_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
