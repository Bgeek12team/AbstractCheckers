using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckersClasslib;
/// <summary>
/// Класс представляет фигуру, которая может двигаться и захватывать только по прямым линиям (вертикально или горизонтально).
/// </summary>
public class StraightFigure : Figure
{
    public StraightFigure(Team team) : base(team) { }

    /// <summary>
    /// Определяет, может ли фигура съесть другую фигуру. Съедение возможно, если на пути к цели есть только одна вражеская фигура.
    /// </summary>
    public override bool CanEat(Move move, Board board)
    {
        var midX = (move.Xfrom + move.Xto) / 2;
        var midY = (move.Yfrom + move.Yto) / 2;
        return board.figures[midX, midY] != null &&
               board.figures[midX, midY].FigureTeam != this.FigureTeam &&
               board.figures[move.Xto, move.Yto] == null;
    }

    /// <summary>
    /// Определяет, может ли фигура переместиться на новую позицию. Перемещение возможно, если целевая клетка свободна.
    /// </summary>
    public override bool CanMove(Move move, Board board) =>
        board.figures[move.Xto, move.Yto] == null;

    /// <summary>
    /// Обрабатывает события при входе фигуры на клетку. Для этой фигуры никакие дополнительные действия не требуются.
    /// </summary>
    public override void HandleInMovement(Move move, Board board) { }

    /// <summary>
    /// Обрабатывает события при выходе фигуры из клетки. Для этой фигуры никакие дополнительные действия не требуются.
    /// </summary>
    public override void HandleOutMovement(Move move, Board board) { }

    /// <summary>
    /// Проверяет, допустим ли ход на съедение. Съедение возможно только если расстояние между начальной и конечной точкой равно 2 и фигура движется по прямой.
    /// </summary>
    public override bool IsValidEating(Move move, Board board) =>
        (Math.Abs(move.Yto - move.Yfrom) == 2 && move.Xto == move.Xfrom) ||
        (move.Yto == move.Yfrom && Math.Abs(move.Xto - move.Xfrom) == 2);

    /// <summary>
    /// Проверяет, допустимо ли обычное перемещение. Перемещение возможно на одну клетку по вертикали или горизонтали.
    /// </summary>
    public override bool IsValidMovement(Move move, Board board) =>
        (Math.Abs(move.Yto - move.Yfrom) == 1 && move.Xto == move.Xfrom) ||
        (move.Yto == move.Yfrom && Math.Abs(move.Xto - move.Xfrom) == 1);
}
