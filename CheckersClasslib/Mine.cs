namespace CheckersClasslib;

public class Mine : Cell
{
    public Mine(Team color) : base(color) { }

    public override void HandleInMovement(Move move, Board board)
    {
        var r = new Random();
        if (r.Next(0, 1) == 0)
        {
            board.figures[move.Xto, move.Yto] = null;
            board.board[move.Xto, move.Yto] = new DefaultCell(this.Team);
        }
    }

    public override void HandleOutMovement(Move move, Board board)
    {
        var r = new Random();
        if (r.Next(0, 1) == 0)
        {
            board.figures[move.Xfrom, move.Yfrom] = null;
            board.board[move.Xfrom, move.Yfrom] = new DefaultCell(this.Team);
        }
    }
}
