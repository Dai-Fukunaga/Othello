using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Othello
{
    internal class Player
    {
        enum Color
        {
            BLACK,
            WHITE,
        };

        public Player() { }

        public Color other(Color color)
        {
            return color == Color.WHITE ? Color.BLACK : Color.WHITE;
        }
    }
}
