using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Pieces
{
    internal class Knight : Piece
    {
        public Knight(PieceColor color) : base(color)
        {

        }

        public override List<string> CalculateLegalMoves()
        {
            throw new NotImplementedException();
        }
    }
}
