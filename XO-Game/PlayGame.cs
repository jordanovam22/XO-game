using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XO_Game
{
    public partial class PlayGame : Form
    {
        bool turn = true;
        int turnCount = 0;

        public PlayGame()
        {
            InitializeComponent();
        }

        private void aboutToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("XO is a game for two players, X and O, who take turns marking the spaces " +
                "in a 3×3 grid. The player who succeeds in placing three of their marks in a diagonal, " +
                "horizontal, or vertical row is the winner.", "XO About");
        }

        private void exitToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (turn)
            {
                b.Text = "X";
                b.BackColor = Color.Orange;
            }
            else
            {
                b.Text = "O";
                b.BackColor = Color.Blue;
            }
            turn = !turn;
            b.Enabled = false;
            turnCount++;

            checkForWinner();
        }

        private void checkForWinner()
        {
            bool thereIsAWinner = false;

            // horizontal checks
            if ((btn1.Text == btn2.Text) && (btn2.Text == btn3.Text) && (!btn1.Enabled))
            {
                thereIsAWinner = true;
            }
            else if ((btn4.Text == btn5.Text) && (btn5.Text == btn6.Text) && (!btn4.Enabled))
            {
                thereIsAWinner = true;
            }
            else if ((btn7.Text == btn8.Text) && (btn8.Text == btn9.Text) && (!btn7.Enabled))
            {
                thereIsAWinner = true;
            }

            //vertical checks
            if ((btn1.Text == btn4.Text) && (btn4.Text == btn7.Text) && (!btn1.Enabled))
            {
                thereIsAWinner = true;
            }
            else if ((btn2.Text == btn5.Text) && (btn5.Text == btn8.Text) && (!btn2.Enabled))
            {
                thereIsAWinner = true;
            }
            else if ((btn3.Text == btn6.Text) && (btn6.Text == btn9.Text) && (!btn3.Enabled))
            {
                thereIsAWinner = true;
            }

            //diagonal checks
            if ((btn1.Text == btn5.Text) && (btn5.Text == btn9.Text) && (!btn1.Enabled))
            {
                thereIsAWinner = true;
            }
            else if ((btn3.Text == btn5.Text) && (btn5.Text == btn7.Text) && (!btn3.Enabled))
            {
                thereIsAWinner = true;
            }


            if (thereIsAWinner)
            {
                disableButtons();

                String winner = "";
                int sum = 0;

                if (turn)
                {
                    winner = lbName2.Text + " (O)";
                    sum = Convert.ToInt32(lbPlayer2.Text) + 1;
                    lbPlayer2.Text = (sum).ToString();
                }
                else
                {
                    winner = lbName1.Text + " (X)";
                    sum = Convert.ToInt32(lbPlayer1.Text) + 1;
                    lbPlayer1.Text = (sum).ToString();
                }

                playSoundForWin();
                MessageBox.Show(winner + " Wins!", "Yay!");
            }
            else
            {
                if (turnCount == 9)
                {
                    DialogResult d;
                    d = MessageBox.Show("Do you want to continue?", "Game over", MessageBoxButtons.YesNo);
                    if (d == DialogResult.Yes)
                    {
                        turn = true;
                        turnCount = 0;

                        btn1.Enabled = true;
                        btn2.Enabled = true;
                        btn3.Enabled = true;
                        btn4.Enabled = true;
                        btn5.Enabled = true;
                        btn6.Enabled = true;
                        btn7.Enabled = true;
                        btn8.Enabled = true;
                        btn9.Enabled = true;

                        btn1.Text = "";
                        btn2.Text = "";
                        btn3.Text = "";
                        btn4.Text = "";
                        btn5.Text = "";
                        btn6.Text = "";
                        btn7.Text = "";
                        btn8.Text = "";
                        btn9.Text = "";

                        btn1.BackColor = Color.Transparent;
                        btn2.BackColor = Color.Transparent;
                        btn3.BackColor = Color.Transparent;
                        btn4.BackColor = Color.Transparent;
                        btn5.BackColor = Color.Transparent;
                        btn6.BackColor = Color.Transparent;
                        btn7.BackColor = Color.Transparent;
                        btn8.BackColor = Color.Transparent;
                        btn9.BackColor = Color.Transparent;

                        btnAddPlayers.Enabled = false;
                        btnResetGame.Enabled = true;
                    }
                    else
                    {
                        Application.Exit();
                    }
                }
            }
        }

        //If we have a winner 
        private void disableButtons()
        {
            turnCount = 0;

            btn1.Enabled = false;
            btn2.Enabled = false;
            btn3.Enabled = false;
            btn4.Enabled = false;
            btn5.Enabled = false;
            btn6.Enabled = false;
            btn7.Enabled = false;
            btn8.Enabled = false;
            btn9.Enabled = false;

            btnAddPlayers.Enabled = false;
            btnResetGame.Enabled = true;
        }

        private void playSimpleSoundForGameOver()
        {
            try
            {
                SoundPlayer simpleSound = new SoundPlayer(@"C:\Users\majaj\Desktop\XO-Game\XO-Game\XO-GameOver.wav");
                simpleSound.Play();
            }
            catch { }
        }

        private void playSoundForWin()
        {
            try
            {
                SoundPlayer simpleSound = new SoundPlayer(@"C:\Users\majaj\Desktop\XO-Game\XO-Game\XO-applause.wav");
                simpleSound.Play();
            }
            catch { }
        }

        private void btnAddPlayers_Click_1(object sender, EventArgs e)
        {
            AddPlayerNames forma = new AddPlayerNames();
            forma.ShowDialog();
            lbName1.Text = AddPlayerNames.player1;
            lbName2.Text = AddPlayerNames.player2;
            btnAddPlayers.Enabled = false;
            btnResetGame.Enabled = true;
        }

        private void btnResetGame_Click_1(object sender, EventArgs e)
        {
            turn = true;
            turnCount = 0;

            btn1.Enabled = true;
            btn2.Enabled = true;
            btn3.Enabled = true;
            btn4.Enabled = true;
            btn5.Enabled = true;
            btn6.Enabled = true;
            btn7.Enabled = true;
            btn8.Enabled = true;
            btn9.Enabled = true;

            btn1.Text = "";
            btn2.Text = "";
            btn3.Text = "";
            btn4.Text = "";
            btn5.Text = "";
            btn6.Text = "";
            btn7.Text = "";
            btn8.Text = "";
            btn9.Text = "";

            btn1.BackColor = Color.Transparent;
            btn2.BackColor = Color.Transparent;
            btn3.BackColor = Color.Transparent;
            btn4.BackColor = Color.Transparent;
            btn5.BackColor = Color.Transparent;
            btn6.BackColor = Color.Transparent;
            btn7.BackColor = Color.Transparent;
            btn8.BackColor = Color.Transparent;
            btn9.BackColor = Color.Transparent;

            btnAddPlayers.Enabled = false;
            btnResetGame.Enabled = true;
        }

        private void btnNewGame_Click_1(object sender, EventArgs e)
        {
            playSimpleSoundForGameOver();

            turn = true;
            turnCount = 0;

            btn1.Enabled = true;
            btn2.Enabled = true;
            btn3.Enabled = true;
            btn4.Enabled = true;
            btn5.Enabled = true;
            btn6.Enabled = true;
            btn7.Enabled = true;
            btn8.Enabled = true;
            btn9.Enabled = true;

            btn1.Text = "";
            btn2.Text = "";
            btn3.Text = "";
            btn4.Text = "";
            btn5.Text = "";
            btn6.Text = "";
            btn7.Text = "";
            btn8.Text = "";
            btn9.Text = "";

            btn1.BackColor = Color.Transparent;
            btn2.BackColor = Color.Transparent;
            btn3.BackColor = Color.Transparent;
            btn4.BackColor = Color.Transparent;
            btn5.BackColor = Color.Transparent;
            btn6.BackColor = Color.Transparent;
            btn7.BackColor = Color.Transparent;
            btn8.BackColor = Color.Transparent;
            btn9.BackColor = Color.Transparent;

            btnAddPlayers.Enabled = true;
            btnResetGame.Enabled = false;
            lbPlayer1.Text = "0";
            lbPlayer2.Text = "0";
            lbName1.Text = "Player 1 :";
            lbName2.Text = "Player 2 :";
        }

    }
}
