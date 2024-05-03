using System.Drawing;

namespace CheckersClasslib;

/// <summary>
/// Абстрактный базовый класс для фигур на доске.
/// Определяет базовые свойства и методы, которые должны быть реализованы в производных классах фигур.
/// </summary>
public abstract class Figure
{
    /// <summary>
    /// Конструктор для создания фигуры принадлежащей определенной команде.
    /// </summary>
    /// <param name="team">Команда, к которой принадлежит фигура</param>
    public Figure(Team team)
    {
        FigureTeam = team;
    }

    /// <summary>
    /// Команда, к которой принадлежит фигура.
    /// </summary>
    public Team FigureTeam { get; private set; }

    /// <summary>
    /// Горизонтальная координата фигуры на доске.
    /// </summary>
    public int X { get; set; }

    /// <summary>
    /// Вертикальная координата фигуры на доске.
    /// </summary>
    public int Y { get; set; }

    /// <summary>
    /// Определяет, является ли предложенный ход допустимым перемещением для фигуры.
    /// </summary>
    public abstract bool IsValidMovement(Move move, Board board);

    /// <summary>
    /// Определяет, является ли предложенный ход допустимым для съедания фигуры противника.
    /// </summary>
    public abstract bool IsValidEating(Move move, Board board);

    /// <summary>
    /// Обрабатывает действия, связанные с перемещением фигуры в новую позицию на доске.
    /// </summary>
    public abstract void HandleInMovement(Move move, Board board);

    /// <summary>
    /// Обрабатывает действия, связанные с уходом фигуры из текущей позиции.
    /// </summary>
    public abstract void HandleOutMovement(Move move, Board board);

    /// <summary>
    /// Определяет, может ли фигура съесть другую фигуру в соответствии с правилами игры.
    /// </summary>
    public abstract bool CanEat(Move move, Board board);

    /// <summary>
    /// Определяет, может ли фигура переместиться на новую позицию в соответствии с правилами игры.
    /// </summary>
    public abstract bool CanMove(Move move, Board board);
}

