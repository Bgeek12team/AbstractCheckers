using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckersClasslib;
/// <summary>
/// Класс фигуры Марка, который обладает уникальными способностями перемещения и захвата.
/// </summary>
public class Markelov : Figure
{
    public Markelov(Team team) : base(team) { }

    /// <summary>
    /// Проверяет возможность захвата фигуры.
    /// </summary>
    public override bool CanEat(Move move, Board board)
    {
        // Проверка вероятности движения
        if (!MoveChance())
            return false;

        // Вычисление длины и направления хода
        var difX = move.Xto - move.Xfrom;
        var difY = move.Yto - move.Yfrom;
        var len = Math.Max(Math.Abs(difX), Math.Abs(difY));

        if (len == 0)
            return false;

        var stepX = difX / len;
        var stepY = difY / len;

        // Проверка наличия фигур между начальной и конечной точками
        var count = 0;
        for (int i = 1; i <= len - 1; i++)
        {
            if (board.figures[move.Xfrom + i * stepX, move.Yfrom + i * stepY] != null)
                count++;
        }

        // Не должно быть фигур между начальной и конечной точками кроме последней
        if (count == 0 || 
board.figures[move.Xfrom + (len - 1) * stepX, move.Yfrom + (len - 1) * stepY]?.FigureTeam == this.FigureTeam)
            return false;

        return board.figures[move.Xto, move.Yto] == null;
    }

    /// <summary>
    /// Проверяет возможность перемещения фигуры.
    /// </summary>
    public override bool CanMove(Move move, Board board)
    {
        // Проверка вероятности движения
        if (!MoveChance())
            return false;

        // Вычисление длины и направления хода
        var difX = move.Xto - move.Xfrom;
        var difY = move.Yto - move.Yfrom;
        var len = Math.Max(Math.Abs(difX), Math.Abs(difY));
        var stepX = difX / len;
        var stepY = difY / len;

        // Проверка, что по пути нет других фигур
        for (int i = 1; i <= len; i++)
        {
            if (board.figures[move.Xfrom + i * stepX, move.Yfrom + i * stepY] != null)
                return false;
        }

        return true;
    }

    /// <summary>
    /// Всегда возвращает true, так как фигура может совершать попытку захвата в любой момент.
    /// </summary>
    public override bool IsValidEating(Move move, Board board) => true;

    /// <summary>
    /// Всегда возвращает true, так как фигура может совершать попытку перемещения в любой момент.
    /// </summary>
    public override bool IsValidMovement(Move move, Board board) => true;

    /// <summary>
    /// Вероятность движения или захвата.
    /// </summary>
    private static bool MoveChance()
    {
        Random random = new Random();
        return random.Next(0, 2) == 0; // Возвращает true с вероятностью 50%
    }

    public override void HandleInMovement(Move move, Board board)
    {
        // Пустая реализация, так как особые действия при входе не требуются.
    }

    public override void HandleOutMovement(Move move, Board board)
    {
        // Пустая реализация, так как особые действия при выходе не требуются.
    }
}
