namespace CheckersClasslib;
/// <summary>
/// Класс представляет клетку "батут", которая перемещает входящую фигуру дальше в направлении её движения.
/// </summary>
public class Trampoline : Cell
{
    public Trampoline(Team color) : base(color) { }

    /// <summary>
    /// Обрабатывает событие входа фигуры на клетку, перенаправляя её дальше по вектору движения.
    /// </summary>
    /// <param name="move">Детали хода</param>
    /// <param name="board">Игровая доска</param>
    public override void HandleInMovement(Move move, Board board)
    {
        var xDifference = move.Xto - move.Xfrom;
        var yDifference = move.Yto - move.Yfrom;
        var newX = move.Xto + xDifference;
        var newY = move.Yto + yDifference;

        // Проверка выхода за пределы доски
        if (IsOutsideBoard(newX, newY, board))
        {
            // Если целевая клетка за пределами доски, удаляем фигуру
            board.figures[move.Xto, move.Yto] = null;
        }
        else
        {
            // Перемещаем фигуру на новую клетку
            board.figures[newX, newY] = board.figures[move.Xto, move.Yto];
            board.figures[move.Xto, move.Yto] = null;
        }
    }

    public override void HandleOutMovement(Move move, Board board)
    {
        // Действия при выходе из клетки не требуются
    }

    /// <summary>
    /// Проверяет, находится ли указанная позиция за пределами доски.
    /// </summary>
    /// <param name="x">Горизонтальная координата</param>
    /// <param name="y">Вертикальная координата</param>
    /// <param name="board">Игровая доска</param>
    /// <returns>Возвращает true, если позиция за пределами доски.</returns>
    private bool IsOutsideBoard(int x, int y, Board board)
    {
        return x >= board.board.GetLength(0) || x < 0 ||
               y >= board.board.GetLength(1) || y < 0;
    }
}


