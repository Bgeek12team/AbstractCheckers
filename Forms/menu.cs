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
            Cell[,] cells = new Cell[8, 8];
            Figure[,] figures = {
                { null, GenBlackFigure(), null, GenBlackFigure(), null, GenBlackFigure(), null, GenBlackFigure()},
                { GenBlackFigure(), null, GenBlackFigure(), null, GenBlackFigure(), null, GenBlackFigure(), null},
                { null, GenBlackFigure(), null, GenBlackFigure(), null, GenBlackFigure(), null, GenBlackFigure()},
                { null, null, null, null, null, null, null, null},
                { null, null, null, null, null, null, null, null},
                { GenWhiteFigure(), null, GenWhiteFigure(), null, GenWhiteFigure(), null, GenWhiteFigure(), null},
                { null, GenWhiteFigure(), null, GenWhiteFigure(), null, GenWhiteFigure(), null, GenWhiteFigure()},
                { GenWhiteFigure(), null, GenWhiteFigure(), null, GenWhiteFigure(), null, GenWhiteFigure(), null},
                                };
            for (int i = 0; i < cells.GetLength(0); i++)
            {
                for (int j = 0; j < cells.GetLength(1); j++)
                {
                    cells[i, j] = new DefaultCell(((i + j) % 2) != 0 ? Team.Black : Team.White);
                }
            }

            board = new mainBoard(cells, figures);
            board.Show();
        }

        Figure GenWhiteFigure() => new DefaultFigure(Team.White);
        Figure GenBlackFigure() => new DefaultFigure(Team.Black);

        private void button2_Click(object sender, EventArgs e)
        {
            Cell[,] cells = new Cell[8, 8];
            Figure[,] figures = {
                { null, GenBlackFigure(), null, GenBlackFigure(), null, GenBlackFigure(), null, new Markelov(Team.Black)},
                { new Queen(Team.Black), null, GenBlackFigure(), null, GenBlackFigure(), null, GenBlackFigure(), null},
                { null, GenBlackFigure(), null, GenBlackFigure(), null, GenBlackFigure(), null, GenBlackFigure()},
                { null, null, null, null, null, null, null, null},
                { null, null, null, null, null, null, null, null},
                { new Queen(Team.White), null, GenWhiteFigure(), null, GenWhiteFigure(), null, GenWhiteFigure(), null},
                { null, GenWhiteFigure(), null, GenWhiteFigure(), null, GenWhiteFigure(), null, GenWhiteFigure()},
                { GenWhiteFigure(), null, GenWhiteFigure(), null, GenWhiteFigure(), null, new Markelov(Team.White), null},
                                };
            for (int i = 0; i < cells.GetLength(0); i++)
            {
                for (int j = 0; j < cells.GetLength(1); j++)
                {
                    cells[i, j] = new DefaultCell(((i + j) % 2) != 0 ? Team.Black : Team.White);
                }
            }

            board = new mainBoard(cells, figures);

            board.Show();
        }
    }
}
