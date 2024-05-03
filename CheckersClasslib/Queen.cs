namespace CheckersClasslib;

/// <summary>
/// Класс представляет фигуру дамки, которая может двигаться и захватывать по диагоналям.
/// </summary>
public class Queen : Figure
{
    public Queen(Team team) : base(team) { }

    /// <summary>
    /// Проверяет возможность захвата другой фигуры.
    /// </summary>
    public override bool CanEat(Move move, Board board)
    {
        var difX = move.Xto - move.Xfrom;
        var difY = move.Yto - move.Yfrom;
        var startX = move.Xfrom;
        var startY = move.Yfrom;
        var len = Math.Abs(difX);  // Длина хода должна быть одинакова в обеих измерениях для диагонального хода.

        if (len == 0)
            return false;

        var stepX = difX / len;
        var stepY = difY / len;
        var count = 0;
        for (int i = 1; i <= len - 1; i++)
        {
            if (board.figures[startX + i * stepX, startY + i * stepY] != null)
                count++;
        }

        if (count > 1 || count == 0)  // Захват возможен, если между начальной и конечной точкой ровно одна фигура.
            return false;

        return board.figures[startX + (len - 1) * stepX, startY + (len - 1) * stepY]?.FigureTeam != this.FigureTeam &&
               board.figures[move.Xto, move.Yto] == null;
    }

    /// <summary>
    /// Проверяет возможность перемещения на заданную клетку.
    /// </summary>
    public override bool CanMove(Move move, Board board)
    {
        var difX = move.Xto - move.Xfrom;
        var difY = move.Yto - move.Yfrom;
        var startX = move.Xfrom;
        var startY = move.Yfrom;
        var len = Math.Abs(difX);  // Путь должен быть чист от других фигур.

        if (len == 0)
            return false;

        var stepX = difX / len;
        var stepY = difY / len;
        for (int i = 1; i <= len; i++)
        {
            if (board.figures[startX + i * stepX, startY + i * stepY] != null)
                return false;
        }

        return true;
    }

    public override void HandleInMovement(Move move, Board board) { }

    public override void HandleOutMovement(Move move, Board board) { }

    /// <summary>
    /// Возвращает true, если движение соответствует диагональному ходу.
    /// </summary>
    public override bool IsValidEating(Move move, Board board) =>
        Math.Abs(move.Yto - move.Yfrom) == Math.Abs(move.Xto - move.Xfrom);

    /// <summary>
    /// Возвращает true, если движение соответствует диагональному ходу.
    /// </summary>
    public override bool IsValidMovement(Move move, Board board) =>
        Math.Abs(move.Yto - move.Yfrom) == Math.Abs(move.Xto - move.Xfrom);
}