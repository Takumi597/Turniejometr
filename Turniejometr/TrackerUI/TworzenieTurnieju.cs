using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrackerLib.Wlasciwosci;
using TrackerLib.Modele;
using TrackerLib;

namespace UI
{
    public partial class TworzenieTurnieju : Form, IPrizeRequester, ITeamRequester
    {

        List<Druzyna> availableTeams = GlobalConfig.Connection.GetTeam_All();
        List<Druzyna> selectedTeams = new List<Druzyna>();
        List<Nagroda> selectedPrizes = new List<Nagroda>();
        public TworzenieTurnieju()
        {
            InitializeComponent();
            WireUpLists();
        }

        private void WireUpLists()
        {
            WybierzDruzyne.DataSource = null;
            ListaGraczy.DataSource = null;
            ListaNagrod.DataSource = null;

            WybierzDruzyne.DataSource = availableTeams;
            WybierzDruzyne.DisplayMember = "TeamName";

            ListaGraczy.DataSource = selectedTeams;
            ListaGraczy.DisplayMember = "TeamName";

            ListaNagrod.DataSource = selectedPrizes;
            ListaNagrod.DisplayMember = "PlaceName";

        }

        private void DodajDruzynePrzycisk_Click(object sender, EventArgs e)
        {

            Druzyna t = (Druzyna)WybierzDruzyne.SelectedItem;
            if (t != null)
            {
                availableTeams.Remove(t);
                selectedTeams.Add(t);
                WireUpLists();
            }
        }

        private void DodajNagrodePrzycisk_Click(object sender, EventArgs e)
        {

            TworzenieNagrod frm = new TworzenieNagrod(this);
            frm.Show();
        }

        public void PrizeComplete(Nagroda model)
        {

            selectedPrizes.Add(model);
            WireUpLists();

        }

        public void TeamComplete(Druzyna model)
        {
            selectedTeams.Add(model);
            WireUpLists();
        }

        private void DodajDruzyne_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            TworzenieDruzyny frm = new TworzenieDruzyny(this);

            frm.Show();

        }

        private void UsunGraczy_Click(object sender, EventArgs e)
        {
            Druzyna t = (Druzyna)ListaGraczy.SelectedItem;
            if (t != null)
            {
                selectedTeams.Remove(t);
                availableTeams.Add(t);
                WireUpLists();
            }
        }

        private void UsunNagrody_Click(object sender, EventArgs e)
        {
            Nagroda p = (Nagroda)ListaNagrod.SelectedItem;
            if (p != null)
            {
                selectedPrizes.Remove(p);
                WireUpLists();
            }
        }

        private void StworzTurniej_Click(object sender, EventArgs e)
        {


            decimal fee = 0;

            bool feeAcceptable = decimal.TryParse(PoleKwoty.Text, out fee);

            if (!feeAcceptable)
            {
                MessageBox.Show("Wprowadz poprawną opłatę",
                    "Niepoprawna opłata",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }


            Turniej tm = new Turniej();

            tm.NazwaTurnieju = PoleNazwyTurnieju.Text;
            tm.Opłata = fee;

            tm.Nagrody = selectedPrizes;
            tm.AktywneDruzyny = selectedTeams;


            TournamentLogic.CreateRounds(tm);


            GlobalConfig.Connection.CreateTournament(tm);
            Widok frm = new Widok(tm);
            frm.Show();
            Close();

        }

        private void DodajDruzyne_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            TworzenieDruzyny teamForm = new TworzenieDruzyny(this);
            teamForm.Show();
        }
    }
}
