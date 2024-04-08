using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckersClasslib
{
    public class TrembolonCell : Cell
    {
        public TrembolonCell(Team color) : base(color) { }

        public override void HandleInMovement(Move move, Board board)
        {
            if (board.board[move.Xfrom, move.Yfrom] is TrembolonCell &&
                board.figures[move.Xfrom, move.Yfrom] != null &&
                !(board.figures[move.Xfrom, move.Yfrom] is Markelov))
            {
                var figure = board.figures[move.Xfrom, move.Yfrom];
                var team = figure.Team;

                var newMark = new Markelov(team);

                board.figures[move.Xfrom, move.Yfrom] = newMark;
            }
        }

        public override void HandleOutMovement(Move move, Board board)
        {

        }
    }
}
