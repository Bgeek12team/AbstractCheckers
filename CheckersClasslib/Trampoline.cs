namespace CheckersClasslib;

public class Trampoline : Cell
{
    public Trampoline(Team color) : base(color) { }

    public override void HandleInMovement(Move move, Board board)
    {
        var xDifference = move.Xfrom - move.Xto;
        var yDifference = move.Yfrom - move.Yto;
        var newX = xDifference + move.Xto;
        var newY = yDifference + move.Yto;
        var xOutsideCells = newX >= board.board.GetLength(0) || newX < 0;
        var yOutsideCells = newY >= board.board.GetLength(0) || newY < 0;
        if (xOutsideCells || yOutsideCells) 
        {
            board.figures[move.Xto, move.Yto] = null;
            return;
        }
        board.figures[newX, newY] = board.figures[move.Xto, move.Yto];
        board.figures[move.Xto, move.Yto] = null;
    }

    public override void HandleOutMovement(Move move, Board board)
    {

    }
}


public class Catapult : Cell
{
    public Catapult(Team color) : base(color) { }

    public override void HandleInMovement(Move move, Board board)
    {
        var newX = move.Xto;
        var newY = move.Yto;
        while (newY < board.board.GetLength(0) && board.figures[newX, newY+1] == null)
        {
            newY++;
        }

        if (newY > move.Yto)
        {
            board.figures[newX, newY] = board.figures[move.Xto, move.Yto];
            board.figures[move.Xto, move.Yto] = null;
        }
    }

    public override void HandleOutMovement(Move move, Board board)
    {

    }
}

