namespace CheckersClasslib;

public class DefaultFigure(Team team) : Figure(team)
{
    public override bool CanEat(Move move, Board board) =>
        board.figures[(move.Xfrom + move.Xto) / 2, (move.Yfrom + move.Yto) / 2] != null &&
        board.figures[(move.Xfrom + move.Xto) / 2, (move.Yfrom + move.Yto) / 2].Team != this.Team &&
        board.figures[move.Xto, move.Yto] == null;

    public override bool CanMove(Move move, Board board) =>
        board.figures[move.Xto, move.Yto] == null;

    public override bool IsValidEating(Move move, Board board) =>
        (Math.Abs(move.Yto - move.Yfrom) == 2) &&
        (Math.Abs(move.Xto - move.Xfrom) == 2);

    public override bool IsValidMovement(Move move, Board board) =>
        (
            board.figures[move.Xfrom, move.Yfrom].Team == Team.White ?
            move.Yfrom - move.Yto == 1 : move.Yto - move.Yfrom == 1
        ) &&
        (Math.Abs(move.Xto - move.Xfrom) == 1);
}
