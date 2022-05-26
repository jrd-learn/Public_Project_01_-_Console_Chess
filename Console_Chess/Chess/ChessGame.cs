using System;
using Chessboard;

namespace Chess
{
    internal class ChessGame
    {
        public Board Board { get; private set; }
        public int Turn { get; private set; }
        public Color CurrentPlayer { get; private set; }
        public bool GameOver { get; private set; }

        public ChessGame()
        {
            Board = new Board(8, 8);
            Turn = 1;
            CurrentPlayer = Color.Cyan;
            GameOver = false;
            PutPieces();
        }

        public void ExecuteMovement(Position source, Position destiny)
        {
            Piece piece = Board.RemovePiece(source);
            
            Piece pieceCapturated = Board.RemovePiece(destiny);

            Board.InsertPiece(piece, destiny);
        }

        public void ExecutePlay(Position source, Position destiny)
        {
            ExecuteMovement(source, destiny);
            Turn++;
            ChangePlayer();
        }

        public void ValidateSourcePosition(Position position)
        {
            if (Board.Piece(position) == null)
            {
                throw new BoardExceptions("There is no piece in this source position!");
            }
            if (CurrentPlayer != Board.Piece(position).Color)
            {
                throw new BoardExceptions("The current player is not owner of this piece in source position!");
            }
            if (!Board.Piece(position).CheckPossibleMoves())
            {
                throw new BoardExceptions("There is no moves allowed to this piece in source position!");
            }
        }

        public void ValidateDestinyPosition(Position source, Position destiny)
        {
            if (!Board.Piece(source).CanMoveTo(destiny))
            {
                throw new BoardExceptions("Invalid destiny position!");
            }
        }

        private void ChangePlayer()
        {
            if (CurrentPlayer == Color.Cyan)
            {
                CurrentPlayer = Color.Magenta;
            }
            else
            {
                CurrentPlayer = Color.Cyan;
            }
        }
        private void PutPieces()
        {
            Board.InsertPiece(new Rook(Board, Color.Cyan), new PiecePosition('a', 1).ToPiecePosition());
            Board.InsertPiece(new Knight(Board, Color.Cyan), new PiecePosition('b', 1).ToPiecePosition());
            Board.InsertPiece(new Bishop(Board, Color.Cyan), new PiecePosition('c', 1).ToPiecePosition());
            Board.InsertPiece(new Queen(Board, Color.Cyan), new PiecePosition('d', 1).ToPiecePosition());
            Board.InsertPiece(new King(Board, Color.Cyan), new PiecePosition('e', 1).ToPiecePosition());
            Board.InsertPiece(new Bishop(Board, Color.Cyan), new PiecePosition('f', 1).ToPiecePosition());
            Board.InsertPiece(new Knight(Board, Color.Cyan), new PiecePosition('g', 1).ToPiecePosition());
            Board.InsertPiece(new Rook(Board, Color.Cyan), new PiecePosition('h', 1).ToPiecePosition());

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
