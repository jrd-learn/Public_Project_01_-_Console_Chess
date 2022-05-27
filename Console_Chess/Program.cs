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
                    try
                    {
                        Console.Clear();
                        Screen.PrintChessGame(chessGame);

                        Console.WriteLine();
                        Console.Write("Source: ");
                        Position source = Screen.InputPiecePosition().ToPiecePosition();
                        chessGame.ValidateSourcePosition(source);

                        bool[,] possibleMoves = chessGame.Board.Piece(source).PossibleMoves();

                        Console.Clear();
                        Screen.PrintBoard(chessGame.Board, possibleMoves);

                        Console.WriteLine();
                        Console.Write("Destiny: ");
                        Position destiny = Screen.InputPiecePosition().ToPiecePosition();
                        chessGame.ValidateDestinyPosition(source, destiny);

                        chessGame.ExecutePlay(source, destiny);
                    }
                    
                    catch (BoardExceptions e)
                    {
                        Console.WriteLine(e.Message);
                        Console.ReadLine();
                    }

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