namespace CheckersClasslib;

public class Board
{
    public enum MoveResult
    {
        Eat, Movement, Denied
    }

    internal Cell[,] board;
    internal Figure[,] figures;

    public event EventHandler<BoardEventArgs> ChangedTeam;

    public Team LeadingTeam { get; set; }

    public Board(Cell[,] cells, Figure[,] figures, int size)
    {
        board = cells;
        this.figures = figures;
    }

    public void MakeMove(Move move)
    {
        if (board[move.Xfrom, move.Yfrom].Team != LeadingTeam)
            return;

        MoveResult moveResult;
        moveResult = HandleMove(move);
        if (moveResult == MoveResult.Denied)
        {
            ChangeTeam();
            return;
        }
        board[move.Xto, move.Yto].HandleOutMovement(move, this);
        if (moveResult == MoveResult.Movement)
        {
            HandleMovement(move);
            return;
        }
        HandleEating(move);
    }


    MoveResult HandleMove(Move move)
    {
        if (figures[move.Xfrom, move.Yfrom].IsValidEating(move))
        {
            return figures[move.Xto, move.Yto].CanEat(move, this) ? MoveResult.Eat : MoveResult.Denied;
        }
        if (figures[move.Xfrom, move.Yfrom].IsValidMovement(move))
        {
            return figures[move.Xto, move.Yto].CanMove(move, this) ? MoveResult.Movement : MoveResult.Denied;
        }
        return MoveResult.Denied;
    }

    int FigureCount(Move move) =>
        figures[(move.Xfrom + move.Xto) / 2, (move.Yfrom + move.Yto) / 2] != null ?
        1 : 0;

    void HandleMovement(Move move)
    {
        ChangeCoords(move);
        board[move.Xto, move.Yto].HandleInMovement(move, this);
        ChangeTeam();
    }
    void ChangeCoords(Move move)
    {
        Figure clone = figures[move.Xto, move.Yto];
        figures[move.Xto, move.Yto] = figures[move.Xfrom, move.Yfrom];
        figures[move.Xfrom, move.Yfrom] = clone;
    }

    void HandleEating(Move move)
    {
        if (!figures[move.Xfrom, move.Yfrom].CanEat(move, this))
        {
            ChangeTeam();
            return;
        }
        DeleteFigures(move);
        board[move.Xto, move.Yto].HandleInMovement(move, this);
        return;
    }

    void DeleteFigures(Move move)
    {
        int eatenX = (move.Xfrom + move.Xto) / 2;
        int eatenY = (move.Yfrom + move.Yto) / 2;

        figures[eatenX, eatenY] = null;
    }

    void ChangeTeam()
    { 
        LeadingTeam = (Team)(1 - (int)LeadingTeam);
        ChangedTeam?.Invoke(this, new BoardEventArgs());
    }

}
