using Chessboard;
using ChessPieces;

namespace Console_Chess
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Board board = new Board(8, 8);

                board.InputPiece(new Rook(board, Color.Magenta), new Position(0, 1));
                board.InputPiece(new Rook(board, Color.Magenta), new Position(0, 2));
                board.InputPiece(new King(board, Color.Magenta), new Position(0, 3));
                
                board.InputPiece(new King(board, Color.Cyan), new Position(7, 1));
                board.InputPiece(new King(board, Color.Cyan), new Position(7, 2));
                board.InputPiece(new King(board, Color.Cyan), new Position(7, 3));

                Screen.PrintBoard(board);
            }
            catch (BoardExceptions e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
        }
    }
}