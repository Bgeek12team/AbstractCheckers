namespace CheckersClasslib;

public enum MoveResult
{
    Eat, Movement, Denied
}

public class Board
{
    Cell[,] board;
    Figure[,] figures;

    public event EventHandler<BoardEventArgs> ChangedTeam;

    public Teams LeadingTeam { get; set; }

    public Board(Cell[,] cells, Figure[,] figures, int size)
    {
        board = cells;
        this.figures = figures;
    }

    public void MakeMove(Move move)
    {
        MoveResult moveResult;
        board[move.Xto, move.Yto].HandleOutMovement(move, this);
        moveResult = HandleMove(move);
        if (moveResult == MoveResult.Denied)
        {
            ChangeTeam();
            return;
        }
        if (moveResult == MoveResult.Movement)
        {
            HandleMovement(move);
            return;
        }
        HandleEating(move);
    }


    MoveResult HandleMove(Move move)
    {
        if (figures[move.Xfrom, move.Yfrom].IsValidMovement(move))
        {
            return figures[move.Xto, move.Yto] == null ? MoveResult.Movement : MoveResult.Denied;
        }
        if (figures[move.Xfrom, move.Yfrom].IsValidEating(move))
        {
            return FigureCount(move) == 1 ? MoveResult.Eat : MoveResult.Denied;
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
        LeadingTeam = (Teams)(1 - (int)LeadingTeam);
        ChangedTeam?.Invoke(this, new BoardEventArgs());
    }

}
