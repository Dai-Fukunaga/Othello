using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Othello
{
    internal class State
    {
        public State previous;

        public Board board;

        public Player player;

        public int turn;

        private int descendants = 0;

        public State(State previous, Board board)
        {
            this.previous = previous;
            this.board = board;
            this.player = previous.player.Other();
            this.turn = previous.player.Equal(Player.Color.WHITE) ? previous.turn + 1 : previous.turn;
            State parent = previous;
            while (parent != null)
            {
                parent.descendants++;
                parent = parent.previous;
            }
        }

        public State()
        {
            previous = null;
            board = new Board();
            player = new Player(0);
            this.turn = 0;
        }

        private State(State toClone)
        {
            this.previous = toClone.previous;
            this.board = toClone.board;
            this.player = toClone.player;
            this.turn = toClone.turn;
        }


    }
}
