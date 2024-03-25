namespace CheckersClasslib;

public abstract class Figure(Teams team)
{
    public Teams Team { get; set; } = team;
    public int X { get; set; }
    public int Y { get; set; }

    public abstract bool IsValidMove(Move move);

    public abstract bool CanEat(Move move, Board board);
}