using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Pieces
{
    internal class Knight : Piece
    {
        public Knight(int x, int y, PieceColor color) : base(x, y, color, PieceType.Knight)
        {

        }

        public override string CalculateLegalMoves()
        {
            throw new NotImplementedException();
        }
    }
}
