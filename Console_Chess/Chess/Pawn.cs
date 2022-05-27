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

        private bool ValidateOpposite(Position position)
        {
            Piece piece = Board.Piece(position);

            return piece != null && piece.Color != Color;
        }

        private bool ValidateOppositeIsNull(Position position)
        {
            return Board.Piece(position) == null;
        }

        public override bool[,] PossibleMoves()
        {
            bool[,] possibleMoves = new bool[Board.Rows, Board.Columns];

            Position position = new Position(0, 0);

            //Cyan Player
            if (Color == Color.Cyan)
            {
                position.SetValue(Position.Row - 1, Position.Column);
                if (Board.ValidatePosition(position) && ValidateOppositeIsNull(position))
                {
                    possibleMoves[position.Row, position.Column] = true;
                }

                position.SetValue(Position.Row - 2, Position.Column);
                if (Board.ValidatePosition(position) && ValidateOppositeIsNull(position) && NumMoves == 0)
                {
                    possibleMoves[position.Row, position.Column] = true;
                }

                position.SetValue(Position.Row - 1, Position.Column - 1);
                if (Board.ValidatePosition(position) && ValidateOpposite(position))
                {
                    possibleMoves[position.Row, position.Column] = true;
                }

                position.SetValue(Position.Row - 1, Position.Column + 1);
                if (Board.ValidatePosition(position) && ValidateOpposite(position))
                {
                    possibleMoves[position.Row, position.Column] = true;
                }
            }
            else
            {
                position.SetValue(Position.Row + 1, Position.Column);
                if (Board.ValidatePosition(position) && ValidateOppositeIsNull(position))
                {
                    possibleMoves[position.Row, position.Column] = true;
                }

                position.SetValue(Position.Row + 2, Position.Column);
                if (Board.ValidatePosition(position) && ValidateOppositeIsNull(position) && NumMoves == 0)
                {
                    possibleMoves[position.Row, position.Column] = true;
                }

                position.SetValue(Position.Row + 1, Position.Column - 1);
                if (Board.ValidatePosition(position) && ValidateOpposite(position))
                {
                    possibleMoves[position.Row, position.Column] = true;
                }

                position.SetValue(Position.Row + 1, Position.Column + 1);
                if (Board.ValidatePosition(position) && ValidateOpposite(position))
                {
                    possibleMoves[position.Row, position.Column] = true;
                }
            }
            

            return possibleMoves;
        }
    }
}
