# Опис на играта XO

## Објаснување на проблемот

XO е игра за двајца, X и O, кои наизменично ги обележуваат празнините во матрица 3 × 3. 
Играчот кој ќе успее да постави три свои ознаки во дијагонален, хоризонтален или вертикален ред е победник. 

Кога ке ја отворите играта, ви се покажува овој екран на кој можете да започнете нова игра со кликнување на копчето “Start Game”.

 

Следна форма која се прикажува е формата AddPlayerNames која ни овозможува да ги внесеме имињата на играчите.

 







Последната форма која се прикажува е оваа форма. Во оваа форма имаме можност да започнеме нова рунда помеѓу веќе внесените играчи, или пак да започнеме нова игра со внесување на нови имиња на играчи. 

 

Со кликнување на File во менито имаме можност да ја затвориме играта со кликнување на Еxit, додека во Help со клик на About ни се отвора MessageBox со опис за самата игра. Целото тоа можеме да го видиме на следната слика.


## Да се опише решението на проблемот

Самата игра е имплементирана на доста едноставен начин. 

Се состои од три форми: 

- StartForm е почетната форма која се прикажува веднаш по стартувањето на играта и таа
содржи едно копче "Start Game" кое служи за започнување на играта. 

- AddPlayerNames е втората форма која се прикажува на екранот. Во неа имаме можност да ги внесеме имињата на двајцата играчи.

Карактеристично за оваа форма е тоа што се користи и подоцна во играта, поточно со клик на копчето "Add Player Names" кое се наоѓа на третата форма, каде имаме можност повторно да внесеме имиња на играчи доколку сакаме да започнеме нова игра.

- PlayGame е формата која се прикажува откако ќе ги внесеме имињата на играчите.
Оваа форма е всушност главната форма каде што е прикажана самата игра, девет полиња во матрица, копчиња како "New Round", "New Game" и "Add Player Names".

Во оваа игра се имплементирани и аудио звуци кои соодветно се активираат при победа или  започнување на нова рунда.

## Опис на функцијата checkForWinner() 

Функцијата е опишана соодветно преку коментари. Главна цел на овој метод е проверка за тоа дали имаме победник во играта, односно дали некој од играчите има успеано да постави три исти знаци во хоризонтален, вертикален или пак дијагонален ред.
/* checkForWinner */
private void checkForWinner()
        {
            bool thereIsAWinner = false; // На почетокот декларираме променлива bool која е false

            // horizontal checks
            // Овде ги проверуваме знаците во полињата во хоризонтален ред
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
            // Овде ги проверуваме знаците во полињата во вертикален ред
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
            // Овде ги проверуваме знаците во полињата во дијагонален ред
            if ((btn1.Text == btn5.Text) && (btn5.Text == btn9.Text) && (!btn1.Enabled))
            {
                thereIsAWinner = true;
            }
            else if ((btn3.Text == btn5.Text) && (btn5.Text == btn7.Text) && (!btn3.Enabled))
            {
                thereIsAWinner = true;
            }

            // Доколку имаме победник, односно доколку во некој од случаевите погоре thereIsAWinner == true
            if (thereIsAWinner)
            {
                disableButtons(); // Доколку веќе имаме победник го повикуваме овој метод за да оневозможиме кликнување на останатите копчиња

                String winner = ""; // Оваа променлива е креирана со цел да го содржи името на победникот кое се прикажува при победа во MessageBox
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

                playSoundForWin(); // Овој метод содржи соодветен звук кој се активира при победа на играчот
                MessageBox.Show(winner + " Wins!", "Yay!"); // Порака која се прикажува доколку некој од играчите победи
            }
            // Доколку немаме победник во рундата, односно доколку thereIsAWinner == false
            else
            {
                if (turnCount == 9)
                {
                    // Ни се прикажува прозорец дали сакаме да продолжиме да играме, или не
                    DialogResult d;
                    d = MessageBox.Show("Do you want to continue?", "Game over", MessageBoxButtons.YesNo);
                    // Доколку одовориме со Yes, играта продолжува со истите играчи само се ресетираат одредени копчиња
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

                        btnResetGame.Enabled = true;
                    }
                    // Доколку одговориме со No, апликацијата се затвора, односно играта завршува
                    else
                    {
                        Application.Exit();
                    }
                }
            }
        }
Овој метод повикува два други методи. Методот disableButtons() и методот playSoundForWin() кои соодветно се опишани во самиот код.

[линк](https://google.com)