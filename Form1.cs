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
        //keep count of total moves of each player till the end of the game
        int playerMovesCounter;
        int pcMovesCounter;
        //keep track of time passed till the end of the game
        int time;
        PlayerShips userShips;
        PlayerShips computerShips;

        public labelColumn8()
        {
            InitializeComponent();
        }

        private void startNewGame_Click(object sender, EventArgs e)
        {
            userShips = new PlayerShips();
            computerShips = new PlayerShips();
            AddButtonsforPlayer();
            AddButtonsforComputer();
            initializeVariables();
            timer.Enabled = true;
            panelRows1.Visible = true;
            panelColumns1.Visible = true;
            panelRows2.Visible = true;
            panelColumns2.Visible = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void timer_Tick(object sender, EventArgs e)
        {
            timeTextLabel.Text = time.ToString();
            time++;
        }
        
        private void initializeVariables()//initialize variables for start of the game
        {
            playerMovesCounter = 0;
            pcMovesCounter = 0;
            time = 0;
        }

        private void AddButtonsforPlayer()
        {
            int xPos = 0;
            int yPos = 0;
            // Declare and assign number of buttons = 26
            System.Windows.Forms.Button[] btnArray = new System.Windows.Forms.Button[100];
            // Create (26) Buttons:
            for (int i = 0; i < 100; i++)
            {
                // Initialize one variable
                btnArray[i] = new System.Windows.Forms.Button();
            }
            int n = 0;

            while (n < 100)
            {
                
                btnArray[n].Tag = n; // Tag of button
                btnArray[n].Width = 40; // Width of button
                btnArray[n].Height = 40; // Height of button
                if (n % 10 == 0) // Location of every next line of buttons
                {   
                    xPos = 0;
                    yPos = n * 4;
                }
              
                // Location of button:
                btnArray[n].Left = xPos;
                btnArray[n].Top = yPos;
                // Add buttons to a Panel:
                playerBoard.Controls.Add(btnArray[n]); // panel hold the Buttons
                xPos = xPos + btnArray[n].Width; 
                btnArray[n].Text = btnArray[n].Tag.ToString();


                // the Event of click Button
                btnArray[n].Click += new System.EventHandler(ClickButton);
                n++;
            }
            //place ships
            for(int i=0;i< userShips.getShips().Length; i++)
            {
                for (int j = 0; j < userShips.getShips()[i].getSquares().Length; j++)
                {
                    btnArray[userShips.getShips()[i].getSquares()[j]].BackColor = Color.Red;
                }
            }
        }


        private void AddButtonsforComputer()
        {
            int xPos = 0;
            int yPos = 0;
            // Declare and assign number of buttons = 26
            System.Windows.Forms.Button[] btnArray = new System.Windows.Forms.Button[100];
            // Create (26) Buttons:
            for (int i = 0; i < 100; i++)
            {
                // Initialize one variable
                btnArray[i] = new System.Windows.Forms.Button();
            }
            int n = 0;

            while (n < 100)
            {

                btnArray[n].Tag = n; // Tag of button
                btnArray[n].Width = 40; // Width of button
                btnArray[n].Height = 40; // Height of button
                if (n % 10 == 0) // Location of every next line of buttons
                {
                    xPos = 0;
                    yPos = n * 4;
                }

                // Location of button:
                btnArray[n].Left = xPos;
                btnArray[n].Top = yPos;
                // Add buttons to a Panel:
                computerBoard.Controls.Add(btnArray[n]); // panel hold the Buttons
                xPos = xPos + btnArray[n].Width;
                btnArray[n].Text = btnArray[n].Tag.ToString();


                // the Event of click Button
                btnArray[n].Click += new System.EventHandler(ClickButton);
                n++;
            }
            //place ships
            for (int i = 0; i < computerShips.getShips().Length; i++)
            {
                for (int j = 0; j < computerShips.getShips()[i].getSquares().Length; j++)
                {
                    btnArray[computerShips.getShips()[i].getSquares()[j]].BackColor = Color.Red;
                }
            }
        }

        // Result of (Click Button) event, get the text of button
        public void ClickButton(Object sender, System.EventArgs e)
        {
            Button btn = (Button)sender;
            btn.Enabled = false;
            bool hitWasSuccesful = false;
           
            //MessageBox.Show("You clicked character [" + btn.Tag + "]");
            for (int i = 0; i < computerShips.getShips().Length; i++)
            {
                for (int j = 0; j < computerShips.getShips()[i].getSquares().Length; j++)
                {
                    if(String.Equals(btn.Tag, computerShips.getShips()[i].getSquares()[j]))
                    {
                        btn.Text = "X";
                        hitWasSuccesful = true;
                        computerShips.getShips()[i].increaseSuccesfulHits();
                        if (computerShips.getShips()[i].getSinked())
                        {
                            computerShips.increaseSinkedShipsNum();
                            MessageBox.Show("You Sinked " + computerShips.getShips()[i].getName() + "!");
                            if (!computerShips.isThereAnyLeft())
                            {
                                MessageBox.Show("You Won !!");
                            }
                        }
                    }
                }
                if (!hitWasSuccesful)
                {
                    btn.Text = "-";
                }
            }
        }






    }
}
