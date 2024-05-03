namespace CheckersClasslib;
/// <summary>
/// Класс представляет клетку "Катапульта", которая перемещает фигуру на максимальное доступное расстояние в соответствии с направлением её команды.
/// </summary>
public class Catapult : Cell
{
    /// <summary>
    /// Инициализирует новую катапульту, принадлежащую определенной команде.
    /// </summary>
    /// <param name="color">Команда клетки</param>
    public Catapult(Team color) : base(color) { }

    /// <summary>
    /// Обрабатывает вход фигуры на клетку, перемещая её на максимально возможное расстояние в направлении команды клетки.
    /// </summary>
    /// <param name="move">Детали хода, включая начальные и конечные координаты фигуры</param>
    /// <param name="board">Доска, на которой происходит игра</param>
    public override void HandleInMovement(Move move, Board board)
    {
        var newX = move.Xto;
        var newY = move.Yto;
        // Катапультируем фигуру в зависимости от команды клетки
        if (this.CellTeam == Team.Black)
        {
            newY = MoveToMaximumAvailablePosition(newX, newY, 1, board);
        }
        else
        {
            newY = MoveToMaximumAvailablePosition(newX, newY, -1, board);
        }

        // Если позиция изменилась, перемещаем фигуру
        if (newY != move.Yto)
        {
            board.figures[newX, newY] = board.figures[move.Xto, move.Yto];
            board.figures[move.Xto, move.Yto] = null;
        }
    }

    public override void HandleOutMovement(Move move, Board board)
    {
        // Пустая реализация, так как "Катапульта" не требует действий при выходе фигуры из клетки.
    }

    /// <summary>
    /// Вычисляет новую позицию Y, перемещаясь в заданном направлении до первой занятой клетки или края доски.
    /// </summary>
    /// <param name="x">Текущая координата X фигуры</param>
    /// <param name="y">Текущая координата Y фигуры</param>
    /// <param name="direction">Направление движения (1 или -1)</param>
    /// <param name="board">Доска, на которой происходит игра</param>
    /// <returns>Максимально возможная координата Y для перемещения</returns>
    private static int MoveToMaximumAvailablePosition(int x, int y, int direction, Board board)
    {
        while (y + direction >= 0 && 
            y + direction < board.board.GetLength(1) && 
            board.figures[x, y + direction] == null)
        {
            y += direction;
        }
        return y;
    }
}




