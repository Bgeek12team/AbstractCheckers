namespace CheckersClasslib;
/// <summary>
/// Фигура "Бомба", которая может взрываться при перемещении, уничтожая соседние фигуры.
/// </summary>
public class BombFigure : Figure
{
    /// <summary>
    /// Инициализирует новый экземпляр фигуры "Бомба" для указанной команды.
    /// </summary>
    /// <param name="team">Команда, которой принадлежит фигура.</param>
    public BombFigure(Team team) : base(team) { }

    /// <summary>
    /// Определяет, может ли фигура съесть другую фигуру. Для "Бомбы" всегда возвращает false.
    /// </summary>
    public override bool CanEat(Move move, Board board) => false;

    /// <summary>
    /// Определяет, может ли фигура переместиться на указанную позицию.
    /// </summary>
    public override bool CanMove(Move move, Board board) =>
        board.figures[move.Xto, move.Yto] == null;

    /// <summary>
    /// Проверяет, допустим ли ход на съедение для фигуры "Бомба". Всегда возвращает false.
    /// </summary>
    public override bool IsValidEating(Move move, Board board) => false;

    /// <summary>
    /// Проверяет, допустимо ли движение для "Бомбы".
    /// </summary>
    public override bool IsValidMovement(Move move, Board board) =>
        Math.Abs(move.Xto - move.Xfrom) <= 2 && Math.Abs(move.Yto - move.Yfrom) <= 2;

    /// <summary>
    /// Обрабатывает действия при входе фигуры на клетку.
    /// </summary>
    public override void HandleInMovement(Move move, Board board)
    {
        Explode(move, board);
    }

    /// <summary>
    /// Вызывает взрыв фигуры "Бомба", уничтожая фигуры в соседних клетках.
    /// </summary>
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

    /// <summary>
    /// Обрабатывает действия при выходе фигуры из клетки. Для "Бомбы" не требуется реализация.
    /// </summary>
    public override void HandleOutMovement(Move move, Board board)
    {
        // Пустая реализация, так как "Бомба" не требует действий при выходе из клетки.
    }

    /// <summary>
    /// Определяет, должна ли "Бомба" самовзорваться.
    /// </summary>
    /// <returns>Возвращает true, если бомба должна взорваться.</returns>
    private static bool SelfExplode()
    {
        Random random = new Random();
        return random.Next(0, 4) <= 1;  // 50% вероятность взрыва
    }
}
