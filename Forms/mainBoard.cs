using CheckersClasslib;

namespace Forms
{
    public partial class mainBoard : Form
    {
        Board board;

        Cell[,] cells;
        Figure[,] figures;
        (int x, int y) sizeCell;

        Bitmap whiteCells;
        Bitmap blackCells;

        public mainBoard(Cell[,] cells, Figure[,] figures)
        {
            InitializeComponent();
            this.cells = cells;
            this.figures = figures;
            board = new Board(cells, figures);
            sizeCell.x = 55; sizeCell.y = 55;

            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "image", "cellsWhite.jpg");
            whiteCells = new Bitmap(path);
            blackCells = new Bitmap(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "image", "cellsBlack.jpg"));


            initBoard();
            
        }

        Image GetImageForFigure(Figure figure)
        {
            if (figure == null)
                return Image.FromFile("NoChess.png");
            if (figure is DefaultFigure)
                return Image.FromFile("C:\\Users\\�������\\source\\repos\\AbstractCheckers\\Forms\\image\\5053bd92-f2e2-48dd-a0ac-52fd46007138.jpg");
            if (figure is Queen)
                return Image.FromFile("Queen.jpg");
            if (figure is Markelov)
                return Image.FromFile("Mark.jpg");
            if (figure is StraightFigure)
                return Image.FromFile("Straight.jpg");
            throw new NotImplementedException();
        }

        void initBoard()
        {
            int y = 30, x;
            for (int i = 0; i < cells.GetLength(0); i++)
            {
                x = 30;
                for (int j = 0; j < cells.GetLength(1); j++)
                {

                    var image = GetImageForFigure(figures[i, j]);
                    var cell = new PictureBox()
                    {
                        Size = new Size(sizeCell.x, sizeCell.y),
                        Location = new Point(x, y),
                        BackColor = cells[i, j].Team == Team.White ? Color.Gray : Color.Black,
                        Image = image
                        BackgroundImage = cells[i, j].Team == Team.White ? whiteCells : blackCells
                    };
                    gB_board.Controls.Add(cell);
                    x += sizeCell.x;
                }
                y += sizeCell.y;
            }
        }
        

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void b_stopGame_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void mainBoard_Load(object sender, EventArgs e)
        {

        }
    }
}
