using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Pieces
{
    internal class Rook : Piece
    {
        public Rook(PieceColor color) : base(color)
        {
        }

        public override List<string> CalculateLegalMoves()
        {
            List<string> legalMoves = new List<string>();
            Board board = Board.GetInstance();
            var boardString = board.StringifyBoard();
            int position = 8 * this.y + this.x;
            int distanceUp = Math.Abs(0 - this.y);
            int distanceDown = Math.Abs(7 - this.y);
            int distanceLeft = Math.Abs(0 - this.x);
            int distanceRight = Math.Abs(7 - this.x);
            for(int i = 1; i <= distanceUp; i++)
            {
                if(position - i * 8 < 0)
                {
                    break;
                }
                if(boardString[position - i * 8] != '0')
                {
                    if(this.color == PieceColor.White)
                    {
                        if(char.IsLower(boardString[position - i * 8]))
                        {
                            legalMoves.Add($"{y},{x}|{distanceUp - i},{distanceLeft}");
                        }
                        break;
                    }
                    else
                    {
                        if (char.IsUpper(boardString[position - i * 8]))
                        {
                            legalMoves.Add($"{y},{x}|{distanceUp - i},{distanceLeft}");
                        }
                        break;
                    }
                }
                if (boardString[position - i * 8] == '0')
                {
                    legalMoves.Add($"{y},{x}|{distanceUp - i},{distanceLeft}");
                }
            }
            for(int i = 1; i <= distanceDown; i++)
            {
                if(position + i * 8 > 63)
                {
                    break;
                }
                if (boardString[position + i * 8] != '0')
                {
                    if (this.color == PieceColor.White)
                    {
                        if (char.IsLower(boardString[position + i * 8]))
                        {
                            legalMoves.Add($"{y},{x}|{distanceUp + i},{distanceLeft}");
                        }
                        break;
                    }
                    else
                    {
                        if (char.IsUpper(boardString[position + i * 8]))
                        {
                            legalMoves.Add($"{y},{x}|{distanceUp + i},{distanceLeft}");
                        }
                        break;
                    }
                }
                if (boardString[position + i * 8] == '0')
                {
                    legalMoves.Add($"{y},{x}|{distanceUp + i},{distanceLeft}");
                }
            }
            for(int i = 1; i <= distanceLeft; i++)
            {
                if(position - i < 0)
                {
                    break;
                }
                if (boardString[position - i] != '0')
                {
                    if (this.color == PieceColor.White)
                    {
                        if (char.IsLower(boardString[position - i]))
                        {
                            legalMoves.Add($"{y},{x}|{distanceUp},{distanceLeft - i}");
                        }
                        break;
                    }
                    else
                    {
                        if (char.IsUpper(boardString[position - i]))
                        {
                            legalMoves.Add($"{y},{x}|{distanceUp},{distanceLeft - i}");
                        }
                        break;
                    }
                }
                if (boardString[position - i] == '0')
                {
                    legalMoves.Add($"{y},{x}|{distanceUp},{distanceLeft - i}");
                }
            }
            for(int i = 1; i <= distanceRight; i++)
            {
                if(position + i > 63)
                {
                    break;
                }
                if (boardString[position + i] != '0')
                {
                    if (this.color == PieceColor.White)
                    {
                        if (char.IsLower(boardString[position + i]))
                        {
                            legalMoves.Add($"{y},{x}|{distanceUp},{distanceLeft + i}");
                        }
                        break;
                    }
                    else
                    {
                        if (char.IsUpper(boardString[position + i]))
                        {
                            legalMoves.Add($"{y},{x}|{distanceUp},{distanceLeft + i}");
                        }
                        break;
                    }
                }
                if (boardString[position + i] == '0')
                {
                    legalMoves.Add($"{y},{x}|{distanceUp},{distanceLeft + i}");
                }
            }
            return legalMoves;
        }
    }
}
