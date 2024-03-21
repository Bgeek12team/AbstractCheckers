namespace CheckersClasslib;

public abstract class Cell
{
    public abstract void HandleInMovement(Move move, Board board);
    public abstract void HandleOutMovement(Move move, Board board);
}
