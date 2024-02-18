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

namespace UI
{
    public partial class StronaGlowna : Form
    {
        List<Turniej> tournaments = GlobalConfig.Connection.GetTournament_All();

        public StronaGlowna()
        {
            InitializeComponent();
            WireUpLists();
        }


        private void WireUpLists()
        {
            WybierzCzlonkaDruzyny.DataSource = tournaments;
            WybierzCzlonkaDruzyny.DisplayMember = "TournamentName";
        }

        private void stworzTurniej_Click(object sender, EventArgs e)
        {
            TworzenieTurnieju frm = new TworzenieTurnieju();
            frm.Show();
        }

        private void WczytajTurniej_Click(object sender, EventArgs e)
        {
            Turniej tm = (Turniej)WybierzCzlonkaDruzyny.SelectedItem;
            Widok frm = new Widok(tm);
            frm.Show();
        }

        
    }
}
