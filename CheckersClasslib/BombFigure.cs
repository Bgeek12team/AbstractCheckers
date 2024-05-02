namespace CheckersClasslib;

public class BombFigure : Figure
{
    public BombFigure(Team team) : base(team) { }

    public override bool CanEat(Move move, Board board) => false;

    public override bool CanMove(Move move, Board board) =>
        board.figures[move.Xto, move.Yto] == null;

    public override bool IsValidEating(Move move, Board board) => false;

    public override bool IsValidMovement(Move move, Board board) =>
        Math.Abs(move.Xto - move.Xfrom) <= 2 && Math.Abs(move.Yto - move.Yfrom) <= 2;

    public override void HandleInMovement(Move move, Board board)
    {
        Explode(move, board);
    }

    private void Explode(Move move, Board board)
    {
        if (SelfExplode())
        {
            board.figures[move.Xto, move.Yto] = null;
            return;
        }
        int[] dx = { -1, 0, 1, -1, 1, -1, 0, 1 };
        int[] dy = { -1, -1, -1, 0, 0, 1, 1, 1 };
        for (int i = 0; i < dx.Length; i++)
        {
            int nx = move.Xto + dx[i];
            int ny = move.Yto + dy[i];
            if (nx >= 0 && nx < board.figures.GetLength(0) && ny >= 0 && ny < board.figures.GetLength(1))
            {
                board.figures[nx, ny] = null;
            }
        }
    }

    public override void HandleOutMovement(Move move, Board board)
    {

    }

    private static bool SelfExplode()
    {
        Random random = new Random();
        return random.Next(0, 3) <= 1;
    }
}
