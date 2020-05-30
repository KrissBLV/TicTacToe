using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class Form1 : Form
    {
        bool xPlayerTurn = true;
        int turnCount = 0;

        public Form1()
        {
            InitializeComponent();
            InitializeGrid();
            InitializeCells();
        }

        private void InitializeGrid()
        {
            Grid.BackColor = Color.LightSkyBlue;
            Grid.CellBorderStyle = TableLayoutPanelCellBorderStyle.Inset;
        }

        private void RestartGame()
        {
            InitializeCells();
            turnCount = 0;
        }
        
        private void InitializeCells()
        {
            string labelName;
            for (int i = 1; i <= 9; i++)
            {
                labelName = "label" + i;
                Grid.Controls[labelName].Text = string.Empty;
                Grid.Controls[labelName].BackColor = Color.LightSkyBlue;
            }
        }

        private void Player_Click(object sender, EventArgs e)
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
            turnCount++;
            CheckForWin();
            CheckForDraw();
            xPlayerTurn = !xPlayerTurn;
        }

        private void CheckForWin()
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
                GameOver();
            }
        }

        private void WinnerCellsChangeColor()
        {
            if (label1.Text == label2.Text && label1.Text == label3.Text && label1.Text != "")
            {
                ChangeCellColors(label1, label2, label3, Color.Green);
            }
            else if (label4.Text == label5.Text && label4.Text == label6.Text && label4.Text != "")
            {
                ChangeCellColors(label4, label5, label6, Color.Green);
            }
            else if (label7.Text == label8.Text && label7.Text == label9.Text && label7.Text != "")
            {
                ChangeCellColors(label7, label8, label9, Color.Green);
            }
            else if (label1.Text == label4.Text && label1.Text == label7.Text && label1.Text != "")
            {
                ChangeCellColors(label1, label4, label7, Color.Green);
            }
            else if (label2.Text == label5.Text && label2.Text == label8.Text && label2.Text != "")
            {
                ChangeCellColors(label2, label5, label8, Color.Green);
            }
            else if (label3.Text == label6.Text && label3.Text == label9.Text && label3.Text != "")
            {
                ChangeCellColors(label3, label6, label9, Color.Green);
            }
            else if (label1.Text == label5.Text && label1.Text == label9.Text && label1.Text != "")
            {
                ChangeCellColors(label1, label5, label9, Color.Green);
            }
            else if (label3.Text == label5.Text && label3.Text == label7.Text && label3.Text != "")
            {
                ChangeCellColors(label3, label5, label7, Color.Green);
            }

        }

        private void ChangeCellColors(Label firstLabel, Label secondLabel, Label thirdLabel, Color color)
        {
            firstLabel.BackColor = color;
            secondLabel.BackColor = color;
            thirdLabel.BackColor = color;
        }

        private void GameOver()
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
            WinnerCellsChangeColor();
            MessageBox.Show(winner + "wins!");
            RestartGame();
        }
        private void CheckForDraw()
        {
            if(turnCount == 9)
            {
                MessageBox.Show("Draw!");
                RestartGame();
            }
        }
    }
}
