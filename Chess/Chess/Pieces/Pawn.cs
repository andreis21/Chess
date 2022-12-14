using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Pieces
{
    internal class Pawn : Piece
    {
        public Pawn(PieceColor color) : base(color)
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

            if(board.playerMove == PlayerType.Human)
            {
                if(distanceUp >= 1)
                {
                    int nextPoition = position - 8;
                    if (boardString[nextPoition] == '0')
                    {
                        legalMoves.Add($"{y},{x}|{distanceUp - 1},{distanceLeft}");
                    }
                    if (distanceLeft >= 2)
                    {
                        if (distanceRight >= 2)
                        {
                            nextPoition = position - 7;
                            if (boardString[nextPoition] != '0')
                            {
                                if (this.color == PieceColor.White)
                                {
                                    if (char.IsLower(boardString[nextPoition]))
                                    {
                                        legalMoves.Add($"{y},{x}|{distanceUp - 1},{distanceLeft + 1}");
                                    }
                                }
                                else
                                {
                                    if (char.IsUpper(boardString[nextPoition]))
                                    {
                                        legalMoves.Add($"{y},{x}|{distanceUp - 1},{distanceLeft + 1}");
                                    }
                                }
                            }
                            nextPoition = position - 9;
                            if (boardString[nextPoition] != '0')
                            {
                                if (this.color == PieceColor.White)
                                {
                                    if (char.IsLower(boardString[nextPoition]))
                                    {
                                        legalMoves.Add($"{y},{x}|{distanceUp - 1},{distanceLeft - 1}");
                                    }
                                }
                                else
                                {
                                    if (char.IsUpper(boardString[nextPoition]))
                                    {
                                        legalMoves.Add($"{y},{x}|{distanceUp - 1},{distanceLeft - 1}");
                                    }
                                }
                            }
                        }
                        else
                        {
                            nextPoition = position - 9;
                            if (boardString[nextPoition] != '0')
                            {
                                if (this.color == PieceColor.White)
                                {
                                    if (char.IsLower(boardString[nextPoition]))
                                    {
                                        legalMoves.Add($"{y},{x}|{distanceUp - 1},{distanceLeft - 1}");
                                    }
                                }
                                else
                                {
                                    if (char.IsUpper(boardString[nextPoition]))
                                    {
                                        legalMoves.Add($"{y},{x}|{distanceUp - 1},{distanceLeft - 1}");
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        nextPoition = position - 7;
                        if (boardString[nextPoition] != '0')
                        {
                            if (this.color == PieceColor.White)
                            {
                                if (char.IsLower(boardString[nextPoition]))
                                {
                                    legalMoves.Add($"{y},{x}|{distanceUp - 1},{distanceLeft + 1}");
                                }
                            }
                            else
                            {
                                if (char.IsUpper(boardString[nextPoition]))
                                {
                                    legalMoves.Add($"{y},{x}|{distanceUp - 1},{distanceLeft + 1}");
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                if(distanceDown >= 1)
                {
                    int nextPoition = position + 8;
                    if (boardString[nextPoition] == '0')
                    {
                        legalMoves.Add($"{y},{x}|{distanceUp + 1},{distanceLeft}");
                    }
                    if (distanceLeft >= 2)
                    {
                        if (distanceRight >= 2)
                        {
                            nextPoition = position + 9;
                            if (boardString[nextPoition] != '0')
                            {
                                if (this.color == PieceColor.White)
                                {
                                    if (char.IsLower(boardString[nextPoition]))
                                    {
                                        legalMoves.Add($"{y},{x}|{distanceUp + 1},{distanceLeft + 1}");
                                    }
                                }
                                else
                                {
                                    if (char.IsUpper(boardString[nextPoition]))
                                    {
                                        legalMoves.Add($"{y},{x}|{distanceUp + 1},{distanceLeft + 1}");
                                    }
                                }
                            }
                            nextPoition = position + 7;
                            if (boardString[nextPoition] != '0')
                            {
                                if (this.color == PieceColor.White)
                                {
                                    if (char.IsLower(boardString[nextPoition]))
                                    {
                                        legalMoves.Add($"{y},{x}|{distanceUp + 1},{distanceLeft - 1}");
                                    }
                                }
                                else
                                {
                                    if (char.IsUpper(boardString[nextPoition]))
                                    {
                                        legalMoves.Add($"{y},{x}|{distanceUp + 1},{distanceLeft - 1}");
                                    }
                                }
                            }
                        }
                        else
                        {
                            nextPoition = position + 7;
                            if (boardString[nextPoition] != '0')
                            {
                                if (this.color == PieceColor.White)
                                {
                                    if (char.IsLower(boardString[nextPoition]))
                                    {
                                        legalMoves.Add($"{y},{x}|{distanceUp + 1},{distanceLeft - 1}");
                                    }
                                }
                                else
                                {
                                    if (char.IsUpper(boardString[nextPoition]))
                                    {
                                        legalMoves.Add($"{y},{x}|{distanceUp + 1},{distanceLeft - 1}");
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        nextPoition = position + 9;
                        if (boardString[nextPoition] != '0')
                        {
                            if (this.color == PieceColor.White)
                            {
                                if (char.IsLower(boardString[nextPoition]))
                                {
                                    legalMoves.Add($"{y},{x}|{distanceUp + 1},{distanceLeft + 1}");
                                }
                            }
                            else
                            {
                                if (char.IsUpper(boardString[nextPoition]))
                                {
                                    legalMoves.Add($"{y},{x}|{distanceUp + 1},{distanceLeft + 1}");
                                }
                            }
                        }
                    }
                }
            }

            return legalMoves;
        }
    }
}
