namespace CheckersClasslib;

public abstract class Figure(Team team)
{
    public Team Team { get; set; } = team;
    public int X { get; set; }
    public int Y { get; set; }

    public abstract bool IsValidMovement(Move move);
    public abstract bool IsValidEating(Move move);

    public abstract bool CanEat(Move move, Board board);
    public abstract bool CanMove(Move move, Board board);
}
