using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Pieces
{
    internal class Pawn : Piece
    {
        public Pawn(int x, int y, PieceColor color) : base(x, y, color, PieceType.Pawn)
        {
        }

        public override string CalculateLegalMoves()
        {
            throw new NotImplementedException();
        }
    }
}
