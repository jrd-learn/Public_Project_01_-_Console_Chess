using Chessboard;

namespace Chess
{
    internal class Knight : Piece
    {
        public Knight(Board board, Color color) : base(board, color)
        {
        }

        public override string ToString()
        {
            return "C";
        }

        private bool CanMove(Position position)
        {
            Piece piece = Board.Piece(position);

            return piece == null || piece.Color != Color;
        }

        public override bool[,] PossibleMoves() // TODO
        {
            bool[,] possibleMoves = new bool[Board.Rows, Board.Columns];

            Position position = new Position(0, 0);

            //North
            position.SetValue(Position.Row - 1, Position.Column);
            while (Board.ValidatePosition(position) && CanMove(position))
            {
                possibleMoves[Position.Row, Position.Column] = true;

                if (Board.Piece(position) != null && Board.Piece(position).Color != Color)
                {
                    break;
                }

                position.Row--;
            }            

            return possibleMoves;
        }
    }
}
