using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Pieces
{
    internal class King : Piece
    {
        public King(PieceColor color) : base(color, PieceType.King)
        {
        }

        public override string CalculateLegalMoves()
        {
            throw new NotImplementedException();
        }
    }
}
