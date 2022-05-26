using Chessboard;

namespace Chess
{
    internal class Pawn : Piece
    {
        public Pawn(Board board, Color color) : base(board, color)
        {
        }

        public override string ToString()
        {
            return "P";
        }

        private bool CanMove(Position position) // TODO
        {
            Piece piece = Board.Piece(position);

            return piece == null || piece.Color != Color;
        }

        public override bool[,] PossibleMoves()
        {
            bool[,] possibleMoves = new bool[Board.Rows, Board.Columns];

            Position position = new Position(0, 0);

            //North
            position.SetValue(Position.Row - 1, Position.Column);
            if (Board.ValidatePosition(position) && CanMove(position))
            {
                possibleMoves[position.Row, position.Column] = true;
            }

            return possibleMoves;
        }
    }
}
