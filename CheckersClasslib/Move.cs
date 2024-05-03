namespace CheckersClasslib;


/// <summary>
/// Структура для представления хода в игре.
/// Хранит начальные и конечные координаты хода фигуры.
/// </summary>
public readonly record struct Move
{
    /// <summary>
    /// Начальная горизонтальная координата фигуры.
    /// </summary>
    public int Xfrom { get; }

    /// <summary>
    /// Начальная вертикальная координата фигуры.
    /// </summary>
    public int Yfrom { get; }

    /// <summary>
    /// Конечная горизонтальная координата фигуры.
    /// </summary>
    public int Xto { get; }

    /// <summary>
    /// Конечная вертикальная координата фигуры.
    /// </summary>
    public int Yto { get; }

    /// <summary>
    /// Конструктор для создания хода с указанными начальными и конечными координатами.
    /// </summary>
    /// <param name="Xfrom">Начальная горизонтальная координата</param>
    /// <param name="Yfrom">Начальная вертикальная координата</param>
    /// <param name="Xto">Конечная горизонтальная координата</param>
    /// <param name="Yto">Конечная вертикальная координата</param>
    public Move(int Xfrom, int Yfrom, int Xto, int Yto)
    {
        this.Xfrom = Xfrom;
        this.Yfrom = Yfrom;
        this.Xto = Xto;
        this.Yto = Yto;
    }
}

