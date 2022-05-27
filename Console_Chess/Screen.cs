using Chessboard;
using Chess;

namespace Console_Chess
{
    internal class Screen
    {

        public static void PrintChessGame(ChessGame chessGame)
        {
            PrintBoard(chessGame.Board);
            Console.WriteLine();
            PrintCapturedPieces(chessGame);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine($"Turn: {chessGame.Turn}");
            Console.WriteLine($"Waiting player: {chessGame.CurrentPlayer}");
            if (chessGame.Check)
            {
                Console.WriteLine("Check!");
            }
        }

        public static void PrintCapturedPieces(ChessGame chessGame)
        {
            Console.WriteLine("Captured Pieces:");
            Console.Write("Cyan: ");
            ConsoleColor consoleColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Cyan;
            PrintCapturedSet(chessGame.CapturedPieces(Color.Cyan));
            Console.ForegroundColor = consoleColor;
            Console.WriteLine();

            Console.Write("Magenta: ");            
            Console.ForegroundColor = ConsoleColor.Magenta;
            PrintCapturedSet(chessGame.CapturedPieces(Color.Magenta));
            Console.ForegroundColor = consoleColor;
            Console.WriteLine();
        }

        public static void PrintCapturedSet(HashSet<Piece> capturedSet)
        {
            Console.Write("[");
            foreach (Piece piece in capturedSet)
            {
                Console.Write($"{piece} ");
            }
            Console.Write("]");
        }

        public static void PrintBoard(Board board)
        {
            for (int i = 0; i < board.Rows; i++)
            {
                Console.Write($"{8 - i} ");

                for (int j = 0; j < board.Columns; j++)
                {
                    PrintPiece(board.Piece(i, j));
                }

                Console.WriteLine();
            }

            Console.WriteLine("+  A  B  C  D  E  F  G  H");
        }

        public static void PrintBoard(Board board, bool[,] possibleMoves)
        {
            ConsoleColor defaultBackground = Console.BackgroundColor;
            ConsoleColor newBackground = ConsoleColor.DarkGray;

            for (int i = 0; i < board.Rows; i++)
            {
                Console.Write($"{8 - i} ");

                for (int j = 0; j < board.Columns; j++)
                {
                    if (possibleMoves[i, j])
                    {
                        Console.BackgroundColor = newBackground;
                    }
                    else
                    {
                        Console.BackgroundColor = defaultBackground;
                    }

                    PrintPiece(board.Piece(i, j));

                    Console.BackgroundColor = defaultBackground;
                }

                Console.WriteLine();
            }

            Console.WriteLine("+  A  B  C  D  E  F  G  H");

            Console.BackgroundColor = defaultBackground;
        }

        public static PiecePosition InputPiecePosition()
        {
            string piecePosition = Console.ReadLine().ToLower();
            char column = piecePosition[0];
            int row = int.Parse($"{piecePosition[1]}");
            return new PiecePosition(column, row);
        }

        public static void PrintPiece(Piece piece)
        {

            if (piece == null)
            {
                Console.Write(" - ");
            }
            else
            {
                if (piece.Color == Color.White)
                {
                    ConsoleColor consoleColor = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write($" {piece} ");
                    Console.ForegroundColor = consoleColor;
                }
                else if (piece.Color == Color.Yellow)
                {
                    ConsoleColor consoleColor = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write($" {piece} ");
                    Console.ForegroundColor = consoleColor;
                }
                else if (piece.Color == Color.Cyan)
                {
                    ConsoleColor consoleColor = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write($" {piece} ");
                    Console.ForegroundColor = consoleColor;
                }
                else if (piece.Color == Color.Red)
                {
                    ConsoleColor consoleColor = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write($" {piece} ");
                    Console.ForegroundColor = consoleColor;
                }
                else if (piece.Color == Color.Green)
                {
                    ConsoleColor consoleColor = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write($" {piece} ");
                    Console.ForegroundColor = consoleColor;
                }
                else
                {
                    ConsoleColor consoleColor = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Write($" {piece} ");
                    Console.ForegroundColor = consoleColor;
                }
            }
        }
    }
}
