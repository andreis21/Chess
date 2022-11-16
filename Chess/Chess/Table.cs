using Chess.Pieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    internal class Table
    {
        private Table _instance;
        public Cell[,] Cells;

        private Table()
        {
            for(int i = 0; i < 8; i++)
            {
                for(int j = 0; j < 8; j++)
                {
                    Cells[i, j] = new Cell();
                }
            }
        }

        public void SetupTableForColor(PieceColor color)
        {
            switch (color)
            {
                case PieceColor.Black:
                    
                    break;
                case PieceColor.White:
                    break;
            }
        }

        public void ParseAndSetupTable(string positionsString)
        {
            int row = 0;
            int col = 0;
            foreach(var character in positionsString)
            {
                if (character.Equals('/'))
                {
                    col++;
                    continue;
                }
                if (char.IsDigit(character))
                {
                    row += Int16.Parse(character.ToString());
                    continue;
                }
                Piece piece = null;
                switch (character)
                {
                    case 'p':
                        piece = new 
                        break;
                }
            }
        }
    }
}
