using System.ComponentModel;
using TrackerLib.Modele;
using TrackerLib.Wlasciwosci;

namespace UI
{
    public partial class Widok : Form
    {
        private Turniej tournament;
        BindingList<int> rounds = new BindingList<int>();
        BindingList<Mecz> selectedMatchups = new BindingList<Mecz>();



        public Widok(Turniej tournamentModel)
        {
            InitializeComponent();

            tournament = tournamentModel;

            tournament.OnTournamentComplete += Tournament_OnTournamentComplete;

            WireUpLists();

            LoadFormData();

            LoadRounds();
        }

        private void Tournament_OnTournamentComplete(object sender, DateTime e)
        {
            Close();
        }

        private void LoadFormData()
        {
            TurniejNazwa.Text = tournament.NazwaTurnieju;
        }

        private void WireUpLists()
        {

            RundaNumer.DataSource = rounds;
            ListaMeczy.DataSource = selectedMatchups;
            ListaMeczy.DisplayMember = "DisplayName";

        }


        private void LoadRounds()
        {

            rounds.Clear();

            rounds.Add(1);
            int currRound = 1;

            foreach (List<Mecz> matchups in tournament.Rundy)
            {
                if (matchups.First().AktualnaRunda > currRound)
                {
                    currRound = matchups.First().AktualnaRunda;
                    rounds.Add(currRound);
                }
            }

            LoadMatchups(1);

        }
        private void RundaNumer_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadMatchups((int)RundaNumer.SelectedItem);


        }

        private void LoadMatchups(int round)
        {


            foreach (List<Mecz> matchups in tournament.Rundy)
            {
                if (matchups.First().AktualnaRunda == round)
                {
                    selectedMatchups.Clear();

                    foreach (Mecz m in matchups)
                    {
                        if (m.Zwyciezca == null || !CzyTylkoNoweRundy.Checked)
                        {
                            selectedMatchups.Add(m);
                        }
                    }

                }

            }

            if (selectedMatchups.Count > 0)
            {
                LoadMatchup(selectedMatchups.First());
            }

            DisplayMatchupInfo();

        }

        private void DisplayMatchupInfo()
        {
            bool isVisible = (selectedMatchups.Count > 0);

            Druzyna1.Visible = isVisible;
            Wynik1.Visible = isVisible;
            Wynik1label.Visible = isVisible;

            Druzyna2.Visible = isVisible;
            Wynik2label.Visible = isVisible;
            Wynik2.Visible = isVisible;

            VSlabel.Visible = isVisible;
            PotwierdzWynik.Visible = isVisible;
        }

        private void LoadMatchup(Mecz m)
        {


            for (int i = 0; i < m.Tura.Count; i++)
            {
                if (i == 0)
                {
                    if (m.Tura[0].DruzynaWalczaca != null)
                    {
                        Druzyna1.Text = m.Tura[0].DruzynaWalczaca.NazwaDruzyny;
                        Wynik1.Text = m.Tura[0].Wynik.ToString();

                        Druzyna2.Text = "<naura>";
                        Wynik2.Text = "0";

                    }
                    else
                    {
                        Druzyna1.Text = "Nie ustawiono";
                        Wynik1.Text = "";
                    }
                }

                if (i == 1)
                {
                    if (m.Tura[1].DruzynaWalczaca != null)
                    {
                        Druzyna2.Text = m.Tura[1].DruzynaWalczaca.NazwaDruzyny;
                        Wynik2.Text = m.Tura[1].Wynik.ToString();

                    }
                    else
                    {
                        Druzyna2.Text = "Not yet Set";
                        Wynik2.Text = "";
                    }
                }
            }


        }

        private void ListaMeczy_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadMatchup((Mecz)ListaMeczy.SelectedItem);
        }

        private void CzyTylkoNoweRundy_CheckedChanged(object sender, EventArgs e)
        {
            LoadMatchups((int)RundaNumer.SelectedItem);
        }

        private bool IsValidData()
        {
            bool output = true;
            double teamOneScore = 0;
            double teamTwoScore = 0;

            bool scoreOneValid = double.TryParse(Wynik1.Text, out teamOneScore);
            bool scoreTwoValid = double.TryParse(Wynik2.Text, out teamTwoScore);

            if (!scoreOneValid || !scoreTwoValid)
            {
                output = false;
            }
            if (teamOneScore == 0 && teamTwoScore == 0)
            {
                output = false;
            }
            if (teamOneScore == teamTwoScore)
            {
                output = false;
            }

            return output;


        }

        private void PotwierdzWynik_Click(object sender, EventArgs e)
        {
            if (!IsValidData())
            {
                MessageBox.Show("Wprowadü dane zanim przejdziemy dalej");
                return;
            }
            Mecz m = (Mecz)ListaMeczy.SelectedItem;
            double teamOneScore = 0;
            double teamTwoScore = 0;

            for (int i = 0; i < m.Tura.Count; i++)
            {
                if (i == 0)
                {
                    if (m.Tura[0].DruzynaWalczaca != null)
                    {
                        Druzyna1.Text = m.Tura[0].DruzynaWalczaca.NazwaDruzyny;


                        bool scoreValid = double.TryParse(Wynik1.Text, out teamOneScore);

                        if (scoreValid)
                        {
                            m.Tura[0].Wynik = teamOneScore;
                        }
                        else
                        {
                            MessageBox.Show("Wprowadü wynik druøyny 1.");
                            return;
                        }
                    }

                }

                if (i == 1)
                {
                    if (m.Tura[1].DruzynaWalczaca != null)
                    {



                        bool scoreValid = double.TryParse(Wynik2.Text, out teamTwoScore);
                        if (scoreValid)
                        {
                            m.Tura[1].Wynik = teamTwoScore;
                        }
                        else
                        {
                            MessageBox.Show("Wprowadü wynik dla druøyny 2.");
                            return;
                        }
                    }

                }
            }

            if (teamOneScore > teamTwoScore)
            {
                // Team one wins
                m.Zwyciezca = m.Tura[0].DruzynaWalczaca;

            }
            else if (teamTwoScore > teamOneScore)
            {
                m.Zwyciezca = m.Tura[1].DruzynaWalczaca;
            }
            else
            {
                MessageBox.Show("I do not handle tie games.");
            }

            foreach (List<Mecz> round in tournament.Rundy)
            {
                foreach (Mecz rm in round)
                {
                    foreach (AktualnyMecz me in rm.Tura)
                    {
                        if (me.PoprzedzajacyMecz != null)
                        {
                            if (me.PoprzedzajacyMecz.ID == m.ID)
                            {
                                me.DruzynaWalczaca = m.Zwyciezca;
                            }
                        }
                    }
                }
            }

            try
            {
                TournamentLogic.UpdateTournamentResults(tournament);
            }
            catch (Exception ex)
            {

                MessageBox.Show($"The application had the following error: {ex.Message}");
                return;
            }

            LoadMatchups((int)RundaNumer.SelectedItem);


        }

       
    }
}
