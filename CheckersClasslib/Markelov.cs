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
        if (!MoveChance())
            return false;

        var difX = move.Xto - move.Xfrom;
        var difY = move.Yto - move.Yfrom;

        var len = Math.Max(Math.Abs(difX), Math.Abs(difY));
        if (len == 0)
            return false;
        var stepX = difX / len;
        var stepY = difY / len;

        var count = 0;
        for (int i = 1; i <= len - 1; i++)
        {
            if (board.figures[move.Xfrom + i * stepX, move.Yfrom + i * stepY] != null)
                count++;
        }
        if (count == 0)
            return false;

        if (board.figures[move.Xfrom + (len - 1) * stepX, move.Yfrom + (len - 1) * stepY] != null &&
            board.figures[move.Xfrom + (len - 1) * stepX, move.Yfrom + (len - 1) * stepY].Team == this.Team)
            return false;

        return board.figures[move.Xto, move.Yto] == null;
    }
    public override bool CanMove(Move move, Board board)
    {
        if (!MoveChance())
            return false;

        var difX = move.Xto - move.Xfrom;
        var difY = move.Yto - move.Yfrom;

        var len = Math.Max(Math.Abs(difX), Math.Abs(difY));
        if (len == 0)
            return false;
        var stepX = difX / len;
        var stepY = difY / len;

        for (int i = 1; i <= len; i++)
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
        return random.Next(0, 1) == 0;
    }

    public override void HandleInMovement(Move move, Board board)
    {

    }

    public override void HandleOutMovement(Move move, Board board)
    {

    }
}

