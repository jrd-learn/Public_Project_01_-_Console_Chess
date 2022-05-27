using Chessboard;

namespace Chess
{
    internal class Pawn : Piece
    {
        private ChessGame chessGame;
        public Pawn(Board board, Color color, ChessGame chessGame) : base(board, color)
        {
            this.chessGame = chessGame;
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

                // # SpecialMove En Passant
                if (Position.Row == 3)
                {
                    Position leftSide = new Position(Position.Row, Position.Column - 1);

                    if (Board.ValidatePosition(leftSide) && ValidateOpposite(leftSide) && Board.Piece(leftSide) == chessGame.VunerableEnPassant)
                    {
                        possibleMoves[leftSide.Row - 1, leftSide.Column] = true;
                    }

                    Position rightSide = new Position(Position.Row, Position.Column + 1);

                    if (Board.ValidatePosition(rightSide) && ValidateOpposite(rightSide) && Board.Piece(rightSide) == chessGame.VunerableEnPassant)
                    {
                        possibleMoves[rightSide.Row - 1, rightSide.Column] = true;
                    }
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

                // # SpecialMove En Passant
                if (Position.Row == 4)
                {
                    Position leftSide = new Position(Position.Row, Position.Column - 1);

                    if (Board.ValidatePosition(leftSide) && ValidateOpposite(leftSide) && Board.Piece(leftSide) == chessGame.VunerableEnPassant)
                    {
                        possibleMoves[leftSide.Row + 1, leftSide.Column] = true;
                    }

                    Position rightSide = new Position(Position.Row, Position.Column + 1);

                    if (Board.ValidatePosition(rightSide) && ValidateOpposite(rightSide) && Board.Piece(rightSide) == chessGame.VunerableEnPassant)
                    {
                        possibleMoves[rightSide.Row + 1, rightSide.Column] = true;
                    }
                }
            }
            

            return possibleMoves;
        }
    }
}
