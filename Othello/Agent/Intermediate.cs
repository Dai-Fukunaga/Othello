using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Othello
{
    internal class Intermediate : Agent
    {
        public Intermediate() : base("intermediate") { }

        public override State ChooseMove(State current)
        {
            State currentBest = null, best = null;
            Player player = current.player;
            try
            {
                for (int i = 3; i < 64; i++)
                {
                    double max = Double.NegativeInfinity;
                    foreach (State child in current.NextStates())
                    {
                        double score = CalculateScore.FindMin(child, Double.NegativeInfinity, Double.PositiveInfinity, i, player);
                        if (score >= 1000000)
                        {
                            return child;
                        }
                        if (max < score)
                        {
                            max = score;
                            currentBest = child;
                        }
                    }
                    best = currentBest;
                }
            }
            catch (SearchBudgetExceededException e)
            {
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                Application.Exit();
            }

            return best;
        }
    }
}
