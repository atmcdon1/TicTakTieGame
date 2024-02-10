/////////////////////////////////////   
/// 2/7/2024 Develped Gui TIc tack toe buttons 
/// 2/7/2024 Event handled buttons
/// 2/7/2024 Made grid of player 1 or 2
/// 2/7/2024 winCheck to see if the player got three in a row.
/// 2/7/2024 Reset event-handler developed resets everything.
/// 2/8/2024 took appart button click and make executBtn a seperate method
/// 2/8/2024 made tieCheck()
/// 2/8/2024 made pickRandomBtn() this plays as the computer when called
/// 2/8/2024 The buttons will become de-enabled when pressed.


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TikTakToe

{
    public partial class Form1 : Form
    {

        int playerTurn = 1;
        
        int[,] grid = new int[3, 3];

        int playCounts = 0;

        int playTiesAmount = 0;

        int player1Wins = 0;
        int player2Wins = 0;

        string player1name = "player 1";

        public Form1()
        {
            InitializeComponent();
        }

        private void Grid_Paint(object sender, PaintEventArgs e)
        {

        }

        private void startBtn_Click(object sender, EventArgs e)
        {
            player1name = playerInputName.Text;

            Player1Label.Text = player1name;

            player1Wins = 0;
            player2Wins = 0;
            P1WinsLabel.Text = player1Wins.ToString();
            P2WinsLabel.Text = player2Wins.ToString();

            restartBtn_Click(sender, e);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void gridBtn_Click(object sender, EventArgs e)
        {
            //when clicked make a X or a O depending if player turn 1 or zero
            //playerTurn switch opposite to zero.
            // 
            Button btn = (Button)sender;


            int row = Grid.GetRow(btn);
            int col = Grid.GetColumn(btn);

            executBtn(btn, row, col);

            //This plays the computer to turn off just Comment out
            if (playerTurn == 2)
            {
                pickRandomBtn();
            }
            
            // gridArray [[1,2,3],
            //            [4,5,6],
            //            [7,8,9]]



            //shows where it is in the array
            
            //ShowGrid();
            void ShowGrid()
            {
                string gridString = "gridArray [\n";
                for (int i = 0; i < grid.GetLength(0); i++) // Iterate over rows
                {
                    gridString += "            [";
                    for (int j = 0; j < grid.GetLength(1); j++) // Iterate over columns
                    {
                        gridString += grid[i, j].ToString();
                        if (j < grid.GetLength(1) - 1)
                        {
                            gridString += ", ";
                        }
                    }
                    gridString += "]" + (i < grid.GetLength(0) - 1 ? ",\n" : "\n");
                }
                gridString += "          ]";

                MessageBox.Show(gridString, "Grid State"); // Display the grid in a message box
            }
        }


        //This method will: Check to see whos turn it is and update the button text 
        //and check if there is a tie. It will assign the player a 1 or 2 in grid array
        //                  
        //Paras: btn, row of button cell, col of button cell
        private void executBtn(Button btn ,int row, int col)
        {

            if (playerTurn == 0)
            {
                playerTurn = 1;
            }
            switch (playerTurn)
            {
                case 1:
                    btn.Text = "X";
                    playCounts++;

                    grid[row, col] = playerTurn;
                    btn.Enabled = false;
                    if (true == winCheck(playerTurn))
                    { displayBox.Text = $"Good Job {player1name} Won!";
                        player1Wins++;
                        P1WinsLabel.Text = player1Wins.ToString();
                        playerTurn = 0;
                        greyButtonsOut();
                        
                        break;
                    }

                    if (tieCheck() == true)
                    {
                        displayBox.Text = $"The Game was Tied";
                        playerTurn = 0;
                        break;
                    }

                    playerTurn = 2;


                    break;

                case 2:
                    btn.Text = "O";
                    playCounts++;
                    grid[row, col] = playerTurn;
                    btn.Enabled = false;
                    
                    if (true == winCheck(playerTurn))
                    { /*displayBox.Text = $"Player {playerTurn} Won!";*/
                        displayBox.Text = $"The Computer Won!";
                        player2Wins++;
                        P2WinsLabel.Text = player2Wins.ToString();
                        playerTurn = 0;
                        greyButtonsOut();
                        break;
                    }
                    if (tieCheck() == true)
                    {
                        displayBox.Text = $"The Game was Tied";
                        playerTurn = 0;
                        break;
                    }

                    playerTurn = 1;
                    displayBox.Text = $"{player1name}'s Turn";
                    break;

            }
        }


        // 
        // 
        // Pick a random btn on the board. Acts as the computer.
        // uses a switch to pick between 1-9 of the buttons then
        // pull the row and column data and checks so see if the 
        // spot has been taken.
        public void pickRandomBtn()
        {
            bool foundEmptyBtn = false;
            while (foundEmptyBtn ==false)
            {
                //pick a number between 1 - 9 
                Random random = new Random();
                int randomBtn = random.Next(1, 9);
                
                //checks grid if spot has been taken.
                switch (randomBtn)
                {
                    case 1: 
                        int row = Grid.GetRow(gridBtn1);
                        int col = Grid.GetColumn(gridBtn1);
                        if (grid[row,col] == 0)
                        {
                            grid[row,col] = 2;
                            executBtn(gridBtn1, row, col);

                            foundEmptyBtn = true;
                        }
                        break;

                    case 2:
                        row = Grid.GetRow(gridBtn2);
                        col = Grid.GetColumn(gridBtn2);
                        if (grid[row, col] == 0)
                        {
                            grid[row, col] = 2;
                            executBtn(gridBtn2, row, col);

                            foundEmptyBtn = true;
                        }
                        break;
                    case 3:
                        row = Grid.GetRow(gridBtn3);
                        col = Grid.GetColumn(gridBtn3);
                        if (grid[row, col] == 0)
                        {
                            grid[row, col] = 2;
                            executBtn(gridBtn3, row, col);

                            foundEmptyBtn = true;
                        }
                        break;
                    case 4:
                        row = Grid.GetRow(gridBtn4);
                        col = Grid.GetColumn(gridBtn4);
                        if (grid[row, col] == 0)
                        {
                            grid[row, col] = 2;
                            executBtn(gridBtn4, row, col);

                            foundEmptyBtn = true;
                        }
                        break;
                    case 5:
                        row = Grid.GetRow(gridBtn5);
                        col = Grid.GetColumn(gridBtn5);
                        if (grid[row, col] == 0)
                        {
                            grid[row, col] = 2;
                            executBtn(gridBtn5, row, col);

                            foundEmptyBtn = true;
                        }
                        break;
                    case 6:
                        row = Grid.GetRow(gridBtn6);
                        col = Grid.GetColumn(gridBtn6);
                        if (grid[row, col] == 0)
                        {
                            grid[row, col] = 2;
                            executBtn(gridBtn6, row, col);

                            foundEmptyBtn = true;
                        }
                        break;
                    case 7:
                        row = Grid.GetRow(gridBtn7);
                        col = Grid.GetColumn(gridBtn7);
                        if (grid[row, col] == 0)
                        {
                            grid[row, col] = 2;
                            executBtn(gridBtn7, row, col);

                            foundEmptyBtn = true;
                        }
                        break;
                    case 8:
                        row = Grid.GetRow(gridBtn8);
                        col = Grid.GetColumn(gridBtn8);
                        if (grid[row, col] == 0)
                        {
                            grid[row, col] = 2;
                            executBtn(gridBtn8, row, col);

                            foundEmptyBtn = true;
                        }
                        break;
                    case 9:
                        row = Grid.GetRow(gridBtn9);
                        col = Grid.GetColumn(gridBtn9);
                        if (grid[row, col] == 0)
                        {
                            grid[row, col] = 2;
                            executBtn(gridBtn9, row, col);

                            foundEmptyBtn = true;
                        }
                        break;
                     default: 
                        displayBox.Text = "There is an error in the pickRandomNum() Switch";
                        break;
                }
            }
                

            
            
        }




        //This method will check how many plays there have been
        //if there is 9 turns played then it will be a tie.
        private bool tieCheck()
        {
            if (playCounts >= 9 && winCheck(playerTurn) == false)
            {
                playTiesAmount++;
                PlayerTies.Text = playTiesAmount.ToString();
                return true;
                
            }
            else
            {
                return false;
            }
        }


            //this method will check if there is a THREE in a row.
        private bool winCheck(int playerTurn)
        {
            //grid[ cols rows,]
            //----------- horizontal wins --------------
            if (grid[0, 0] == playerTurn && grid[0, 1] == playerTurn && grid[0, 2] == playerTurn)
            {
                return true;
            }
            if (grid[1, 0] == playerTurn && grid[1, 1] == playerTurn && grid[1, 2] == playerTurn)
            {
                return true;
            }
            if (grid[2, 0] == playerTurn && grid[2, 1] == playerTurn && grid[2, 2] == playerTurn)
            {
                return true;
            }
            //----------- Vertical wins --------------
            if (grid[0, 0] == playerTurn && grid[1, 0] == playerTurn && grid[2, 0] == playerTurn)
            {
                return true;
            }
            if (grid[0, 1] == playerTurn && grid[1, 1] == playerTurn && grid[2, 1] == playerTurn)
            {
                return true;
            }
            if (grid[0, 2] == playerTurn && grid[1, 2] == playerTurn && grid[2, 2] == playerTurn)
            {
                return true;
            }
            //----------- diagonal --------------
            if (grid[0, 0] == playerTurn && grid[1, 1] == playerTurn && grid[2, 2] == playerTurn)
            {
                return true;
            }
            if (grid[0, 2] == playerTurn && grid[1, 1] == playerTurn && grid[2, 0] == playerTurn)
            {
                return true;
            }

            else
                
            return false;
            
        }

        //This resets teh grid to all zeros
        //resets all the grid Buttons text
        //restarts the first player as X
        private void restartBtn_Click(object sender, EventArgs e)
        {

            greyButtonsOut();
            grid = new int[3, 3];
            gridBtn1.Text = "";
            gridBtn2.Text = "";
            gridBtn3.Text = "";
            gridBtn4.Text = "";
            gridBtn5.Text = "";
            gridBtn6.Text = "";
            gridBtn7.Text = "";
            gridBtn8.Text = "";
            gridBtn9.Text = "";
            playerTurn = 1;
            playCounts = 0;
        }

        private void greyButtonsOut()
        {
            gridBtn1.Enabled = true;
            gridBtn2.Enabled = true;
            gridBtn3.Enabled = true;
            gridBtn4.Enabled = true;
            gridBtn5.Enabled = true;
            gridBtn6.Enabled = true;
            gridBtn7.Enabled = true;
            gridBtn8.Enabled = true;
            gridBtn9.Enabled = true;
        }


        private void label6_Click(object sender, EventArgs e)
        {

        }
    }


}
