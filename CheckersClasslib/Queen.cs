namespace CheckersClasslib;

public class Queen(Team team) : Figure(team)
{
    public override bool CanEat(Move move, Board board)
    {
        var difX = move.Xto - move.Xfrom;
        var difY = move.Yto - move.Yfrom;
        var startX = move.Xfrom;
        var startY = move.Yfrom;
        var len = Math.Abs(difX);
        if (len == 0)
            return false;
        var stepX = difX / len;
        var stepY = difY / len;
        var count = 0;
        for (int i = 1; i <= len - 1; i++)
        {
            if (board.figures[startX + i * stepX, startY + i * stepY] != null)
                 count++;
        }
        if (count > 1 || count == 0)
            return false;
        if (board.figures[startX + (len - 1) * stepX, startY + (len - 1) * stepY] != null &&
            board.figures[startX + (len - 1) * stepX, startY + (len - 1) * stepY].Team == this.Team)
            return false;

        return board.figures[move.Xto, move.Yto] == null;
    }

    public override bool CanMove(Move move, Board board)
    {
        var difX = move.Xto - move.Xfrom;
        var difY = move.Yto - move.Yfrom;
        var startX = move.Xfrom;
        var startY = move.Yfrom;
        var len = Math.Abs(difX);
        if (len == 0)
            return false;
        var stepX = difX / len;
        var stepY = difY / len;
        for(int i = 1; i <= len; i++)
        {
            if (board.figures[startX + i * stepX, startY + i * stepY] != null)
                return false;
        }
        return true;
    }

    public override bool IsValidEating(Move move, Board board) => 
        (Math.Abs(move.Yto - move.Yfrom)) == (Math.Abs(move.Xto - move.Xfrom));

    public override bool IsValidMovement(Move move, Board board) =>
        (Math.Abs(move.Yto - move.Yfrom)) == (Math.Abs(move.Xto - move.Xfrom) );
}