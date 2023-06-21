using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Othello
{
    internal class Human : Agent
    {
        public string name;

        public Human() : base("Human") { }

        public override State ChooseMove(State root)
        {
            return null;
        }
    }
}
