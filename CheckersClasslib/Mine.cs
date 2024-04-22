namespace CheckersClasslib;

public class Mine : Cell
{
    public Mine(Team color) : base(color) { }

    public override void HandleInMovement(Move move, Board board)
    {
        var r = new Random();
        if (r.Next(0, 1) == 0)
            board.figures[move.Xto, move.Yto] = null;
    }

    public override void HandleOutMovement(Move move, Board board)
    {
        var r = new Random();
        if (r.Next(0, 1) == 0)
            board.figures[move.Xfrom, move.Yfrom] = null;
    }
}

public class AntiMarkMine : Mine
{
    public AntiMarkMine(Team color) : base(color) { }

    public override void HandleInMovement(Move move, Board board)
    {
        if (board.figures[move.Xto, move.Xfrom] is not Markelov)
            return;
        var r = new Random();
        if (r.Next(0, 1) == 0)
            board.figures[move.Xto, move.Yto] = null;
    }

    public override void HandleOutMovement(Move move, Board board)
    {
        if (board.figures[move.Xto, move.Xfrom] is not Markelov)
            return;
        var r = new Random();
        if (r.Next(0, 1) == 0)
            board.figures[move.Xfrom, move.Yfrom] = null;
    }
}
