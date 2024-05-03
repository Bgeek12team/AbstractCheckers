using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckersClasslib;

/// <summary>
/// Класс представляет клетку "Торнадо", которая транспонирует массивы фигур и клеток доски при входе фигуры.
/// </summary>
public class Tornado : Cell
{
    public Tornado(Team color) : base(color) { }

    /// <summary>
    /// Обрабатывает событие входа фигуры в клетку, транспонируя доску и массив фигур.
    /// </summary>
    /// <param name="move">Детали хода</param>
    /// <param name="board">Игровая доска</param>
    public override void HandleInMovement(Move move, Board board)
    {
        // Транспонируем массив фигур
        TransposeArray(board.figures);
        // Транспонируем игровое поле
        TransposeArray(board.board);
    }

    public override void HandleOutMovement(Move move, Board board)
    {
        // Действия при выходе из клетки не требуются
    }

    /// <summary>
    /// Транспонирует массив, создавая новый массив, где строки и столбцы меняются местами.
    /// </summary>
    /// <typeparam name="T">Тип элементов массива</typeparam>
    /// <param name="array">Исходный двумерный массив</param>
    /// <returns>Новый транспонированный массив</returns>
    static void TransposeArray<T>(T[,] array)
    {
        int rows = array.GetLength(0);
        int columns = array.GetLength(1);

        for (int i = 0; i < rows; i++)
        {
            for (int j = i; j < columns; j++)
            {
                var t = array[i, j];
                array[i, j] = array[j, i];
                array[j, i] = t;
            }
        }
    }
}
