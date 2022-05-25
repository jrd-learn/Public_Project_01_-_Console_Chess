using Chessboard;
using Chess;

namespace Console_Chess
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ChessGame chessGame = new ChessGame();

                while (!chessGame.GameOver)
                {
                    Console.Clear();
                    Screen.PrintBoard(chessGame.Board);
                    
                    Console.WriteLine();
                    Console.Write("Source: ");
                    Position source = Screen.InputPiecePosition().ToPiecePosition();
                    Console.Write("Destiny: ");
                    Position destiny = Screen.InputPiecePosition().ToPiecePosition();

                    chessGame.ExecuteMovement(source, destiny);
                }                
            }
            catch (BoardExceptions e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
        }
    }
}