using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Pieces
{
    internal class Rook : Piece
    {
        public Rook(PieceColor color) : base(color, PieceType.Rook)
        {
        }

        public override string CalculateLegalMoves()
        {
            throw new NotImplementedException();
        }
    }
}
