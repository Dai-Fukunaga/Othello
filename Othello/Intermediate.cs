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

        private double FindMax(State state, double alpha, double beta, int cnt, Player player)
        {
            if (state.outcome != State.Outcome.PLAYING)
            {
                if (state.outcome == State.Outcome.DRAW)
                {
                    return 0;
                }
                else if (state.outcome == State.Outcome.BLACK_WIN)
                {
                    return (player == Player.Black()) ? 1000000 : -1000000;
                }
                else if (state.outcome == State.Outcome.WHITE_WIN)
                {
                    return (player == Player.White()) ? 1000000 : -1000000;
                }
            }
            else if (cnt <= 0)
            {
                return CalculateScore.Score(state.board, player);
            }
            else
            {
                double max = Double.NegativeInfinity;
                foreach (State child in state.NextStates())
                {
                    double childValue = FindMin(child, alpha, beta, cnt - 1, player);
                    max = Math.Max(max, childValue);
                    if (max >= beta)
                    {
                        return max;
                    }
                    alpha = Math.Max(alpha, max);
                }
                return max;
            }

            return 0;
        }

        private double FindMin(State state, double alpha, double beta, int cnt, Player player)
        {
            if (state.outcome != State.Outcome.PLAYING)
            {
                if (state.outcome == State.Outcome.DRAW)
                {
                    return 0;
                }
                else if (state.outcome == State.Outcome.BLACK_WIN)
                {
                    return (player == Player.Black()) ? 1000000 : -1000000;
                }
                else if (state.outcome == State.Outcome.WHITE_WIN)
                {
                    return (player == Player.White()) ? 1000000 : -1000000;
                }
            }
            else if (cnt <= 0)
            {
                return CalculateScore.Score(state.board, player);
            }
            else
            {
                double min = Double.PositiveInfinity;
                foreach (State child in state.NextStates())
                {
                    double childValue = FindMax(child, alpha, beta, cnt - 1, player);
                    min = Math.Min(min, childValue);
                    if (min <= alpha)
                    {
                        return min;
                    }
                    beta = Math.Min(beta, min);
                }
                return min;
            }

            return 0;
        }

        public override State ChooseMove(State current)
        {
            State currentBest = null, best = null;
            Player player = current.player;
            CancellationTokenSource cts = new CancellationTokenSource();
            Task timeoutTask = Task.Delay(5000, cts.Token);

            Task mainTask = Task.Run(() =>
            {
                for (int i = 3; i < 64; i++)
                {
                    double max = Double.NegativeInfinity;
                    foreach (State child in current.NextStates())
                    {
                        double score = FindMin(child, Double.NegativeInfinity, Double.PositiveInfinity, i, player);
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
            });

            Task completedTask = await Task.WhenAny(mainTask, timeoutTask);
            if (completedTask == timeoutTask)
            {
                cts.Cancel();
                Console.WriteLine("タイムアウトしました。");
            }
            else
            {
                // mainTask が正常に終了した場合の処理
            }
            return best;
        }
    }
}
