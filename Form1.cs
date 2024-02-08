/////////////////////////////////////   
/// 2/7/2024 Develped Gui TIc tack toe buttons 
/// 2/7/2024 Event handled buttons
/// 2/7/2024 Made grid of player 1 or 2
/// 2/7/2024 winCheck to see if the player got three in a row.
/// 2/7/2024 Reset event-handler developed resets everything.
/// 2/8/2024


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gane
{
    public partial class Form1 : Form
    {

        int playerTurn = 1;
        
        int[,] grid = new int[3, 3];

        public Form1()
        {
            InitializeComponent();
        }

        private void Grid_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

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

            switch (playerTurn) 
            {
                case 1:
                    btn.Text = "X";
                    grid[row, col] = playerTurn;
                    if (true == winCheck(playerTurn))
                    { displayBox.Text = $"Player {playerTurn} Won!"; }

                    playerTurn = 2;

                    break;

                case 2:
                    btn.Text = "O";
                    grid[row, col] = playerTurn;
                    if (true == winCheck(playerTurn))
                    { displayBox.Text = $"Player {playerTurn} Won!"; }

                    playerTurn = 1;
                    break;
            }
            // gridArray [[1,2,3],
            //            [4,5,6],
            //            [7,8,9]]
            //get the cell row and col in the grid
            //put them in array
            ///asdsadas
            
            
            

            //shows where it is in the array
            //MessageBox.Show(String.Join(" ", grid.Cast<int>()));
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
            playerTurn = 2;
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }


}
