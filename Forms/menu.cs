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

namespace Forms;

public partial class Menu : Form
{
    MainBoard board;
    public Menu()
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

        board = new MainBoard(TransposeArray(cells), TransposeArray(figures));
        board.Show();
    }

    Figure GenWhiteFigure() => new DefaultFigure(Team.White);
    Figure GenBlackFigure() => new DefaultFigure(Team.Black);
    Team getTeam(int x, int y) { return ((x + y) % 2) != 0 ? Team.Black : Team.White; }

    private void button2_Click(object sender, EventArgs e)
    {
        Dictionary<(int x, int y), Cell> mapNotDefaultCells = new Dictionary<(int x, int y), Cell>()
        {
            {(3, 6), new AntiMarkMine(getTeam(3,6)) },
            {(3, 4), new Trampoline(getTeam(3,4)) },
            {(4, 5), new Mine(getTeam(4,5)) },
            {(4, 1), new TrenbolonCell(getTeam(5,1)) },
            {(3, 2), new Catapult(getTeam(3,2)) },
            {(2, 4), new Tornado(getTeam(2,4)) },
        };
        Cell[,] cells = new Cell[8, 8];

        Figure[,] figures = {
            { null, GenBlackFigure(), null, GenBlackFigure(), null, GenBlackFigure(), null, GenBlackFigure()},
            { new Queen(Team.Black), null, GenBlackFigure(), null, new StraightFigure(Team.Black), null, GenBlackFigure(), null},
            { null, GenBlackFigure(), null, GenBlackFigure(), null, GenBlackFigure(), null, new Markelov(Team.Black)},
            { null, null, null, null, null, null, null, null},
            { null, null, null, null, null, null, null, null},
            { new Queen(Team.White), null, new BombFigure(Team.White), null, new Markelov(Team.White), null, GenWhiteFigure(), null},
            { null, GenWhiteFigure(), null, GenWhiteFigure(), null, GenWhiteFigure(), null, GenWhiteFigure()},
            { GenWhiteFigure(), null, GenWhiteFigure(), null, GenWhiteFigure(), null, GenWhiteFigure(), null},
                            };


        for (int i = 0; i < cells.GetLength(0); i++)
        {
            for (int j = 0; j < cells.GetLength(1); j++)
            {
                if (mapNotDefaultCells.ContainsKey((i, j)))
                {
                    cells[i, j] = mapNotDefaultCells[(i, j)];
                    continue;
                }
                cells[i, j] = new DefaultCell(getTeam(i, j));
            }
        }

        board = new MainBoard(TransposeArray(cells), TransposeArray(figures));

        board.Show();
    }

    private void button3_Click(object sender, EventArgs e)
    {
        var r = new Random();
        int size = r.Next(7, 9);
        var cells = new Cell[size, size];
        var figures = new Figure[size, size];
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                var cellTeam = ((i + j) % 2) != 0 ? Team.Black : Team.White;
                cells[i, j] = GenerateRandomCell(cellTeam);
                figures[i, j] = GenerateRandomFigure((Team)r.Next(0, 2));
            }
        }

        board = new MainBoard(TransposeArray(cells), TransposeArray(figures));

        board.Show();
    }

    Figure GenerateRandomFigure(Team team)
    {
        var r = new Random();
        var number = r.Next(0, 11);
        if (number < 5)
            return null;
        if (number < 6)
            return new StraightFigure(team);
        if (number < 7)
            return new Queen(team);
        if (number < 8)
            return new Markelov(team);
        if (number < 9)
            return new BombFigure(team);
        else
            return new DefaultFigure(team);
    }

    Cell GenerateRandomCell(Team team)
    {
        var r = new Random();
        var number = r.Next(0, 9);
        if (number < 1)
            return new AntiMarkMine(team);
        if (number < 2)
            return new TrenbolonCell(team);
        if (number < 3)
            return new Mine(team);
        if (number < 4)
            return new Trampoline(team);
        if (number < 5)
            return new Catapult(team);
        if (number < 6)
            return new Mine(team);
        if (number < 7)
            return new Tornado(team);
        else
            return new DefaultCell(team);
    }

    private void help_Click(object sender, EventArgs e)
    {
        HelpForm helpForm = new HelpForm();
        helpForm.ShowDialog();
    }

    static T[,] TransposeArray<T>(T[,] array)
    {
        int rows = array.GetLength(0);
        int columns = array.GetLength(1);
        T[,] transposed = new T[columns, rows];

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                transposed[j, i] = array[i, j];
            }
        }

        return transposed;
    }
}
