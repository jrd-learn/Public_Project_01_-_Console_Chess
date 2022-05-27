using Chessboard;

namespace Chess
{
    internal class King : Piece
    {
        private readonly ChessGame chessGame;
        public King(Board board, Color color, ChessGame chessGame) : base(board, color)
        {
            this.chessGame = chessGame;
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

        public bool ValidateRookForCastling(Position position)
        {
            Piece piece = Board.Piece(position);

            return piece != null && piece is Rook && piece.Color == Color && piece.NumMoves == 0;
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

            // #Specialmove 'castling'

            if (NumMoves == 0 && !chessGame.Check)
            {
                Position rightRookPosititon = new Position(Position.Row, Position.Column + 3);

                if (ValidateRookForCastling(rightRookPosititon)) // short castling
                {
                    Position position1 = new Position(Position.Row, Position.Column + 1);
                    Position position2 = new Position(Position.Row, Position.Column + 2);

                    if (Board.Piece(position1) == null && Board.Piece(position2) == null)
                    {
                        possibleMoves[Position.Row, Position.Column + 2] = true;
                    }
                }

                Position leftRookPosititon = new Position(Position.Row, Position.Column - 4);

                if (ValidateRookForCastling(leftRookPosititon)) // Long castling
                {
                    Position position1 = new Position(Position.Row, Position.Column - 1);
                    Position position2 = new Position(Position.Row, Position.Column - 2);
                    Position position3 = new Position(Position.Row, Position.Column - 3);

                    if (Board.Piece(position1) == null && Board.Piece(position2) == null && Board.Piece(position3) == null)
                    {
                        possibleMoves[Position.Row, Position.Column - 2] = true;
                    }
                }
            }

            return possibleMoves;
        }
    }
}
