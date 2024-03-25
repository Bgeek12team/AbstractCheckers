namespace CheckersClasslib;

public class Board
{
    Cell[,] board;
    Figure[,] figures;

    public event EventHandler<BoardEventArgs> ChangedTeam;

    public Teams LeadingTeam { get; set; }

    public Board(Cell[,] cells, Figure[,] figures, int size)
    {
        board = new Cell[size, size];
        figures = new Figure[size, size];
    }

    public void MakeMove(Move move)
    {
        if (!figures[move.Xfrom, move.Yfrom].IsValidMove(move))
        {
            return;
        }
        board[move.Xto, move.Yto].HandleOutMovement(move, this);
        if (!HandleMovement(move)) // ход на просто перемещение
        { 
            HandleEating(move);
            return;
        } 
        ChangeTeam();
    }

    bool HandleMovement(Move move)
    {
        ChangeCoords(move);
        board[move.Xto, move.Yto].HandleInMovement(move, this);
        return default;
    }
    void ChangeCoords(Move move)
    {
        return;
    }
    

    void HandleEating(Move move)
    {
        if (!figures[move.Xfrom, move.Yfrom].CanEat(move, this))
        {
            ChangeTeam();
            return;
        }
        DeleteFigures(move);
        SkipMove(move);
        var newPos = CreateSkippedMove(move);
        board[newPos.Xto, newPos.Yto].HandleInMovement(newPos, this);
        return;
    }

    Move CreateSkippedMove(Move move)
    {
        return default;
    }

    void DeleteFigures(Move move)
    {
        return;
    }
    void SkipMove(Move move)
    {
        return;
    }


    void ChangeTeam()
    { 
        LeadingTeam = (Teams)(1 - (int)LeadingTeam);
        ChangedTeam?.Invoke(this, new BoardEventArgs());
    }

}
