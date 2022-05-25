using System;
using Chessboard;

namespace Chess
{
    internal class ChessGame
    {
        public Board Board { get; private set; }
        private int Turn;
        private Color CurrentPlayer;
        public bool GameOver { get; private set; }

        public ChessGame()
        {
            Board = new Board(8, 8);
            Turn = 1;
            CurrentPlayer = Color.White;
            GameOver = false;
            PutPieces();
        }

        public void ExecuteMovement(Position source, Position destiny)
        {
            Piece piece = Board.RemovePiece(source);

            piece.IncreaseNumMoves();

            Piece pieceCapturated = Board.RemovePiece(destiny);

            Board.InsertPiece(piece, destiny);
        }

        private void PutPieces()
        {
            Board.InsertPiece(new Rook(Board, Color.White), new PiecePosition('a', 1).ToPiecePosition());
            Board.InsertPiece(new Knight(Board, Color.White), new PiecePosition('b', 1).ToPiecePosition());
            Board.InsertPiece(new Bishop(Board, Color.White), new PiecePosition('c', 1).ToPiecePosition());
            Board.InsertPiece(new Queen(Board, Color.White), new PiecePosition('d', 1).ToPiecePosition());
            Board.InsertPiece(new King(Board, Color.White), new PiecePosition('e', 1).ToPiecePosition());
            Board.InsertPiece(new Bishop(Board, Color.White), new PiecePosition('f', 1).ToPiecePosition());
            Board.InsertPiece(new Knight(Board, Color.White), new PiecePosition('g', 1).ToPiecePosition());
            Board.InsertPiece(new Rook(Board, Color.White), new PiecePosition('h', 1).ToPiecePosition());

            Board.InsertPiece(new Rook(Board, Color.Magenta), new PiecePosition('a', 8).ToPiecePosition());
            Board.InsertPiece(new Knight(Board, Color.Magenta), new PiecePosition('b', 8).ToPiecePosition());
            Board.InsertPiece(new Bishop(Board, Color.Magenta), new PiecePosition('c', 8).ToPiecePosition());
            Board.InsertPiece(new Queen(Board, Color.Magenta), new PiecePosition('d', 8).ToPiecePosition());
            Board.InsertPiece(new King(Board, Color.Magenta), new PiecePosition('e', 8).ToPiecePosition());
            Board.InsertPiece(new Bishop(Board, Color.Magenta), new PiecePosition('f', 8).ToPiecePosition());
            Board.InsertPiece(new Knight(Board, Color.Magenta), new PiecePosition('g', 8).ToPiecePosition());
            Board.InsertPiece(new Rook(Board, Color.Magenta), new PiecePosition('h', 8).ToPiecePosition());
        }
    }
}
