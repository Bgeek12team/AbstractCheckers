using CheckersClasslib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Forms
{
    public partial class menu : Form
    {
        mainBoard board;
        public menu()
        {
            InitializeComponent();
        }

        private void b_startStandartGame_Click(object sender, EventArgs e)
        {
            Cell[,] cells = new Cell[10, 10];
            Figure[,] figures = new Figure[10, 10];
            for (int i = 0; i < cells.GetLength(0); i++)
            {
                for (int j = 0; j < cells.GetLength(1); j++)
                {
                    cells[i, j] = new DefaultCell(((i + j) % 2) != 0 ? Team.Black : Team.White);
                }
            }
            for (int i = 0;i < figures.GetLength(0); i++)
            {
                for (int j = 0; j < figures.GetLength(1); j++)
                {
                    figures[i, j] = new DefaultFigure(Team.White);
                }
            }
            board = new mainBoard(cells, figures);
            board.Show();
        }
    }
}
