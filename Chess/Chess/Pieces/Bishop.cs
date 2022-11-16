using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Pieces
{
    internal class Bishop : Piece
    {
        public Bishop(PieceColor color) : base(color, PieceType.Bishop)
        {
        }

        public override string CalculateLegalMoves()
        {
            throw new NotImplementedException();
        }
    }
}
