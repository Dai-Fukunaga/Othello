using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Othello
{
    internal class Human : Agent
    {
        private int row;
        private int column;
        public Human() : base("Human")
        {
            row = -1;
            column = -1;
        }

        public void SetRow(int row)
        {
            this.row = row;
        }

        public void SetColumn(int column)
        {
            this.column = column;
        }

        public override State ChooseMove(State root)
        {
            if (!Board.IsValid(row, column))
            {
                Console.WriteLine("Invalid");
                return null;
            }

            if (!root.board.ValidSquare(row, column, root.player))
            {
                Console.WriteLine("Invalid Square");
                return null;
            }

            foreach (State state in root.nextStates())
            {
                if (state.board.PieceAt(row, column))
                {
                    row = -1;
                    column = -1;
                    return state;
                }
            }

            row = -1; column = -1;
            return null;
        }
    }
}
