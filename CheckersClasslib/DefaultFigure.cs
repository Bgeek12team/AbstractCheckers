namespace CheckersClasslib;

/// <summary>
/// Класс представляет стандартную фигуру в игре (обычно пешку).
/// </summary>
public class DefaultFigure : Figure
{
    public DefaultFigure(Team team) : base(team) { }

    public override bool CanEat(Move move, Board board) =>
        board.figures[(move.Xfrom + move.Xto) / 2, (move.Yfrom + move.Yto) / 2]?.FigureTeam != this.FigureTeam &&
        board.figures[move.Xto, move.Yto] == null;

    public override bool CanMove(Move move, Board board) =>
        board.figures[move.Xto, move.Yto] == null;

    public override void HandleInMovement(Move move, Board board)
    {
        // Пустая реализация для базовой фигуры
    }

    public override void HandleOutMovement(Move move, Board board)
    {
        // Пустая реализация для базовой фигуры
    }

    public override bool IsValidEating(Move move, Board board) =>
        Math.Abs(move.Yto - move.Yfrom) == 2 && Math.Abs(move.Xto - move.Xfrom) == 2;

    public override bool IsValidMovement(Move move, Board board) =>
        Math.Abs(move.Yto - move.Yfrom) == 1 && Math.Abs(move.Xto - move.Xfrom) == 1 &&
        (board.figures[move.Xfrom, move.Yfrom].FigureTeam == Team.White ? 
                        move.Yfrom > move.Yto : move.Yto > move.Yfrom);
}
