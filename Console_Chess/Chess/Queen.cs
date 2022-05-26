using Chessboard;

namespace Chess
{
    internal class Queen : Piece
    {
        public Queen(Board board, Color color) : base(board, color)
        {
        }

        public override string ToString()
        {
            return "Q";
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

            //North-East
            position.SetValue(Position.Row - 1, Position.Column + 1);
            while (Board.ValidatePosition(position) && CanMove(position))
            {
                possibleMoves[position.Row, position.Column] = true;

                if (Board.Piece(position) != null && Board.Piece(position).Color != Color)
                {
                    break;
                }

                position.Row--;                
                position.Column++;
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

            //South-East
            position.SetValue(Position.Row + 1, Position.Column + 1);
            while (Board.ValidatePosition(position) && CanMove(position))
            {
                possibleMoves[position.Row, position.Column] = true;

                if (Board.Piece(position) != null && Board.Piece(position).Color != Color)
                {
                    break;
                }

                position.Row++;
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

            //South-West
            position.SetValue(Position.Row + 1, Position.Column - 1);
            while (Board.ValidatePosition(position) && CanMove(position))
            {
                possibleMoves[position.Row, position.Column] = true;

                if (Board.Piece(position) != null && Board.Piece(position).Color != Color)
                {
                    break;
                }

                position.Row++;
                position.Column--;
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

            //North-West
            position.SetValue(Position.Row - 1, Position.Column - 1);
            while (Board.ValidatePosition(position) && CanMove(position))
            {
                possibleMoves[position.Row, position.Column] = true;

                if (Board.Piece(position) != null && Board.Piece(position).Color != Color)
                {
                    break;
                }

                position.Row--;
                position.Column--;
            }

            return possibleMoves;
        }
    }
}
