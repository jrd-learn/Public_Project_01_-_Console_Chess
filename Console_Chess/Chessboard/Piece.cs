﻿namespace Chessboard
{
    internal class Piece
    {
        public Position Position { get; set; }
        public Color Color { get; protected set; }
        public int NumMoves { get; protected set; }
        public Board Board { get; protected set; }

        public Piece(Board board, Color color)
        {
            Position = null;
            Board = board;
            Color = color;
            NumMoves = 0;
        }

        public void IncreaseNumMoves()
        {
            NumMoves++;
        }
    }
}
