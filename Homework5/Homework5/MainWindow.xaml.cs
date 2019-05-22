using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel;

namespace Homework5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string currentX_O = "O";//Ensures that "X" will be first when 1st button is pressed.

        //use string array to store X and O values
        int[,] ticTacArrayX = new int[3,3];
        int[,] ticTacArrayO = new int[3, 3];
        int intArrayRow;
        int intArrayCol;
        int sumCheck = 0; //int to check if there is a winner.  
        


        //Define method to check if there is a winner after each X | O is populated
        //the Xs and Os will have their own method for checking if there is a winner
        //arrays to be populated with 1 and if a whole row or column or diagnol sums to 3, then winner
        public bool CheckWinnerX(int[,] ticTacArrayX)
        {
            

            //check row totals
            for (int row = 0; row <= 2; row++) //check over rows
            {
                //variable to check sum of row or column.  get's reset to 0 for each outer iteration
                sumCheck = 0;//reset
                
                for (int col = 0; col <= 2; col++)
                {
                    sumCheck = sumCheck + ticTacArrayX[row, col];

                }

                //if find sum of 3 return
                if (sumCheck == 3) //signifies winner on rows!
                {
                    
                    DeclareWinner(true, "X");
                    return true;  //make method void?  boolean return no longer needed?  
                }

            }

            //now check column totals
            for (int col = 0; col <= 2; col++)
            {
                sumCheck = 0;

                for (int row = 0; row <= 2; row++)
                {
                    sumCheck = sumCheck + ticTacArrayX[row, col];
                }
                if (sumCheck == 3) //signifies winner on column
                {
                    
                    DeclareWinner(true, "X");
                    return true;
                }
            }

            //now check diagonal starting at 0,0
            sumCheck = 0;
            for (int col = 0; col <= 2; col++)
            {
                
                sumCheck = sumCheck + ticTacArrayX[col, col];
            }
            if (sumCheck == 3)
            {
                
                DeclareWinner(true, "X");
                return true;
            }

            //now check diagonal starting at 0,2
            sumCheck = 0;
            for (int col = 2, row = 0; col >= 0; col--, row++)
            {
                sumCheck = sumCheck + ticTacArrayX[col, row];
            }
            if (sumCheck == 3)
            {
                
                DeclareWinner(true, "X");
                return true;
            }

            return false; //X has not won yet
        }

        public bool CheckWinnerO(int[,] ticTacArrayO)
        {
            
            //There will be a winner when a row or column or diagonal are all X or O.  ***this is 3x3, so check 3 columns, 3 rows, 2 diagonals
            

            //check row totals
            for (int row = 0; row <= 2; row++) //check over rows
            {
                //variable to check sum of row or column.  get's reset to 0 for each outer iteration
                sumCheck = 0;//reset

                for (int col = 0; col <= 2; col++)
                {
                    sumCheck = sumCheck + ticTacArrayO[row, col];

                }

                //if find sum of 3 return
                if (sumCheck == 3) //signifies winner on rows!
                {
                    
                    DeclareWinner(true, "O");
                    return true;
                }

            }

            //now check column totals
            for (int col = 0; col <= 2; col++)
            {
                sumCheck = 0;

                for (int row = 0; row <= 2; row++)
                {
                    sumCheck = sumCheck + ticTacArrayO[row, col];
                }
                if (sumCheck == 3) //signifies winner on column
                {
                    
                    DeclareWinner(true, "O");
                    return true;
                }
            }

            //now check diagonal starting at 0,0
            sumCheck = 0;
            for (int col = 0; col <= 2; col++)
            {

                sumCheck = sumCheck + ticTacArrayO[col, col];
            }
            if (sumCheck == 3)
            {
                
                DeclareWinner(true, "O");
                return true;
            }
    
            //now check diagonal starting at 0,2
            sumCheck = 0;
            for (int col = 2, row = 0; col >= 0; col--, row++)
            {
                sumCheck = sumCheck + ticTacArrayO[col, row];
            }
            if (sumCheck == 3)
            {
                
                DeclareWinner(true, "O");
                return true;
            }

            return false; //O has not won yet
        }

        //Declare the winner
        public void DeclareWinner(bool winnerFlag, string winner)
        {
            if (winnerFlag == true)
            {
                uxTurn.Text = winner + " is the winner!";

                //disable further development
                uxGrid.IsEnabled = false;


            }
        }
        

        public MainWindow()
        {
            InitializeComponent();
            uxTurn.Text = "X's turn...";



        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (currentX_O == "O")
            {
                currentX_O = "X";
                uxTurn.Text = "O's turn...";

            }
            else
            {
                currentX_O = "O";
                uxTurn.Text = "X's turn...";
                    
            }

            Button currentButton = (sender as Button);
           
            
            //populate UI with X or O
            currentButton.Content = currentX_O;

            //Get coordinates of current cell
            intArrayRow = Convert.ToInt16(currentButton.Tag.ToString()[0].ToString()); //left most value of Tag
            intArrayCol = Convert.ToInt16(currentButton.Tag.ToString()[2].ToString()); //right most value of Tag
            

            //Populate Array with 1 for any X or O and check for winner

            if(currentX_O == "X")
            {
               

                ticTacArrayX[intArrayRow, intArrayCol] = 1;
                CheckWinnerX(ticTacArrayX);
                

            }
            else
            {
                ticTacArrayO[intArrayRow, intArrayCol] = 1;
                CheckWinnerO(ticTacArrayO);

            }
            

            
            //string rowCol = currentButton.Tag.ToString();
            
            //MessageBox.Show(rowCol);
            //MessageBox.Show(currentButton.Content.ToString());
        }

        private void uxExit_Click(object sender, RoutedEventArgs e)
        {
            
            Close();
        }

        private void uxNewGame_Click(object sender, RoutedEventArgs e)
        {
            

            foreach (Button btn in uxGrid.Children.OfType<Button>())
            {
                btn.Content = "";
                
            }

            //reset array to track user input
            ticTacArrayX = new int[3, 3];
            ticTacArrayO = new int[3, 3];

            //enable UI grid
            uxGrid.IsEnabled = true;

            
        }
    }
}
