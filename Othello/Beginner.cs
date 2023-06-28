using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Othello
{
    internal class Beginner : Agent
    {
        public Beginner() : base("beginner") { }

        public override State ChooseMove(State current)
        {
            return null;
        }
    }
}
