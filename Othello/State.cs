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

        private int descendants = 0;

        /// <summary>
        /// Outcome of the game
        /// </summary>
        public enum Outcome
        {
            DRAW,
            BLACK_WIN,
            WHITE_WIN,
            PLAYING,
        };

        public Outcome outcome = Outcome.PLAYING;

        /// <summary>
        /// init the State class
        /// </summary>
        /// <param name="previous">previous state</param>
        /// <param name="board">present board</param>
        public State(State previous, Board board)
        {
            this.previous = previous;
            this.board = board;
            // this.player = previous.player.Other();
            int blackMoves = board.NextMoves(Player.Black()).Count();
            int whiteMoves = board.NextMoves(Player.White()).Count();
            if ((previous.player.Other().Equal(Player.Color.BLACK) && blackMoves == 0) || (previous.player.Other().Equal(Player.Color.WHITE) && whiteMoves == 0))
            {
                this.player = previous.player;
            }
            else
            {
                this.player = previous.player.Other();
            }
            if ((blackMoves == 0 && whiteMoves == 0) || board.CountPieces() == 64)
            {
                if (board.CountPieces(Player.Black()) == board.CountPieces(Player.White()))
                {
                    outcome = Outcome.DRAW;
                }
                else
                {
                    outcome = (board.CountPieces(Player.Black()) > board.CountPieces(Player.White())) ? Outcome.BLACK_WIN : Outcome.WHITE_WIN;
                }
            }
            State parent = previous;
            while (parent != null)
            {
                parent.descendants++;
                parent = parent.previous;
            }
        }

        /// <summary>
        /// init the State class
        /// </summary>
        public State()
        {
            previous = null;
            board = new Board();
            player = Player.Black();
        }

        /// <summary>
        /// init the State class
        /// </summary>
        /// <param name="toClone">State you want to make again</param>
        private State(State toClone)
        {
            this.previous = toClone.previous;
            this.board = toClone.board;
            this.player = toClone.player;
        }

        public int CountDescendants()
        {
            return descendants;
        }

        /// <summary>
        /// next States from present State
        /// </summary>
        /// <returns>list of next States</returns>
        public List<State> NextStates()
        {
            List<State> nextStates = new List<State>();
            foreach (Board b in this.board.NextBoards(player))
            {
                nextStates.Add(new State(this, b));
            }
            return nextStates;
        }
    }
}
