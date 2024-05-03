using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckersClasslib;

/// <summary>
/// Класс представляет клетку Тренболон, которая трансформирует фигуру на доске в Марка
/// </summary>
public class TrenbolonCell : Cell
{
    public TrenbolonCell(Team color) : base(color) { }

    /// <summary>
    /// Обрабатывает событие входа фигуры на клетку, трансформируя её в Марка (если возможно).
    /// </summary>
    /// <param name="move">Детали хода</param>
    /// <param name="board">Игровая доска</param>
    public override void HandleInMovement(Move move, Board board)
    {
        if (board.figures[move.Xto, move.Yto] != null &&
            board.figures[move.Xto, move.Yto] is not Markelov)
        {
            // Получаем цвет фигуры
            var figure = board.figures[move.Xto, move.Yto];
            var team = figure.FigureTeam;

            // Создаем нового Марка того же цвета
            var newMark = new Markelov(team);

            // Заменяем текущую фигуру на новую
            board.figures[move.Xto, move.Yto] = newMark;
        }
    }

    /// <summary>
    /// Обрабатывает событие выхода фигуры из клетки.
    /// </summary>
    /// <param name="move">Детали хода</param>
    /// <param name="board">Игровая доска</param>
    public override void HandleOutMovement(Move move, Board board)
    {
        // Нет действий при выходе из клетки
    }
}
