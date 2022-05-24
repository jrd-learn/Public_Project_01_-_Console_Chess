namespace Chessboard
{
    internal class Board
    {
        public int Rows { get; set; }
        public int Columns { get; set; }
        private Piece[,] pieces;

        public Board(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;
            pieces = new Piece[rows, columns];
        }

        public Piece Piece(int row, int column)
        {
            return pieces[row, column];
        }

        public Piece Piece(Position position)
        {
            return pieces[position.Row, position.Column];
        }

        public bool CheckPiece(Position position)
        {
            ValidatePositionException(position);

            return Piece(position) != null;
        }

        public void InputPiece(Piece piece, Position position)
        {
            if (CheckPiece(position){
                throw new BoardExceptions("There is already a piece in this position!");
            }

            pieces[position.Row, position.Column] = piece;

            piece.Position = position;
        }

        public bool ValidatePosition(Position position)
        {
            if (position.Row < 0 || position.Row >= Rows || position.Column < 0 || position.Column >= Columns)
            {
                return false;
            }

            return true;
        }

        public void ValidatePositionException(Position position)
        {
            if (!ValidatePosition(position))
            {
                throw new BoardExceptions("Invalid position!");
            }
        }
    }
}
