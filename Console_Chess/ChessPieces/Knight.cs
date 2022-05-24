using Chessboard;

namespace ChessPieces
{
    internal class Knight : Piece
    {
        public Knight(Board board, Color color) : base(board, color)
        {
        }

        public override string ToString()
        {
            return "C";
        }
    }
}
