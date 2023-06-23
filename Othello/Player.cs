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
