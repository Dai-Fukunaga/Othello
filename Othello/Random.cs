using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Othello
{
    internal class Random : Agent
    {
        public Random() : base("Random") { }

        public override State ChooseMove(State current)
        {
            System.Random random = new System.Random();
            List<State> nextStates = current.NextStates();
            if (nextStates.Count == 0)
            {
                return null;
            }
            Thread.Sleep(1000);
            return nextStates[random.Next(nextStates.Count())];
        }
    }
}
