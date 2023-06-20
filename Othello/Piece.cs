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

        public Piece(Player player, int column, int row)
        {
            this.player = player;
            this.column = column;
            this.row = row;
        }
    }
}
