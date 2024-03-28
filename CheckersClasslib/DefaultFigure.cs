namespace CheckersClasslib;

public class DefaultFigure(Team team) : Figure(team)
{
    public override bool CanEat(Move move, Board board) =>
        board.figures[(move.Xfrom + move.Xto) / 2, (move.Yfrom + move.Yto) / 2] != null &&
        board.figures[(move.Xfrom + move.Xto) / 2, (move.Yfrom + move.Yto) / 2].Team != this.Team &&
        board.figures[move.Xto, move.Yto] == null;

    public override bool CanMove(Move move, Board board) =>
        board.figures[move.Xto, move.Yto] == null;

    public override bool IsValidEating(Move move) =>
        (move.Yto - move.Yfrom == 2) &&
        (Math.Abs(move.Xto - move.Yfrom) == 2);

    public override bool IsValidMovement(Move move) =>
        (move.Yto - move.Yfrom == 1) &&
        (Math.Abs(move.Xto - move.Yfrom) == 1);
}

public class Queen(Team team) : Figure(team)
{
    public override bool CanEat(Move move, Board board)
    {
        var difX = move.Xto - move.Xfrom;
        var difY = move.Yto - move.Yfrom;
        var startX = move.Xfrom;
        var startY = move.Yto;
        var len = Math.Abs(difX);
        var stepX = difX / len;
        var stepY = difY / len;
        if (len == 0)
            return false;
        for (int i = 1; i < len - 1; i++)
        {
            if (board.figures[startX + i * stepX, startY + i * stepY] != null)
                return false;
        }
        if (board.figures[startX + (len - 1) * stepX, startY + (len - 1) * stepY] != null &&
            board.figures[startX + (len - 1) * stepX, startY + (len - 1) * stepY].Team == this.Team)
            return false;

        return board.figures[move.Xto, move.Yfrom] == null;
    }

    public override bool CanMove(Move move, Board board)
    {
        var difX = move.Xto - move.Xfrom;
        var difY = move.Yto - move.Yfrom;
        var startX = move.Xfrom;
        var startY = move.Yto;
        var len = Math.Abs(difX);
        var stepX = difX / len;
        var stepY = difY / len;
        if (len == 0)
            return false;
        for(int i = 1; i <= len; i++)
        {
            if (board.figures[startX + i * stepX, startY += i * stepY] != null)
                return false;
        }
        return true;
    }

    public override bool IsValidEating(Move move) => 
        (Math.Abs(move.Yto - move.Yfrom)) == (Math.Abs(move.Xto - move.Yfrom));

    public override bool IsValidMovement(Move move) =>
        (Math.Abs(move.Yto - move.Yfrom)) == (Math.Abs(move.Xto - move.Yfrom) );
}