using Chessboard;
using Chess;

namespace Console_Chess
{
    internal class Screen
    {
        public static void PrintBoard(Board board)
        {
            for (int i = 0; i < board.Rows; i++)
            {
                Console.Write($"{8 - i}  ");

                for (int j = 0; j < board.Columns; j++)
                {
                    if (board.Piece(i, j) == null)
                    {
                        Console.Write("- ");
                    }
                    else
                    {
                        Screen.PrintPiece(board.Piece(i, j));
                    }
                }

                Console.WriteLine();
            }

            Console.WriteLine("+  A B C D E F G H");
        }

        public static PiecePosition InputPiecePosition()
        {
            string piecePosition = Console.ReadLine();
            char column = piecePosition[0];
            int row = int.Parse($"{piecePosition[1]}");
            return new PiecePosition(column, row);
        }

        public static void PrintPiece(Piece piece)
        {
            if (piece.Color == Color.White)
            {
                ConsoleColor consoleColor = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(piece);
                Console.ForegroundColor = consoleColor;
            }
            else if (piece.Color == Color.Yellow)
            {
                ConsoleColor consoleColor = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(piece);
                Console.ForegroundColor = consoleColor;
            }
            else if (piece.Color == Color.Cyan)
            {
                ConsoleColor consoleColor = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write(piece);
                Console.ForegroundColor = consoleColor;
            }
            else if (piece.Color == Color.Red)
            {
                ConsoleColor consoleColor = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(piece);
                Console.ForegroundColor = consoleColor;
            }
            else if (piece.Color == Color.Green)
            {
                ConsoleColor consoleColor = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(piece);
                Console.ForegroundColor = consoleColor;
            }
            else 
            {
                ConsoleColor consoleColor = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write(piece);
                Console.ForegroundColor = consoleColor;
            }
        }
    }
}
