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

        private void AddPlayerNames_Load(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            player1 = tbPlayer1.Text;
            player2 = tbPlayer2.Text;

            DialogResult dialogResult = MessageBox.Show("Do You Want To Save Your Data?", "Save Data", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
