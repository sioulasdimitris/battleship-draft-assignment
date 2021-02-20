using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BattleShip
{
    public partial class labelColumn8 : Form
    {
        System.Windows.Forms.Button[] computerButtons;
        System.Windows.Forms.Button[] playerButtons;
        //keep track of time passed till the end of the game
        int time;
        Player user;
        Player computer;
        int userWonsCounter = 0;
        int computerWonsCounter = 0;
        Game myGame;
        private HashSet<int> exclude;//hashset to keep track of already used positions

        public labelColumn8()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            myGame = new Game();
            startNewGame();
        }

        private void startNewGame()
        {
            computerBoard.Controls.Clear();//remove all buttons from the panel
            playerBoard.Controls.Clear();//remove all buttons from the panel
            myGame.startNewGame();
            exclude = new HashSet<int>();
            user = new Player();
            computer = new Player();
            AddButtonsforPlayer();
            AddButtonsforComputer();
            initializeVariables();
            timer.Enabled = true;
            panelRows1.Visible = true;
            panelColumns1.Visible = true;
            panelRows2.Visible = true;
            panelColumns2.Visible = true;
            userLabel.Visible = true;
            computerLabel.Visible = true;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            timeTextLabel.Text = time.ToString();
            time++;
        }
        
        private void initializeVariables()//initialize variables for start of the game
        {
            time = 0;
            timer.Start();
        }

        private void AddButtonsforPlayer()
        {
            int xPos = 0;
            int yPos = 0;
            // Declare and assign number of buttons = 26
            playerButtons = new System.Windows.Forms.Button[100];
            // Create (26) Buttons:
            for (int i = 0; i < 100; i++)
            {
                // Initialize one variable
                playerButtons[i] = new System.Windows.Forms.Button();
            }
            int n = 0;

            while (n < 100)
            {
                
                playerButtons[n].Tag = n; // Tag of button
                playerButtons[n].Width = 40; // Width of button
                playerButtons[n].Height = 40; // Height of button
                if (n % 10 == 0) // Location of every next line of buttons
                {   
                    xPos = 0;
                    yPos = n * 4;
                }
              
                // Location of button:
                playerButtons[n].Left = xPos;
                playerButtons[n].Top = yPos;
                // Add buttons to a Panel:
                playerBoard.Controls.Add(playerButtons[n]); // panel hold the Buttons
                xPos = xPos + playerButtons[n].Width; 
                playerButtons[n].Text = playerButtons[n].Tag.ToString();
                playerButtons[n].BackColor = Color.Cyan;
                

                // the Event of click Button
                playerButtons[n].Click += new System.EventHandler(ClickButton);
                n++;
            }
            //place ships
            for(int i=0;i< user.getShips().Length; i++)
            {
                for (int j = 0; j < user.getShips()[i].getSquares().Length; j++)
                {
                    playerButtons[user.getShips()[i].getSquares()[j]].BackColor = Color.Green;
                }
            }
        }


        private void AddButtonsforComputer()
        {
            int xPos = 0;
            int yPos = 0;
            // Declare and assign number of buttons = 26
            computerButtons = new System.Windows.Forms.Button[100];
            // Create (26) Buttons:
            for (int i = 0; i < 100; i++)
            {
                // Initialize one variable
                computerButtons[i] = new System.Windows.Forms.Button();
            }
            int n = 0;

            while (n < 100)
            {

                computerButtons[n].Tag = n; // Tag of button
                computerButtons[n].Width = 40; // Width of button
                computerButtons[n].Height = 40; // Height of button
                if (n % 10 == 0) // Location of every next line of buttons
                {
                    xPos = 0;
                    yPos = n * 4;
                }

                // Location of button:
                computerButtons[n].Left = xPos;
                computerButtons[n].Top = yPos;
                // Add buttons to a Panel:
                computerBoard.Controls.Add(computerButtons[n]); // panel hold the Buttons
                xPos = xPos + computerButtons[n].Width;
                computerButtons[n].Text = computerButtons[n].Tag.ToString();
                computerButtons[n].BackColor = Color.Cyan;


                // the Event of click Button
                computerButtons[n].Click += new System.EventHandler(ClickButton);
                n++;
            }
            //place ships
            /*for (int i = 0; i < computer.getShips().Length; i++)
            {
                for (int j = 0; j < computer.getShips()[i].getSquares().Length; j++)
                {
                    computerButtons[computer.getShips()[i].getSquares()[j]].BackColor = Color.Red;
                }
            }*/
        }

        // click button event
        public void ClickButton(Object sender, System.EventArgs e)
        {
            Button btn = (Button)sender;

            //if the user try to click on his own board with ships
            if (playerBoard.Controls.Contains(btn) && myGame.getWhosTurnIs() == 1)
            {
                MessageBox.Show("You can't sink your own ships!!!\nTry Again on The opponent's board this time!");
            } else if (String.Equals(btn.Text, "X") || String.Equals(btn.Text, "-"))//if user clicks on a previous clicked button
            {
                MessageBox.Show("Pick other square...");
            }            
            else
            {
                
                bool hitWasSuccesful = false;

                //user's turn
                if (myGame.getWhosTurnIs() == 1)
                {
                    user.increaseMovesCount();
                    for (int i = 0; i < computer.getShips().Length; i++)
                    {
                        for (int j = 0; j < computer.getShips()[i].getSquares().Length; j++)
                        {
                            if (String.Equals(btn.Tag, computer.getShips()[i].getSquares()[j]))
                            {

                                btn.Text = "X";
                                btn.ForeColor = Color.Red;
                                
                                hitWasSuccesful = true;
                                computer.getShips()[i].increaseSuccesfulHits();
                                if (computer.getShips()[i].getSinked())
                                {
                                    computer.increaseSinkedShipsNum();
                                    MessageBox.Show("You Sinked " + computer.getShips()[i].getName() + "!");
                                    if (!computer.isThereAnyLeft())
                                    {
                                        timer.Stop();
                                        userWonsCounter++;
                                        MessageBox.Show("You Won!!\nNumber of moves: " + computer.getMovesCount() + "\nSeconds passed: " + time);
                                        gameFinished();
                                    }
                                }
                            }
                        }
                        if (!hitWasSuccesful)
                        {
                            btn.Text = "-";
                            btn.ForeColor = Color.Green;
                        }
                    }
                }

                //computer's turn
                if (myGame.getWhosTurnIs() == 2)
                {
                    computer.increaseMovesCount();
                    for (int i = 0; i < user.getShips().Length; i++)
                    {
                        for (int j = 0; j < user.getShips()[i].getSquares().Length; j++)
                        {
                            if (String.Equals(btn.Tag, user.getShips()[i].getSquares()[j]))
                            {
                                btn.Text = "X";
                                btn.ForeColor = Color.Red;
                                hitWasSuccesful = true;
                                user.getShips()[i].increaseSuccesfulHits();
                                if (user.getShips()[i].getSinked())
                                {
                                    user.increaseSinkedShipsNum();
                                    MessageBox.Show("Your " + user.getShips()[i].getName() + " is sinked!");
                                    if (!user.isThereAnyLeft())
                                    {
                                        timer.Stop();
                                        computerWonsCounter++;
                                        MessageBox.Show("You Lost!!\nNumber of moves: " + computer.getMovesCount() + "\nSeconds passed: " + time);
                                        gameFinished();
                                    }
                                }
                            }
                        }
                        if (!hitWasSuccesful)
                        {
                            btn.Text = "-";
                            btn.ForeColor = Color.Green;
                        }
                    }
                }


                myGame.changeTurn();
                if (myGame.getWhosTurnIs() == 2)
                    computersTurn();
            }

            

        }


        public void computersTurn()
        {
            int position = getNewRandomPosition();//get a new random position to hit
            playerButtons[position].PerformClick();
            exclude.Add(position);
        }

        private int getNewRandomPosition()//get a new random position in range 0-99 excluding the already used positions
        {
            var range = Enumerable.Range(0, 100).Where(i => !exclude.Contains(i));

            var rand = new System.Random();
            int index = rand.Next(0, 100 - exclude.Count);//exclude used positions
            return range.ElementAt(index);
        }

        public void gameFinished()
        {
            DialogResult dialogResult = MessageBox.Show("Wanna play again?", "Battleship Game", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {       
                startNewGame();
            }
            else if (dialogResult == DialogResult.No)
            {
                MessageBox.Show("Games Counter: "+myGame.getNumOfGames() + "\nWons Counter: "+userWonsCounter+"\nLoses Counter: "+computerWonsCounter);
                System.Windows.Forms.Application.Exit();
            }
        }

      


    }
}
