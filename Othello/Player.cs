﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Othello
{
    internal class Player
    {
        private static Player black = new Player(0);
        private static Player white = new Player(1);

        private Color color;

        public enum Color
        {
            BLACK,
            WHITE,
        };

        public Player(int color)
        {
            if (color == 0)
            {
                this.color = Color.BLACK;
            }
            else if (color == 1)
            {
                this.color = Color.WHITE;
            }
        }

        public Player Clone()
        {
            return (Player)MemberwiseClone();
        }

        public Player Other()
        {
            return color == Color.BLACK ? new Player(1) : new Player(0);
        }

        public bool Equal(Player other)
        {
            return color == other.color;
        }

        public bool Equal(Color color)
        {
            return this.color == color;
        }

        public static Player Black()
        {
            return black;
        }

        public static Player White()
        {
            return white;
        }
    }
}
