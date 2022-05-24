using System;
using System.Globalization;
using Chessboard;

namespace Console_Chess
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Position P;
            P = new Position(3, 4);

            Console.WriteLine($"Posição: {P}");
        }
    }
}