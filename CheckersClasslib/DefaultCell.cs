namespace CheckersClasslib;

public class DefaultCell : Cell
{
    public DefaultCell(Team color) : base(color) { }

    public override void HandleInMovement(Move move, Board board)
    {
        if (board.figures[move.Xto, move.Yto].Team == Team.White) 
        { 
            if (move.Yto == 0)
                board.figures[move.Xto, move.Yto] = new Queen(Team.White);
        }
        if (board.figures[move.Xto, move.Yto].Team == Team.Black)
        {
            if (move.Yto == board.figures.GetLength(1) - 1)
                board.figures[move.Xto, move.Yto] = new Queen(Team.Black);
        }
    }

    public override void HandleOutMovement(Move move, Board board)
    {
        
    }
}

