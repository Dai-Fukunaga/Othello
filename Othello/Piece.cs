using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Othello
{
    internal class Piece
    {
        public Player player;

        public int column;

        public int row;

        public Piece(Player player, int row, int column)
        {
            this.player = player;
            this.row = row;
            this.column = column;
        }

        public Piece Clone()
        {
            return (Piece)MemberwiseClone();
        }
    }
}
