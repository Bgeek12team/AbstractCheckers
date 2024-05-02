namespace CheckersClasslib;

public class AntiMarkMine : Mine
{
    public AntiMarkMine(Team color) : base(color) { }

    public override void HandleInMovement(Move move, Board board)
    {
        if (board.figures[move.Xto, move.Yto] is not Markelov)
            return;
        board.figures[move.Xto, move.Yto] = null;
    }

    public override void HandleOutMovement(Move move, Board board)
    {
        if (board.figures[move.Xfrom, move.Yfrom] is not Markelov)
            return;
        board.figures[move.Xfrom, move.Yfrom] = null;
    }
}
