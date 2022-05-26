using Chessboard;

namespace Chess
{
    internal class Rook : Piece
    {
        public Rook(Board board, Color color) : base(board, color)
        {
        }

        public override string ToString()
        {
            return "T";
        }

        private bool CanMove(Position position)
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
            while (Board.ValidatePosition(position) && CanMove(position))
            {
                possibleMoves[position.Row, position.Column] = true;

                if (Board.Piece(position) != null && Board.Piece(position).Color != Color)
                {
                    break;
                }

                position.Row--;
            }

            //East
            position.SetValue(Position.Row, Position.Column + 1);
            while (Board.ValidatePosition(position) && CanMove(position))
            {
                possibleMoves[position.Row, position.Column] = true;

                if (Board.Piece(position) != null && Board.Piece(position).Color != Color)
                {
                    break;
                }

                position.Column++;
            }

            //South
            position.SetValue(Position.Row + 1, Position.Column);
            while (Board.ValidatePosition(position) && CanMove(position))
            {
                possibleMoves[position.Row, position.Column] = true;

                if (Board.Piece(position) != null && Board.Piece(position).Color != Color)
                {
                    break;
                }

                position.Row++;
            }

            //West
            position.SetValue(Position.Row, Position.Column - 1);
            while (Board.ValidatePosition(position) && CanMove(position))
            {
                possibleMoves[position.Row, position.Column] = true;

                if (Board.Piece(position) != null && Board.Piece(position).Color != Color)
                {
                    break;
                }

                position.Column--;
            }

            return possibleMoves;
        }
    }
}
