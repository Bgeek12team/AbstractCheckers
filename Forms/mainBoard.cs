using CheckersClasslib;
using System.Drawing.Printing;

namespace Forms
{
    public partial class mainBoard : Form
    {
        Board board;
        PictureBox[,] pcCells;
        PictureBox[,] pcFigures;

        Cell[,] cells;
        Figure[,] figures;
        readonly (int x, int y) sizeCell;
        readonly (int x, int y) sizeFigure;
        readonly int margin;

        bool moveStarted = false;
        int xTo, yTo, xFrom, yFrom;

        public mainBoard(Cell[,] cells, Figure[,] figures)
        {
            InitializeComponent();
            this.cells = cells;
            this.figures = figures;
            board = new Board(cells, figures);
            sizeCell.x = 105; sizeCell.y = 105;
            sizeFigure.x = 60; sizeFigure.y = 60;
            margin = 30;

            InitBoard();
            txbx_leading.Text = board.LeadingTeam.ToString();
            board.ChangedTeam += (o,e) => txbx_leading.Text = board.LeadingTeam.ToString();

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

        void Redraw()
        {
            for (int i = 0; i < cells.GetLength(0); i++)
            {
                for (int j = 0; j < cells.GetLength(1); j++)
                {
                    pcFigures[i, j].BackgroundImage = GetImageForFigure(figures[i, j]);
                    pcFigures[i, j].Update();
                }
            }
        }

        void InitBoard()
        {
            pcCells = new PictureBox[cells.GetLength(0), cells.GetLength(1)];
            pcFigures = new PictureBox[cells.GetLength(0), cells.GetLength(1)];
            int y = margin, x;
            for (int i = 0; i < cells.GetLength(0); i++)
            {
                x = margin;
                for (int j = 0; j < cells.GetLength(1); j++)
                {

                    var cell = new PictureBox()
                    {
                        Size = new Size(sizeCell.x, sizeCell.y),
                        Location = new Point(x, y),
                        BackgroundImage = GetImageForCell(cells[i, j]),
                    };

                    Controls.Add(cell);


                    var figure = new PictureBox()
                    {
                        Size = new Size(sizeFigure.x, sizeFigure.y),
                        Location = new Point((sizeCell.x - sizeFigure.x) / 2, (sizeCell.y - sizeFigure.y) / 2)
                    };
                    if (figures[i, j] != null)
                    {
                        figure.BackgroundImage = GetImageForFigure(figures[i, j]);
                    };

                    cell.Controls.Add(figure);

                    pcCells[i, j] = cell;
                    pcFigures[i, j] = figure;

                    pcFigures[i, j].MouseDown += GenerateAction(i, j);
                    pcCells[i, j].MouseDown += GenerateAction(i, j);

                    x += sizeCell.x;
                }
                y += sizeCell.y;
            }
        }

        MouseEventHandler GenerateAction(int j, int i) =>
            (o, e) =>
            {
                if (!moveStarted)
                {
                    (xFrom, yFrom) = (i, cells.GetLength(1) - 1 - j);
                    moveStarted = true;
                }
                else
                {
                    (xTo, yTo) = (i, cells.GetLength(1) - 1- j);
                    board.MakeMove(new(xFrom, yFrom, xTo, yTo));
                    Redraw();
                    moveStarted = false;
                }
            };

        private void MainBoard_MouseDown(object? sender, MouseEventArgs e)
        {
            throw new NotImplementedException();
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

        private void gB_board_Enter(object sender, EventArgs e)
        {

        }

        private void mainBoard_MouseDown_1(object sender, MouseEventArgs e)
        {
        }

        private void mainBoard_MouseUp(object sender, MouseEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
