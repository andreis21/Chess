using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Pieces
{
    internal class Queen : Piece
    {
        public Queen(PieceColor color) : base(color)
        {
        }

        public override List<string> CalculateLegalMoves()
        {
            throw new NotImplementedException();
        }
    }
}
