using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Othello
{
    internal abstract class Agent
    {
        public string name;

        public Agent(string name)
        {
            this.name = name;
        }

        /// <summary>
        /// choose next State
        /// </summary>
        /// <param name="current">present State</param>
        /// <returns>next State</returns>
        public abstract State ChooseMove(State current);
    }
}
