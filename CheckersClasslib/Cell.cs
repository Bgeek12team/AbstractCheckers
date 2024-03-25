namespace CheckersClasslib;

public abstract class Cell(Teams team)
{
    public Teams Team { get; set; } = team;
    public abstract void HandleInMovement(Move move, Board board);
    public abstract void HandleOutMovement(Move move, Board board);
}
