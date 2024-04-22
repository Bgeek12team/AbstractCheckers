using CheckersClasslib;

namespace Forms
{
    public partial class mainBoard : Form
    {
        Board board;

        Cell[,] cells;
        Figure[,] figures;
        (int x, int y) sizeCell;
        (int x, int y) sizeFigure;


        public mainBoard(Cell[,] cells, Figure[,] figures)
        {
            InitializeComponent();
            this.cells = cells;
            this.figures = figures;
            board = new Board(cells, figures);
            sizeCell.x = 105; sizeCell.y = 105;
            sizeFigure.x = 60; sizeFigure.y = 60;

            initBoard();
            
        }

        Image GetImageForCell(Cell cell)
        {
            var curdir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "image");

            if (cell is DefaultCell)
                if (cell.Team == Team.White)
                    return Image.FromFile(Path.Combine(curdir, "whiteDefaultCell.png"));
                else
                    return Image.FromFile(Path.Combine(curdir, "blackDefaultCell.png"));

            if (cell is Mine)
                if (cell.Team == Team.White)
                    return Image.FromFile(Path.Combine(curdir, "whiteMine.png"));
                else
                    return Image.FromFile(Path.Combine(curdir, "blackMine.png"));

            if (cell is Trampoline)
                if (cell.Team == Team.White)
                    return Image.FromFile(Path.Combine(curdir, "whiteTrampoline.png"));
                else
                    return Image.FromFile(Path.Combine(curdir, "blackTrampoline.png"));

            if (cell is Catapult)
                if (cell.Team == Team.White)
                    return Image.FromFile(Path.Combine(curdir, "whiteCatapult.png"));
                else
                    return Image.FromFile(Path.Combine(curdir, "blackCatapult.png"));

            if (cell is AntiMarkMine)
                if (cell.Team == Team.White)
                    return Image.FromFile(Path.Combine(curdir, "whiteAntiMark.png"));
                else
                    return Image.FromFile(Path.Combine(curdir, "blackAntiMark.png"));


            if (cell is TrenbolonCell)
                if (cell.Team == Team.White)
                    return Image.FromFile(Path.Combine(curdir, "whiteTrenbolone.png"));
                else
                    return Image.FromFile(Path.Combine(curdir, "whiteTrenbolone.png"));


            throw new NotImplementedException();
        }

        Image GetImageForFigure(Figure figure)
        {
            var curdir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "image");

            if (figure == null)
                return Image.FromFile(Path.Combine(curdir, "noFigure.png"));
            
            if (figure is DefaultFigure)
                if (figure.Team == Team.White)
                    return Image.FromFile(Path.Combine(curdir, "whiteFigure.png"));
                else
                    return Image.FromFile(Path.Combine(curdir, "blackFigure.png"));

            if (figure is Queen)
                if (figure.Team == Team.White)
                    return Image.FromFile(Path.Combine(curdir, "whiteQueen.png"));
                else
                    return Image.FromFile(Path.Combine(curdir, "blackQueen.png"));

            if (figure is Markelov)
                if (figure.Team == Team.White)
                    return Image.FromFile(Path.Combine(curdir, "whiteMark.png"));
                else
                    return Image.FromFile(Path.Combine(curdir, "blackMark.png"));

            if (figure is StraightFigure)
                if (figure.Team == Team.White)
                    return Image.FromFile(Path.Combine(curdir, "whiteSraight.png"));
                else
                    return Image.FromFile(Path.Combine(curdir, "blackStraight.png"));


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

                    var cell = new PictureBox()
                    {
                        Size = new Size(sizeCell.x, sizeCell.y),
                        Location = new Point(x, y),
                        BackgroundImage = GetImageForCell(cells[i, j]),
                    };

                    gB_board.Controls.Add(cell);

                    if (figures[i, j] != null)
                    {
                        var figure = new PictureBox()
                        {
                            Size = new Size(sizeFigure.x, sizeFigure.y),
                            Location = new Point((sizeCell.x - sizeFigure.x) / 2, (sizeCell.y - sizeFigure.y) / 2),
                            BackgroundImage = GetImageForFigure(figures[i, j]),
                        };
                        cell.Controls.Add(figure);
                    }

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
