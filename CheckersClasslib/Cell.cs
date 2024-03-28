namespace CheckersClasslib;

public abstract class Cell
{
    public Cell(Team team)
    {
        Team = team;
    }
    public Team Team { get; set; }
    public abstract void HandleInMovement(Move move, Board board);
    public abstract void HandleOutMovement(Move move, Board board);
}
