using Chessboard;

namespace Chess
{
    internal class King : Piece
    {
        public King(Board board, Color color) : base(board, color)
        {
        }

        public override string ToString()
        {
            return "K";
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
            if (Board.ValidatePosition(position) && CanMove(position))
            {
                possibleMoves[position.Row, position.Column] = true;
            }
            //North-East	
            position.SetValue(Position.Row - 1, Position.Column + 1);
            if (Board.ValidatePosition(position) && CanMove(position))
            {
                possibleMoves[position.Row, position.Column] = true;
            }
            //East
            position.SetValue(Position.Row, Position.Column + 1);
            if (Board.ValidatePosition(position) && CanMove(position))
            {
                possibleMoves[position.Row, position.Column] = true;
            }
            //South-East
            position.SetValue(Position.Row + 1, Position.Column + 1);
            if (Board.ValidatePosition(position) && CanMove(position))
            {
                possibleMoves[position.Row, position.Column] = true;
            }
            //South
            position.SetValue(Position.Row + 1, Position.Column);
            if (Board.ValidatePosition(position) && CanMove(position))
            {
                possibleMoves[position.Row, position.Column] = true;
            }
            //South-West
            position.SetValue(Position.Row + 1, Position.Column - 1);
            if (Board.ValidatePosition(position) && CanMove(position))
            {
                possibleMoves[position.Row, position.Column] = true;
            }
            //West
            position.SetValue(Position.Row, Position.Column - 1);
            if (Board.ValidatePosition(position) && CanMove(position))
            {
                possibleMoves[position.Row, position.Column] = true;
            }
            //North-West
            position.SetValue(Position.Row - 1, Position.Column - 1);
            if (Board.ValidatePosition(position) && CanMove(position))
            {
                possibleMoves[position.Row, position.Column] = true;
            }

            return possibleMoves;
        }
    }
}
