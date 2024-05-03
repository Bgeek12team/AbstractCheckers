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


    public Board(Cell[,] cells, Figure[,] figures)
    {
        board = cells;
        this.figures = figures;
    }
    

    public bool MakeMove(Move move)
    {
        if (figures[move.Xfrom, move.Yfrom] == null)
            return false;
        if (figures[move.Xfrom, move.Yfrom].Team != LeadingTeam)
            return false;

        MoveResult moveResult;
        moveResult = HandleMove(move);
        if (moveResult == MoveResult.Denied)
        {
            ChangeTeam();
            return false;
        }

        if (board[move.Xfrom, move.Yfrom] == null)
        {
            ChangeTeam();
            return false;
        }

        figures[move.Xfrom, move.Yfrom].HandleOutMovement(move, this);
        board[move.Xfrom, move.Xfrom].HandleOutMovement(move, this);

        if (moveResult == MoveResult.Movement)
        {
            HandleMovement(move);
            return true;
        }
        HandleEating(move);
        return true;
    }


    MoveResult HandleMove(Move move)
    {
        
        var movingFigure = figures[move.Xfrom, move.Yfrom];
        if (movingFigure.IsValidEating(move, this))
        {
            if (movingFigure.CanEat(move, this))
                return MoveResult.Eat;
        }
        if (movingFigure.IsValidMovement(move, this))
        {
            return movingFigure.CanMove(move, this) ? MoveResult.Movement : MoveResult.Denied;
        }
        return MoveResult.Denied;
    }
    

    void HandleMovement(Move move)
    {
        if (figures[move.Xfrom, move.Yfrom] == null)
        {
            ChangeTeam();
            return;
        }
        ChangeCoords(move);
        figures[move.Xto, move.Yto]?.HandleInMovement(move, this);
        board[move.Xto, move.Yto]?.HandleInMovement(move, this);
        ChangeTeam();
    }
    void ChangeCoords(Move move)
    {
        (figures[move.Xfrom, move.Yfrom], figures[move.Xto, move.Yto]) = 
            (figures[move.Xto, move.Yto], figures[move.Xfrom, move.Yfrom]);
    }

    void HandleEating(Move move)
    {
        DeleteFigures(move);
        ChangeCoords(move);
        board[move.Xto, move.Yto]?.HandleInMovement(move, this);
        figures[move.Xfrom, move.Yfrom]?.HandleInMovement(move, this);
        return;
    }

    void DeleteFigures(Move move)
    {
        var difX = move.Xto - move.Xfrom;
        var difY = move.Yto - move.Yfrom;
        var startX = move.Xfrom;
        var startY = move.Yfrom;
        var len = Math.Max(Math.Abs(difX), Math.Abs(difY));
        if (len == 0)
            return;
        var stepX = difX / len;
        var stepY = difY / len;
        for (int i = 1; i <= len - 1; i++)
        {
            figures[startX + i * stepX, startY + i * stepY] = null;
        }
    }

    void ChangeTeam()
    { 
        LeadingTeam = (Team)(1 - (int)LeadingTeam);
        ChangedTeam?.Invoke(this, new BoardEventArgs());
    }

}
