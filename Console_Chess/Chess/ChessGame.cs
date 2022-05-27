using Chessboard;

namespace Chess
{
    internal class ChessGame
    {
        public Board Board { get; private set; }
        public int Turn { get; private set; }
        public Color CurrentPlayer { get; private set; }
        public bool GameOver { get; private set; }
        public bool Check { get; private set; }
        public Piece VunerableEnPassant { get; private set; }
        private HashSet<Piece> Pieces;
        private HashSet<Piece> Captured;

        public ChessGame()
        {
            Board = new Board(8, 8);
            Turn = 1;
            CurrentPlayer = Color.Cyan;
            GameOver = false;
            Check = false;
            VunerableEnPassant = null;
            Pieces = new HashSet<Piece>();
            Captured = new HashSet<Piece>();
            PutPieces();
        }

        public Piece ExecuteMovement(Position source, Position destiny)
        {
            Piece piece = Board.RemovePiece(source);

            piece.IncreaseNumMoves();

            Piece capturedPiece = Board.RemovePiece(destiny);

            Board.InsertPiece(piece, destiny);

            if (capturedPiece != null)
            {
                Captured.Add(capturedPiece);
            }

            // #SpecialMove 'Short Castling'
            if (piece is King && destiny.Column == source.Column + 2)
            {
                Position rookSource = new Position(source.Row, source.Column + 3);
                Position rookDestiny = new Position(source.Row, source.Column + 1);

                Piece rook = Board.RemovePiece(rookSource);
                rook.IncreaseNumMoves();
                Board.InsertPiece(rook, rookDestiny);
            }

            // #SpecialMove 'Long Castling'
            if (piece is King && destiny.Column == source.Column - 2)
            {
                Position rookSource = new Position(source.Row, source.Column - 4);
                Position rookDestiny = new Position(source.Row, source.Column - 1);

                Piece rook = Board.RemovePiece(rookSource);
                rook.IncreaseNumMoves();
                Board.InsertPiece(rook, rookDestiny);
            }

            // #SpecialMove 'En Passant'
            if (piece is Pawn)
            {
                if (source.Column != destiny.Column && capturedPiece == null)
                {
                    Position pawn;

                    if (piece.Color == Color.Cyan)
                    {
                        pawn = new Position(destiny.Row + 1, destiny.Column);
                    }
                    else
                    {
                        pawn = new Position(destiny.Row - 1, destiny.Column);
                    }

                    capturedPiece = Board.RemovePiece(pawn);

                    Captured.Add(capturedPiece);
                }
            }

            return capturedPiece;
        }

        public void RollbackMove(Position source, Position destiny, Piece capturedPiece)
        {
            Piece piece = Board.RemovePiece(destiny);

            piece.DecreaseNumMoves();

            if (capturedPiece != null)
            {
                Board.InsertPiece(capturedPiece, destiny);

                Captured.Remove(capturedPiece);
            }

            Board.InsertPiece(piece, source);

            // #SpecialMove 'Short Castling'
            if (piece is King && destiny.Column == source.Column + 2)
            {
                Position rookSource = new Position(source.Row, source.Column + 3);
                Position rookDestiny = new Position(source.Row, source.Column + 1);

                Piece rook = Board.RemovePiece(rookDestiny);
                rook.DecreaseNumMoves();
                Board.InsertPiece(rook, rookSource);
            }

            // #SpecialMove 'Long Castling'
            if (piece is King && destiny.Column == source.Column - 2)
            {
                Position rookSource = new Position(source.Row, source.Column - 4);
                Position rookDestiny = new Position(source.Row, source.Column - 1);

                Piece rook = Board.RemovePiece(rookDestiny);
                rook.DecreaseNumMoves();
                Board.InsertPiece(rook, rookSource);
            }

            // #SpecialMove 'En Passant'
            if (piece is Pawn)
            {
                if (source.Column != destiny.Column && capturedPiece == VunerableEnPassant)
                {
                    Piece unrollPawn = Board.RemovePiece(destiny);

                    Position pawnPosition;

                    if (unrollPawn.Color == Color.Cyan)
                    {
                        pawnPosition = new Position(3, destiny.Column);
                    }
                    else
                    {
                        pawnPosition = new Position(4, destiny.Column);
                    }

                    Board.InsertPiece(unrollPawn, pawnPosition);
                }
            }

        }

        public void ExecutePlay(Position source, Position destiny)
        {
            Piece capturedPiece = ExecuteMovement(source, destiny);

            if (ValidateCheck(CurrentPlayer))
            {
                RollbackMove(source, destiny, capturedPiece);

                throw new BoardExceptions("Illegal move... Your king will be in check mode!");
            }

            Piece piece = Board.Piece(destiny);

            // #SpecialMove 'Promotion'
            if (piece is Pawn)
            {
                if (piece.Color == Color.Cyan && destiny.Row == 0 || piece.Color == Color.Magenta && destiny.Row == 7)
                {
                    piece = Board.RemovePiece(destiny);
                    Pieces.Remove(piece);

                    Piece queen = new Queen(Board, piece.Color);
                    Board.InsertPiece(queen, destiny);

                    Pieces.Add(queen);
                }
            }


            if (ValidateCheck(Opponent(CurrentPlayer)))
            {
                Check = true;
            }
            else
            {
                Check = false;
            }

            if (ValidateCheckmate(Opponent(CurrentPlayer)))
            {
                GameOver = true;
            }
            else
            {
                Turn++;
                ChangePlayer();
            }


            // #SpecialMove En Passant            

            if (piece is Pawn && (destiny.Row == source.Row - 2 || destiny.Row == source.Row + 2))
            {
                VunerableEnPassant = piece;
            }
            else
            {
                VunerableEnPassant = null;
            }

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

        public HashSet<Piece> CapturedPieces(Color color)
        {
            HashSet<Piece> captPieces = new HashSet<Piece>();

            foreach (Piece piece in Captured)
            {
                if (piece.Color == color)
                {
                    captPieces.Add(piece);
                }
            }

            return captPieces;
        }

        public HashSet<Piece> InGamePieces(Color color)
        {
            HashSet<Piece> inGamePieces = new HashSet<Piece>();

            foreach (Piece piece in Pieces)
            {
                if (piece.Color == color)
                {
                    inGamePieces.Add(piece);
                }
            }

            inGamePieces.ExceptWith(CapturedPieces(color));

            return inGamePieces;
        }

        private Color Opponent(Color color)
        {
            if (color == Color.Cyan)
            {
                return Color.Magenta;
            }
            else
            {
                return Color.Cyan;
            }
        }

        private Piece ValidateKing(Color color)
        {
            foreach (Piece piece in InGamePieces(color))
            {
                if (piece is King)
                {
                    return piece;
                }
            }

            return null;
        }

        public bool ValidateCheck(Color color)
        {
            Piece king = ValidateKing(color);
            if (king == null)
            {
                throw new BoardExceptions($"King {king} was not found in this board!");
            }

            foreach (Piece piece in InGamePieces(Opponent(color)))
            {
                bool[,] validadeCheck = piece.PossibleMoves();

                if (validadeCheck[king.Position.Row, king.Position.Column])
                {
                    return true;
                }
            }

            return false;
        }

        public bool ValidateCheckmate(Color color)
        {
            if (!ValidateCheck(color))
            {
                return false;
            }

            foreach (Piece piece in InGamePieces(color))
            {
                bool[,] validadeCheckmate = piece.PossibleMoves();
                for (int i = 0; i < Board.Rows; i++)
                {
                    for (int j = 0; j < Board.Columns; j++)
                    {
                        if (validadeCheckmate[i, j])
                        {
                            Position source = piece.Position;
                            Position destiny = new Position(i, j);
                            Piece caturedPiece = ExecuteMovement(source, destiny);
                            bool validadeCheck = ValidateCheck(color);
                            RollbackMove(source, destiny, caturedPiece);
                            if (!validadeCheck)
                            {
                                return false;
                            }
                        }
                    }
                }
            }

            return true;
        }

        public void InsertNewPiece(char column, int row, Piece piece)
        {
            Board.InsertPiece(piece, new PiecePosition(column, row).ToPiecePosition());
            Pieces.Add(piece);
        }

        private void PutPieces()
        {
            InsertNewPiece('a', 1, new Rook(Board, Color.Cyan));
            InsertNewPiece('b', 1, new Knight(Board, Color.Cyan));
            InsertNewPiece('c', 1, new Bishop(Board, Color.Cyan));
            InsertNewPiece('d', 1, new Queen(Board, Color.Cyan));
            InsertNewPiece('e', 1, new King(Board, Color.Cyan, this));
            InsertNewPiece('f', 1, new Bishop(Board, Color.Cyan));
            InsertNewPiece('g', 1, new Knight(Board, Color.Cyan));
            InsertNewPiece('h', 1, new Rook(Board, Color.Cyan));
            InsertNewPiece('a', 2, new Pawn(Board, Color.Cyan, this));
            InsertNewPiece('b', 2, new Pawn(Board, Color.Cyan, this));
            InsertNewPiece('c', 2, new Pawn(Board, Color.Cyan, this));
            InsertNewPiece('d', 2, new Pawn(Board, Color.Cyan, this));
            InsertNewPiece('e', 2, new Pawn(Board, Color.Cyan, this));
            InsertNewPiece('f', 2, new Pawn(Board, Color.Cyan, this));
            InsertNewPiece('g', 2, new Pawn(Board, Color.Cyan, this));
            InsertNewPiece('h', 2, new Pawn(Board, Color.Cyan, this));

            InsertNewPiece('a', 8, new Rook(Board, Color.Magenta));
            InsertNewPiece('b', 8, new Knight(Board, Color.Magenta));
            InsertNewPiece('c', 8, new Bishop(Board, Color.Magenta));
            InsertNewPiece('d', 8, new Queen(Board, Color.Magenta));
            InsertNewPiece('e', 8, new King(Board, Color.Magenta, this));
            InsertNewPiece('f', 8, new Bishop(Board, Color.Magenta));
            InsertNewPiece('g', 8, new Knight(Board, Color.Magenta));
            InsertNewPiece('h', 8, new Rook(Board, Color.Magenta));
            InsertNewPiece('a', 7, new Pawn(Board, Color.Magenta, this));
            InsertNewPiece('b', 7, new Pawn(Board, Color.Magenta, this));
            InsertNewPiece('c', 7, new Pawn(Board, Color.Magenta, this));
            InsertNewPiece('d', 7, new Pawn(Board, Color.Magenta, this));
            InsertNewPiece('e', 7, new Pawn(Board, Color.Magenta, this));
            InsertNewPiece('f', 7, new Pawn(Board, Color.Magenta, this));
            InsertNewPiece('g', 7, new Pawn(Board, Color.Magenta, this));
            InsertNewPiece('h', 7, new Pawn(Board, Color.Magenta, this));


        }
    }
}
