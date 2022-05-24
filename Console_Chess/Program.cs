using Chessboard;

namespace Console_Chess
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Board board = new Board(8, 8);

            Screen.PrintBoard(board);

            Console.ReadLine();
        }
    }
}