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
    public partial class ChooseGameType : Form
    {
        public ChooseGameType()
        {
            InitializeComponent();
        }

        private void btn1Vs1_Click(object sender, EventArgs e)
        {
            this.Hide();
            AddPlayerNames forma = new AddPlayerNames();
            forma.ShowDialog();
            this.Close();
        }

        private void btnEasy_Click(object sender, EventArgs e)
        {
            
        }
    }
}
