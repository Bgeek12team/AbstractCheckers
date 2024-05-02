using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckersClasslib;

public class Tornado : Cell
{
    public Tornado(Team color) : base(color) { }

    public override void HandleInMovement(Move move, Board board)
    {
        TransposeArray(board.figures);
        TransposeArray(board.board);
    }

    public override void HandleOutMovement(Move move, Board board)
    {

    }

    static void TransposeArray<T>(T[,] array)
    {
        int rows = array.GetLength(0);
        int columns = array.GetLength(1);

        for (int i = 0; i < rows; i++)
        {
            for (int j = i; j < columns; j++)
            {
                var t = array[i, j];
                array[i, j] = array[j, i];
                array[j, i] = t;
            }
        }
    }
}
