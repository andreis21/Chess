using Chess.Pieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    internal class Cell
    {
        public Piece? Piece;

        public Cell(Piece piece = null)
        {
            this.Piece = piece;
        }
    }
}
