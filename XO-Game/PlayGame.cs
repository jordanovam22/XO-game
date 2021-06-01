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
        public static int GAME_1VS1 = 0;
        public static int GAME_EASY = 1;
        public static int GAME_HARD = 2;

        private int[,] gameMatrix = new int[3, 3] { { -1, -1, -1 }, { -1, -1, -1 }, { -1, -1, -1 } };
        private Button[,] gameButtons;

        public int gameType; // 0-1 vs 1, 1-easy, 2-hard 
        bool turn = true;
        int turnCount = 0;

        public PlayGame(int gameType)
        {
            this.gameType = gameType;
            InitializeComponent();
            this.gameButtons = new Button[3, 3] { { btn1, btn2, btn3 }, { btn4, btn5, btn6 }, { btn7, btn8, btn9 } };
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
                b.BackColor = Color.Firebrick;
            }
            else
            {
                b.Text = "O";
                b.BackColor = Color.SteelBlue;
            }
            turn = !turn;
            b.Enabled = false;
            turnCount++;

            checkForWinner();
        }

        private void checkForWinner()
        {
            // Доколку имаме победник, односно доколку во некој од случаевите погоре thereIsAWinner == true
            if (horizontalCheck() || verticalCheck() || diagonalCheck())
            {
                // Доколку веќе имаме победник го повикуваме овој метод за да оневозможиме кликнување на останатите копчиња
                disableButtons();

                // Овој метод содржи соодветен звук кој се активира при победа на играчот
                playSoundForWin(); 

                // Го пронаоѓа и принта победникот 
                printWinner();
            }
            else if (turnCount == 9)
            {
                // Го прашува корисникот дали сака нова игра
                confirmNewGame();
            }
        }

        // Овде ги проверуваме знаците во полињата во дијагонален ред
        private bool diagonalCheck()
        {
            if ((btn1.Text == btn5.Text) && (btn5.Text == btn9.Text) && (!btn1.Enabled))
            {
                return true;
            }
            else if ((btn3.Text == btn5.Text) && (btn5.Text == btn7.Text) && (!btn3.Enabled))
            {
                return true;
            }
            return false;
        }

        // Овде ги проверуваме знаците во полињата во вертикален ред
        private bool verticalCheck()
        {
            if ((btn1.Text == btn4.Text) && (btn4.Text == btn7.Text) && (!btn1.Enabled))
            {
                return true;
            }
            else if ((btn2.Text == btn5.Text) && (btn5.Text == btn8.Text) && (!btn2.Enabled))
            {
                return true;
            }
            else if ((btn3.Text == btn6.Text) && (btn6.Text == btn9.Text) && (!btn3.Enabled))
            {
                return true;
            }
            return false;
        }

        // Овде ги проверуваме знаците во полињата во хоризонтален ред
        private bool horizontalCheck()
        {
            if ((btn1.Text == btn2.Text) && (btn2.Text == btn3.Text) && (!btn1.Enabled))
            {
                return true;
            }
            else if ((btn4.Text == btn5.Text) && (btn5.Text == btn6.Text) && (!btn4.Enabled))
            {
                return true;
            }
            else if ((btn7.Text == btn8.Text) && (btn8.Text == btn9.Text) && (!btn7.Enabled))
            {
                return true;
            }
            return false;
        }

        // Го прашуваме играчот дали сака да продолжи и понатаму да игра
        private void confirmNewGame()
        {
            // Ни се прикажува прозорец дали сакаме да продолжиме да играме, или не
            DialogResult d;
            d = MessageBox.Show("Do you want to continue?", "Game over", MessageBoxButtons.YesNo);
            // Доколку одовориме со Yes, играта продолжува со истите играчи само се ресетираат одредени копчиња
            if (d == DialogResult.Yes)
            {
                resetGame();
            }
            // Доколку одговориме со No, апликацијата се затвора, односно играта завршува
            else
            {
                Application.Exit();
            }
        }

        // // Го пронаоѓа и принта победникот 
        private void printWinner()
        {
            String winner = ""; // Оваа променлива е креирана со цел да го содржи името на победникот кое се прикажува при победа
            int sum = 0; // Во оваа променлива соодветно го чуваме резултатот за двајцата играчи

            // Со овој код ги менуваме полињата на лабелите каде се прикажува резултатот помеѓу играчите
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
            MessageBox.Show(winner + " Wins!", "Yay!"); // Порака која се прикажува доколку некој од играчите победи
        }

        // Кога имаме победник оневозможува кликање на другите копчиња
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

            btnResetGame.Enabled = true;
        }

        // Ја ресетира играта
        private void resetGame()
        {
            turn = true;
            turnCount = 0;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    gameButtons[i, j].Enabled = true;
                    gameButtons[i, j].Text = "";
                    gameButtons[i, j].BackColor = Color.Transparent;
                }
            }
            btnResetGame.Enabled = true;
        }

        // Дава звук во позадина кога играчот ќе кликне нова рунда
        private void playSimpleSoundForGameOver()
        {
            try
            {
                SoundPlayer simpleSound = new SoundPlayer(@"C:\Users\majaj\Desktop\XO-Game\XO-Game\XO-GameOver.wav");
                simpleSound.Play();
            }
            catch { }
        }

        // Дава звук во позадина кога има победник
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
            btnResetGame.Enabled = true;
        }

        private void btnResetGame_Click_1(object sender, EventArgs e)
        {
            playSimpleSoundForGameOver();

            resetGame();
        }

        private void btnNewGame_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            ChooseGameType forma = new ChooseGameType();
            forma.ShowDialog();
            this.Close();

            resetGame();

            lbPlayer1.Text = "0";
            lbPlayer2.Text = "0";
            lbName1.Text = "Player 1 :";
            lbName2.Text = "Player 2 :";
        }

        private void PlayGame_Load(object sender, EventArgs e)
        {
            lbName1.Text = AddPlayerNames.player1;
            lbName2.Text = AddPlayerNames.player2;
        }

    }
}
