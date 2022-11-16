using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Pieces
{
    internal abstract class Piece
    {
        PieceColor color;
        PieceType type;

        protected Piece(PieceColor color, PieceType type)
        {
            this.color = color;
            this.type = type;
        }

        public abstract string CalculateLegalMoves();
    }
}
