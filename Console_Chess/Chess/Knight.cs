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
            return "N";
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
                        
            position.SetValue(Position.Row - 1, Position.Column - 2);
            if (Board.ValidatePosition(position) && CanMove(position))
            {
                possibleMoves[position.Row, position.Column] = true;
            }

            position.SetValue(Position.Row - 2, Position.Column - 1);
            if (Board.ValidatePosition(position) && CanMove(position))
            {
                possibleMoves[position.Row, position.Column] = true;
            }

            position.SetValue(Position.Row - 2, Position.Column + 1);
            if (Board.ValidatePosition(position) && CanMove(position))
            {
                possibleMoves[position.Row, position.Column] = true;
            }

            position.SetValue(Position.Row - 1, Position.Column + 2);
            if (Board.ValidatePosition(position) && CanMove(position))
            {
                possibleMoves[position.Row, position.Column] = true;
            }

            position.SetValue(Position.Row + 1, Position.Column + 2);
            if (Board.ValidatePosition(position) && CanMove(position))
            {
                possibleMoves[position.Row, position.Column] = true;
            }

            position.SetValue(Position.Row + 2, Position.Column + 1);
            if (Board.ValidatePosition(position) && CanMove(position))
            {
                possibleMoves[position.Row, position.Column] = true;
            }

            position.SetValue(Position.Row + 2, Position.Column - 1);
            if (Board.ValidatePosition(position) && CanMove(position))
            {
                possibleMoves[position.Row, position.Column] = true;
            }

            position.SetValue(Position.Row + 1, Position.Column - 2);
            if (Board.ValidatePosition(position) && CanMove(position))
            {
                possibleMoves[position.Row, position.Column] = true;
            }

            return possibleMoves;
        }
    }
}
