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

        public void InputPiece(Piece piece, Position position)
        {
            pieces[position.Row, position.Column] = piece;

            piece.Position = position;
        }

    }
}
