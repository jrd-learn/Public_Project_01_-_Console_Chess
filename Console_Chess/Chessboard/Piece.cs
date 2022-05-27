namespace Chessboard
{
    internal abstract class Piece
    {
        public Position Position { get; set; }
        public Color Color { get; protected set; }
        public int NumMoves { get; protected set; }
        public Board Board { get; protected set; }

        public Piece(Board board, Color color)
        {
            Position = null;
            Board = board;
            Color = color;
            NumMoves = 0;
        }

        public void IncreaseNumMoves()
        {
            NumMoves++;
        }
        public void DecreaseNumMoves()
        {
            NumMoves--;
        }

        public bool CheckPossibleMoves()
        {
            bool[,] checkPossibleMoves = PossibleMoves();

            for (int i = 0; i < Board.Rows; i++)
            {
                for (int j = 0; j < Board.Columns; j++)
                {
                    if (checkPossibleMoves[i, j])
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public bool CanMoveTo(Position position)
        {
            return PossibleMoves()[position.Row, position.Column];
        }

        public abstract bool[,] PossibleMoves();
        
    }
}
