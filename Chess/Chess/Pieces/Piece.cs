using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Pieces
{
    internal abstract class Piece
    {
        int x;
        int y;
        PieceColor color;
        PieceType type;

        protected Piece(int x, int y, PieceColor color, PieceType type)
        {
            this.x = x;
            this.y = y;
            this.color = color;
            this.type = type;
        }

        public abstract string CalculateLegalMoves();
    }
}
