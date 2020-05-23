using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TickTackToe
{
    public partial class Form1 : Form
    {
        bool xPlayerTurn = true;
        bool crashed = false;
        int turnCount = 0;
        public Form1()
        {
            InitializeComponent();
            InitializeCells();
            InitializeGrid();
        }

        private void InitializeCells()
        {
            this.BackColor = Color.LightGray;
            string labelName;
            for (int i = 1; i <= 9; i++)
            {
                labelName = "label" + i;
                Grid.Controls[labelName].Text = string.Empty;
            }
        }
        private void InitializeGrid()
        {
            Grid.BackColor = Color.LightGray;
            Grid.CellBorderStyle = TableLayoutPanelCellBorderStyle.InsetDouble;
        }

        private void Player_click(object sender, EventArgs e)
        {
            Label label = (Label)sender;

            if (label.Text != string.Empty)
            {
                return;
            }

            if (xPlayerTurn)
            {
                label.Text = "X";
            }
            else
            {
                label.Text = "O";
            }
            CheckForWin();
            xPlayerTurn = !xPlayerTurn;

        }


        private void CheckForWin()
        {
            try
            {
                if (
                    (label1.Text == label2.Text && label2.Text == label3.Text && label1.Text != string.Empty) ||
                    (label4.Text == label5.Text && label5.Text == label6.Text && label4.Text != string.Empty) ||
                    (label7.Text == label8.Text && label8.Text == label9.Text && label7.Text != string.Empty) ||
                    (label1.Text == label4.Text && label4.Text == label7.Text && label1.Text != string.Empty) ||
                    (label2.Text == label5.Text && label5.Text == label8.Text && label2.Text != string.Empty) ||
                    (label3.Text == label6.Text && label6.Text == label9.Text && label3.Text != string.Empty) ||
                    (label1.Text == label5.Text && label5.Text == label9.Text && label1.Text != string.Empty) ||
                    (label3.Text == label5.Text && label5.Text == label7.Text && label3.Text != string.Empty)
                )
                {
                    gameOver();
                }
            }
            catch
            {
                
                crashed = true;
            }
        }

        private void CheckForDraw()
        {
            if (turnCount == 9)
            {
                MessageBox.Show("Draw!");
                turnCount = 0;
                InitializeCells();
            }
        }

        private void gameOver()
        {
            string winner;
            if (xPlayerTurn)
            {
                winner = "X";
            }
            else
            {
                winner = "O";
            }
            if (crashed)
            {
                gameOver();
                MessageBox.Show("Crashed");
                Application.Exit();
            }

            MessageBox.Show(winner + " Wins!");
            turnCount++;
            CheckForDraw();
            RestartGame();


        }
        private void RestartGame() 
        {
            xPlayerTurn = true;
             crashed = false;
             turnCount = 0;

        }


    }
    
}
