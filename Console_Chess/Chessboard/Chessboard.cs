namespace Chessboard
{
    internal class Chessboard
    {
        public int rows { get; set; }
        public int columns { get; set; }
        private Piece[,] piece;

        public Chessboard(int rows, int columns)
        {
            this.rows = rows;
            this.columns = columns;
            piece = new Piece[rows, columns];
        }
    }
}
