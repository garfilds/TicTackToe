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
            for (int c = 1; c <= 9; c++) //LOL
            {
                labelName = "label" + c;
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
            if (xPlayerTurn)
            {
                label.Text = "X";
            }
            else 
            {
                label.Text = "O";
            }
            xPlayerTurn = !xPlayerTurn;
        }

    }
}
