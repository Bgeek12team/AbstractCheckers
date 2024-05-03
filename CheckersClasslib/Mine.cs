namespace CheckersClasslib;

/// <summary>
/// Представляет клетку с миной, которая может потенциально уничтожить фигуру, входящую или выходящую из неё.
/// </summary>
public class Mine : Cell
{
    private static readonly Random random = new Random();

    /// <summary>
    /// Инициализирует новый экземпляр класса Mine для указанной команды.
    /// </summary>
    /// <param name="color">Команда, которой принадлежит мина.</param>
    public Mine(Team color) : base(color) { }

    /// <summary>
    /// Обрабатывает событие, когда фигура перемещается в эту клетку. Существует вероятность уничтожения фигуры.
    /// </summary>
    /// <param name="move">Детали хода.</param>
    /// <param name="board">Доска, на которой происходит игра.</param>
    public override void HandleInMovement(Move move, Board board)
    {
        // 50% вероятность уничтожить фигуру, входящую в клетку
        if (random.Next(0, 2) == 0)
        {
            board.figures[move.Xto, move.Yto] = null;
            board.board[move.Xto, move.Yto] = new DefaultCell(this.CellTeam);
        }
    }

    /// <summary>
    /// Обрабатывает событие, когда фигура покидает эту клетку. Существует вероятность уничтожения фигуры.
    /// </summary>
    /// <param name="move">Детали хода.</param>
    /// <param name="board">Доска, на которой происходит игра.</param>
    public override void HandleOutMovement(Move move, Board board)
    {
        // 50% вероятность уничтожить фигуру, покидающую клетку
        if (random.Next(0, 2) == 0)
        {
            board.figures[move.Xfrom, move.Yfrom] = null;
            board.board[move.Xfrom, move.Yfrom] = new DefaultCell(this.CellTeam);
        }
    }
}

