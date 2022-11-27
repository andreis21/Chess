using Chess.Pieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    internal class Board
    {
        private static Board _instance;
        public Cell[,] Cells;
        public PlayerType playerMove { get; set; }

        private Board()
        {
            Cells = new Cell[8, 8];
            for(int i = 0; i < 8; i++)
            {
                for(int j = 0; j < 8; j++)
                {
                    Cells[i, j] = new Cell();
                }
            }
        }

        public static Board GetInstance()
        {
            if (_instance == null)
            {
                _instance = new Board();
            }
            return _instance;
        }

        public void SetupBoardForColor(PieceColor color)
        {
            switch (color)
            {
                case PieceColor.Black:
                    ParseAndSetupBoard("RCBQKBCR/PPPPPPPP/8/8/8/8/pppppppp/rcbqkbcr");
                    break;
                case PieceColor.White:
                    ParseAndSetupBoard("rcbqkbcr/pppppppp/8/8/8/8/PPPPPPPP/RCBQKBCR");
                    break;
            }
        }

        public void ParseAndSetupBoard(string positionsString)
        {
            int row = 0;
            int col = 0;
            foreach(var character in positionsString)
            {
                if (character.Equals('/'))
                {
                    row++;
                    col = 0;
                    continue;
                }
                if (char.IsDigit(character))
                {
                    col += Int16.Parse(character.ToString());
                    continue;
                }
                Piece piece = null;
                switch (character)
                {
                    case 'p':
                        piece = new Pawn(PieceColor.Black);
                        break;
                    case 'P':
                        piece = new Pawn(PieceColor.White);
                        break;
                    case 'c':
                        piece = new Knight(PieceColor.Black);
                        break;
                    case 'C':
                        piece = new Knight(PieceColor.White);
                        break;
                    case 'b':
                        piece = new Bishop(PieceColor.Black);
                        break;
                    case 'B':
                        piece = new Bishop(PieceColor.White);
                        break;
                    case 'r':
                        piece = new Rook(PieceColor.Black);
                        break;
                    case 'R':
                        piece = new Rook(PieceColor.White);
                        break;
                    case 'q':
                        piece = new Queen(PieceColor.Black);
                        break;
                    case 'Q':
                        piece = new Queen(PieceColor.White);
                        break;
                    case 'k':
                        piece = new King(PieceColor.Black);
                        break;
                    case 'K':
                        piece = new King(PieceColor.White);
                        break;
                    default:
                        break;
                }
                piece.x = col;
                piece.y = row;
                Cells[row, col].Piece = piece;
                col++;
            }
        }

        public string StringifyBoard()
        {
            string boardString = string.Empty;
            for(int i = 0; i < 8; i++)
            {
                for(int j = 0; j < 8; j++)
                {
                    if (Cells[i, j].Piece != null)
                    {
                        if (Cells[i, j].Piece.GetType().Name.Equals("Knight") || Cells[i, j].Piece.GetType().Name.Equals("knight"))
                        {
                            if(Cells[i, j].Piece.color == PieceColor.Black)
                            {
                                boardString += Cells[i, j].Piece.GetType().Name.ToString()[0].ToString().ToLower();
                            }
                            continue;
                        }
                        if (Cells[i, j].Piece.color == PieceColor.Black)
                        {
                            boardString += Cells[i, j].Piece.GetType().Name.ToString()[0].ToString().ToLower();
                            continue;
                        }
                        boardString += Cells[i, j].Piece.GetType().Name.ToString()[0];
                        continue;
                    }
                    boardString += '0';
                }
            }
            return boardString;
        }
    }
}
