using Chessboard;
using ChessPieces;

namespace Console_Chess
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PiecePosition piecePosition = new PiecePosition('c', 7);

            Console.WriteLine(piecePosition);

            Console.WriteLine(piecePosition.ToPiecePosition());
            //try
            //{
            //    Board board = new Board(8, 8);

            //    board.InputPiece(new Rook(board, Color.Black), new Position(0, 0));
            //    board.InputPiece(new Rook(board, Color.Black), new Position(1, 3));
            //    board.InputPiece(new King(board, Color.Black), new Position(2, 4));

            //    Screen.PrintBoard(board);
            //}
            //catch(BoardExceptions e)
            //{
            //    Console.WriteLine(e.Message);
            //}

            Console.ReadLine();
        }
    }
}