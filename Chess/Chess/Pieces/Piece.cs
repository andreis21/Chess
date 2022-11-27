using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Pieces
{
    internal abstract class Piece
    {
        public int x;
        public int y;
        public PieceColor color;

        protected Piece(PieceColor color)
        {
            this.color = color;
        }

        public abstract List<string> CalculateLegalMoves();
    }
}
