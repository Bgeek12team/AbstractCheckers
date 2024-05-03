namespace CheckersClasslib;
/// <summary>
/// Класс, представляющий игровую доску для расширенной версии шашек.
/// Управляет состоянием игры, обработкой ходов и сменой активной команды.
/// </summary>
public class Board
{
    /// <summary>
    /// Результаты попыток выполнить ход.
    /// </summary>
    public enum MoveResult
    {
        Eat,       // Ход съедает фигуру противника
        Movement,  // Ход перемещает фигуру на новую позицию
        Denied     // Ход отклонен (невозможен)
    }

    /// <summary>
    /// Двумерный массив клеток, представляющий собой игровую доску.
    /// </summary>
    internal Cell[,] board;

    /// <summary>
    /// Двумерный массив фигур, размещенных на доске.
    /// </summary>
    internal Figure[,] figures;

    /// <summary>
    /// Событие, срабатывающее при смене команды.
    /// </summary>
    public event EventHandler<BoardEventArgs> ChangedTeam;

    /// <summary>
    /// Текущая ведущая команда, которая имеет право хода.
    /// </summary>
    public Team LeadingTeam { get; set; }

    bool isEating = false;

    /// <summary>
    /// Инициализирует новую доску с заданными клетками и фигурами
    /// </summary>
    public Board(Cell[,] cells, Figure[,] figures)
    {
        board = cells;
        this.figures = figures;
    }

    /// <summary>
    /// Осуществляет попытку выполнить ход
    /// </summary>
    public bool MakeMove(Move move)
    {
        var movingFigure = figures[move.Xfrom, move.Yfrom];
        if (movingFigure == null || movingFigure.FigureTeam != LeadingTeam)
            return false;

        MoveResult moveResult = HandleMove(move);
        if (moveResult == MoveResult.Denied)
        {
            isEating = false;
            ChangeTeam();
            return false;
        }

        movingFigure?.HandleOutMovement(move, this);
        board[move.Xfrom, move.Yfrom]?.HandleOutMovement(move, this);

        if (moveResult == MoveResult.Movement)
        {
            isEating = false;
            HandleMovement(move);
            return true;
        }

        isEating = true;
        HandleEating(move);
        return true;
    }

    /// <summary>
    /// Определяет результат хода в зависимости от возможности съесть фигуру или просто переместиться
    /// </summary>
    private MoveResult HandleMove(Move move)
    {
        var movingFigure = figures[move.Xfrom, move.Yfrom];
        if (movingFigure.IsValidEating(move, this) && movingFigure.CanEat(move, this))
            return MoveResult.Eat;

        if (!isEating && movingFigure.IsValidMovement(move, this) && movingFigure.CanMove(move, this))
            return MoveResult.Movement;

        return MoveResult.Denied;
    }

    /// <summary>
    /// Обрабатывает перемещение фигуры
    /// </summary>
    private void HandleMovement(Move move)
    {
        ChangeCoords(move);
        figures[move.Xto, move.Yto]?.HandleInMovement(move, this);
        board[move.Xto, move.Yto]?.HandleInMovement(move, this);
        ChangeTeam();
    }

    /// <summary>
    /// Меняет координаты двух фигур
    /// </summary>
    private void ChangeCoords(Move move)
    {
        (figures[move.Xfrom, move.Yfrom], figures[move.Xto, move.Yto]) =
            (figures[move.Xto, move.Yto], figures[move.Xfrom, move.Yfrom]);
    }

    /// <summary>
    /// Обрабатывает ситуацию съедения фигуры
    /// </summary>
    private void HandleEating(Move move)
    {
        DeleteFigures(move);
        ChangeCoords(move);
        figures[move.Xto, move.Yto]?.HandleInMovement(move, this);
    }

    /// <summary>
    /// Удаляет фигуры между начальной и конечной точкой хода
    /// </summary>
    private void DeleteFigures(Move move)
    {
        var difX = move.Xto - move.Xfrom;
        var difY = move.Yto - move.Yfrom;
        int len = Math.Max(Math.Abs(difX), Math.Abs(difY));
        if (len == 0)
            return;
        int stepX = difX / len;
        int stepY = difY / len;
        for (int i = 1; i < len; i++)
        {
            figures[move.Xfrom + i * stepX, move.Yfrom + i * stepY] = null;
        }
    }

    /// <summary>
    /// Смена активной команды на противоположную
    /// </summary>
    private void ChangeTeam()
    {
        LeadingTeam = (Team)(1 - (int)LeadingTeam);
        ChangedTeam?.Invoke(this, new BoardEventArgs());
    }
}

