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

        /// <summary>
        /// init the Piece class
        /// </summary>
        /// <param name="player">Piece's Player</param>
        /// <param name="row">Piece's row</param>
        /// <param name="column">Piece's column</param>
        public Piece(Player player, int row, int column)
        {
            this.player = player;
            this.row = row;
            this.column = column;
        }

        /// <summary>
        /// return clone Piece
        /// </summary>
        /// <returns>clone Piece</returns>
        public Piece Clone()
        {
            return (Piece)MemberwiseClone();
        }
    }
}
