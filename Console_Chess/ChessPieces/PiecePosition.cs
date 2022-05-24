using Chessboard;

namespace ChessPieces
{
    internal class PiecePosition
    {
        public char Column { get; set; }
        public int Row { get; set; }

        public PiecePosition(char column, int row)
        {
            Column = column;
            Row = row;
        }

        public Position ToPiecePosition()
        {
            return new Position(8 - Row, Column - 'a');
        }

        public override string ToString()
        {
            return $"{Column}{Row}";
        }
    }
}
