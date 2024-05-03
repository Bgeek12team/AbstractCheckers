namespace CheckersClasslib;

/// <summary>
/// Класс представляет стандартную клетку на доске.
/// </summary>
public class DefaultCell : Cell
{
    public DefaultCell(Team color) : base(color) { }

    /// <summary>
    /// Обрабатывает вход фигуры на клетку, превращение в дамку при достижении края доски.
    /// </summary>
    public override void HandleInMovement(Move move, Board board)
    {
        
        // Преобразование пешки в дамку при достижении противоположной стороны доски
        if (board.figures[move.Xto, move.Yto]?.FigureTeam == Team.White && move.Yto == 0)
        {
            board.figures[move.Xto, move.Yto] = new Queen(Team.White);
        }
        else if (board.figures[move.Xto, move.Yto]?.FigureTeam == Team.Black && move.Yto == board.figures.GetLength(1) - 1)
        {
            board.figures[move.Xto, move.Yto] = new Queen(Team.Black);
        }
    }

    /// <summary>
    /// Обрабатывает выход фигуры с клетки.
    /// </summary>
    public override void HandleOutMovement(Move move, Board board)
    {
        // Нет необходимости в реализации для стандартной клетки
    }
}

