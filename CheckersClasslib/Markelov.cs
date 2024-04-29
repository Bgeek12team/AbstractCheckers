using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckersClasslib;

public class Markelov(Team team) : Figure(team)
{
    public override bool CanEat(Move move, Board board)
    {
        if (MoveChance())
            return false;
        var difX = move.Xto - move.Xfrom;
        var difY = move.Yto - move.Yfrom;

        var len = Math.Max(Math.Abs(difX), Math.Abs(difY));
        var stepX = difX / len;
        var stepY = difY / len;

        for (int i = 1; i < len; i++)
        {
            if (board.figures[move.Xfrom + i * stepX, move.Yfrom + i * stepY] != null)
                return false;
        }

        if (board.figures[move.Xto, move.Yto] != null &&
            board.figures[move.Xto, move.Yto].Team != this.Team)
            return true;

        return board.figures[move.Xto, move.Yto] == null;
    }
    public override bool CanMove(Move move, Board board)
    {
        if (MoveChance())
            return false;

        var difX = move.Xto - move.Xfrom;
        var difY = move.Yto - move.Yfrom;

        var len = Math.Abs(difX);
        var stepX = difX / len;
        var stepY = difY / len;

        for (int i = 1; i < len; i++)
        {
            if (board.figures[move.Xfrom + i * stepX, move.Yfrom + i * stepY] != null)
                return false;
        }

        return true;
    }
    public override bool IsValidEating(Move move, Board board) => true;

    public override bool IsValidMovement(Move move, Board board) => true;

    private static bool MoveChance()
    {
        Random random = new Random();
        return random.Next(2) == 0;
    }
}

