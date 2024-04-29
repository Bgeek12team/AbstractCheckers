namespace CheckersClasslib;

public class Catapult : Cell
{
    public Catapult(Team color) : base(color) { }

    public override void HandleInMovement(Move move, Board board)
    {
        var newX = move.Xto;
        var newY = move.Yto;
        if (this.Team == Team.Black)
        {
            while (newY + 1 < board.board.GetLength(0) && board.figures[newX, newY + 1] == null)
            {
                newY++;
            }

            if (newY > move.Yto)
            {
                board.figures[newX, newY] = board.figures[move.Xto, move.Yto];
                board.figures[move.Xto, move.Yto] = null;
            }
        }
        else
        {
            while (newY - 1> 0 && board.figures[newX, newY - 1] == null)
            {
                newY--;
            }

            if (newY < move.Yto)
            {
                board.figures[newX, newY] = board.figures[move.Xto, move.Yto];
                board.figures[move.Xto, move.Yto] = null;
            }
        }
    }

    public override void HandleOutMovement(Move move, Board board)
    {

    }
}

