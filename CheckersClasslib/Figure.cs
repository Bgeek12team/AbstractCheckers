namespace CheckersClasslib;

public abstract class Figure
{
    public int X { get; set; }
    public int Y { get; set; }

    public abstract bool IsValidMove(Move move);

    public abstract bool CanEat(Move move, Board board);
}