namespace CheckersClasslib;

/// <summary>
/// Класс представляет мины, которые активируются на Марка
/// </summary>
public class AntiMarkMine : Mine
{
    /// <summary>
    /// Инициализирует новую мину, которая реагирует на Марка
    /// </summary>
    /// <param name="color">Команда, к которой принадлежит мина</param>
    public AntiMarkMine(Team color) : base(color) { }

    /// <summary>
    /// Обрабатывает вход фигуры на клетку с миной.
    /// Уничтожает Марка, если она входит на клетку с этой миной.
    /// </summary>
    /// <param name="move">Детали хода, который был совершен</param>
    /// <param name="board">Доска, на которой происходит игра</param>
    public override void HandleInMovement(Move move, Board board)
    {
        // Уничтожаем Марка, если она входит на клетку с миной
        if (board.figures[move.Xto, move.Yto] is Markelov)
        {
            board.figures[move.Xto, move.Yto] = null;
        }
    }

    /// <summary>
    /// Обрабатывает выход фигуры с клетки с миной.
    /// Уничтожает Марка, если она выходит с клетки с этой миной.
    /// </summary>
    /// <param name="move">Детали хода, который был совершен</param>
    /// <param name="board">Доска, на которой происходит игра</param>
    public override void HandleOutMovement(Move move, Board board)
    {
        // Уничтожаем Марка, если она выходит с клетки с миной
        if (board.figures[move.Xfrom, move.Yfrom] is Markelov)
        {
            board.figures[move.Xfrom, move.Yfrom] = null;
        }
    }
}

