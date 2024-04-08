using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckersClasslib
{
    public class TrenbolonCell : Cell
    {
        public TrenbolonCell(Team color) : base(color) { }

        public override void HandleInMovement(Move move, Board board)
        {
            if (board.board[move.Xto, move.Yto] is TrenbolonCell &&
                board.figures[move.Xto, move.Yto] != null &&
                board.figures[move.Xto, move.Yto] is not Markelov)
            {
                var figure = board.figures[move.Xto, move.Yto];
                var team = figure.Team;

                var newMark = new Markelov(team);

                board.figures[move.Xto, move.Yto] = newMark;
            }
        }

        public override void HandleOutMovement(Move move, Board board)
        {

        }
    }
}
