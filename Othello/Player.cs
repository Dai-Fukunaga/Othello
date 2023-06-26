/*
The MIT License (MIT)

Copyright (c) 2023 Dai Fukunaga.

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in
all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
THE SOFTWARE.
*/

using System;
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

        private Color color = Color.BLACK;

        public enum Color
        {
            BLACK,
            WHITE,
        };

        /// <summary>
        /// init the Player class
        /// </summary>
        /// <param name="color">player color (0 means black, 1 means white)</param>
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

        /// <summary>
        /// Clone the Player class
        /// </summary>
        /// <returns></returns>
        public Player Clone()
        {
            return (Player)MemberwiseClone();
        }

        /// <summary>
        /// return other Player class
        /// </summary>
        /// <returns>other Player class</returns>
        public Player Other()
        {
            return color == Color.BLACK ? new Player(1) : new Player(0);
        }

        /// <summary>
        /// check if the Player is the same
        /// </summary>
        /// <param name="other">other Player</param>
        /// <returns>if the Player is the same, return true, otherwise, return false</returns>
        public bool Equal(Player other)
        {
            return color == other.color;
        }

        /// <summary>
        /// check if the Player is the same
        /// </summary>
        /// <param name="color">other Player's color</param>
        /// <returns>if the Player is the same, return true, otherwise, return false</returns>
        public bool Equal(Color color)
        {
            return this.color == color;
        }

        /// <summary>
        /// return Player BLACK
        /// </summary>
        /// <returns>Player BLACK</returns>
        public static Player Black()
        {
            return black;
        }

        /// <summary>
        /// return Player WHITE
        /// </summary>
        /// <returns>Player WHITE</returns>
        public static Player White()
        {
            return white;
        }
    }
}
