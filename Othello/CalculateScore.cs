﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Othello
{
    internal class CalculateScore
    {
        private const int boardSize = 8;

        private static System.Random rnd = new System.Random();

        public CalculateScore() { }

        public static double FindMax(State state, double alpha, double beta, int count, Player player)
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
            else if (count <= 0)
            {
                return Score(state.board, player);
            }
            else
            {
                double max = Double.NegativeInfinity;
                foreach (State child in state.NextStates())
                {
                    double childValue = FindMin(child, alpha, beta, count - 1, player);
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

        public static double FindMin(State state, double alpha, double beta, int count, Player player)
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
            else if (count <= 0)
            {
                return Score(state.board, player);
            }
            else
            {
                double min = Double.PositiveInfinity;
                foreach (State child in state.NextStates())
                {
                    double childValue = FindMax(child, alpha, beta, count - 1, player);
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

        private static double BP(Board board, Player player)
        {
            double[,] bp = new double[,]
            {
                { 45, -11, 4, -1, -1, 4, -11, 45 },
                { -11, -16, -1,-3, -3, -1, -16 ,-11 },
                { 4, -1, 2, -1, -1, 2, -1, 4 },
                {-1, -3, -1, 0, 0, -1, -3, -1 },
                {-1, -3, -1, 0, 0, -1, -3, -1 },
                { 4, -1, 2, -1, -1, 2, -1, 4 },
                { -11, -16, -1,-3, -3, -1, -16 ,-11 },
                { 45, -11, 4, -1, -1, 4, -11, 45 },
            };
            double score = 0;
            foreach (Piece piece in board.Pieces())
            {
                if (piece.player.Equal(player))
                {
                    score += bp[piece.column, piece.row];
                }
                else
                {
                    score -= bp[piece.column, piece.row];
                }
            }
            return score;
        }

        private static double CP(Board board, Player player)
        {
            double score = (board.NextMoves(player).Count() - board.NextMoves(player.Other()).Count() + 2 * (rnd.NextDouble() - rnd.NextDouble())) * 10;
            return score;
        }

        private static double FS(Board board, Player player)
        {
            double score = 0;
            Player[,] fs = new Player[boardSize, boardSize];
            foreach (Piece piece in board.Pieces())
            {
                if (piece.player.Equal(Player.Black()))
                {
                    fs[piece.column, piece.row] = Player.Black();
                }
                else if (piece.player.Equal(Player.White()))
                {
                    fs[piece.column, piece.row] = Player.White();
                }
                else
                {
                    fs[piece.column, piece.row] = null; // it means empty
                }
            }

            int[] changeX = new int[] { 1, 0, -1, 0 };
            int[] changeY = new int[] { 0, 1, 0, -1 };

            int countSame = 0, countOther = 0;

            for (int i = 0; i < boardSize; i++)
            {
                for (int j = 0; j < boardSize; j++)
                {
                    int wall = 0;
                    if (fs[i, j] == null)
                    {
                        continue;
                    }
                    for (int k = 0; k < changeX.Length; k++)
                    {
                        int p = i + changeX[k], q = j + changeY[k];
                        bool flag = true;
                        while (Board.IsValid(p, q))
                        {
                            if (fs[p, q] == null || !fs[i, j].Equals(fs[p, q]))
                            {
                                flag = false;
                                break;
                            }
                            p += changeX[k];
                            q += changeY[k];
                        }
                        if (flag)
                        {
                            wall++;
                        }
                    }
                    if (wall >= 2)
                    {
                        if (fs[i, j].Equal(player))
                        {
                            countSame++;
                        }
                        else
                        {
                            countOther++;
                        }
                    }
                }
            }

            score = (countSame - countOther + rnd.NextDouble() * 2 - rnd.NextDouble() * 2) * 10;

            return score;
        }

        public static double Score(Board board, Player player)
        {
            double score = 2 * BP(board, player) + CP(board, player) + 5 * FS(board, player);
            // Console.WriteLine(score);
            return score;
        }
    }
}
