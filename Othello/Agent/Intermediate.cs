/*
The MIT License (MIT)

Copyright (c) 2023 Dai Fukunaga.

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in
all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
THE SOFTWARE.
*/

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
                Console.WriteLine(e.ToString());
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
