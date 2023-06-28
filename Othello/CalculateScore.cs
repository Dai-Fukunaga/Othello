using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Othello
{
    internal class CalculateScore
    {
        private static double[,] bp = new double[,]
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

        private static System.Random rnd = new System.Random();

        public CalculateScore() { }

        private static double BP(Board board, Player player)
        {
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

        private static int CountFS()
        {
            int cnt = 0;
            int[] x = new int[] { 1, -1, 1, -1 };
            int[] y = new int[] { 1, 1, -1, -1 };
            for (int i = 0; i < 4; i++)
            {

            }
            return cnt;
        }

        private static double FS(Board board, Player player)
        {
            double score = 0;
            int black = 0, white = 0;
            char[,] fs = new char[8, 8];
            foreach (Piece piece in board.Pieces())
            {
                if (piece.player.Equal(Player.Black()))
                {
                    fs[piece.column, piece.row] = 'b';
                }
                else
                {
                    fs[piece.column, piece.row] = 'w';
                }
            }

            return score;
        }

        public static double Score(Board board, Player player)
        {
            double score = BP(board, player) + CP(board, player) + FS(board, player);
            // Console.WriteLine(score);
            return score;
        }
    }
}
