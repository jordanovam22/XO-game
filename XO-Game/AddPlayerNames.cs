using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XO_Game
{
    public partial class AddPlayerNames : Form
    {
        public static string player1 = "";
        public static string player2 = "";

        public AddPlayerNames()
        {
            InitializeComponent();
        }

        private void btnSaveNames_Click(object sender, EventArgs e)
        {
            this.Hide();
            player1 = tbPlayer1.Text;
            player2 = tbPlayer2.Text;

            PlayGame forma = new PlayGame(PlayGame.GAME_1VS1);
            forma.ShowDialog();
            this.Close();
        }

        private void tbPlayer1_Validating(object sender, CancelEventArgs e)
        {
            if(tbPlayer1.Text.Trim().Length != 0)
            {
                errorProvider1.SetError(tbPlayer1, null);
                e.Cancel = false;
            }
            else
            {
                errorProvider1.SetError(tbPlayer1, "Внеси име!");
                e.Cancel = true;
            }
        }

        private void tbPlayer2_Validating(object sender, CancelEventArgs e)
        {
            if (tbPlayer2.Text.Trim().Length != 0)
            {
                errorProvider2.SetError(tbPlayer2, null);
                e.Cancel = false;
            }
            else
            {
                errorProvider2.SetError(tbPlayer2, "Внеси име!");
                e.Cancel = true;
            }
        }
    }
}
