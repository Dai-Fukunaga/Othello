using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Othello
{
    internal class Board
    {
        public Board previous;

        private Piece[] pieces;

        private int size;

        private const int boardSize = 8;

        private static Piece[] INITIAL = { new Piece(new Player(1), 3, 3), new Piece(new Player(0), 4, 3), new Piece(new Player(0), 3, 4), new Piece(new Player(1), 4, 4) };

        public static bool IsValid(int row, int column)
        {
            return row >= 0 && row < 8 && column >= 0 && column < 8;
        }

        private Board(Board previous, Board toClone)
        {
            this.previous = previous;
            this.pieces = new Piece[toClone.size];
            this.size = toClone.size;
            int i = 0;
            Piece[] p = toClone.pieces;
            int n = p.Length;
            for (int j = 0; j < n; j++)
            {
                Piece piece = p[j];
                if (piece != null)
                {
                    this.pieces[i++] = piece;
                }
            }
        }

        public Board()
        {
            this.previous = null;
            this.pieces = INITIAL;
            this.size = pieces.Length;
        }

        public Board Clone()
        {
            return new Board(previous, this);
        }

        public int CountPieces()
        {
            return this.size;
        }

        public int CountPieces(Player player)
        {
            int cnt = 0;
            Piece[] p;
            int n = (p = this.pieces).Length;
            for (int i = 0; i < n; i++)
            {
                Piece piece = p[i];
                if (piece != null && piece.player.Equal(player))
                {
                    cnt++;
                }
            }
            return cnt;
        }

        public Piece GetPieceAt(int row, int column)
        {
            Piece[] p;
            int n = (p = this.pieces).Length;

            for (int i = 0; i < n; i++)
            {
                Piece piece = p[i];
                if (piece != null && piece.row == row && piece.column == column)
                {
                    return piece;
                }
            }

            return null;
        }

        public bool PieceAt(int row, int column)
        {
            return (GetPieceAt(row, column) != null);
        }

        public bool PieceAt(int row, int column, Player player)
        {
            Piece piece = GetPieceAt(row, column);
            return piece != null && piece.player.Equal(player);
        }

        public IEnumerable<Piece> PieceIterator()
        {
            Piece[] p;
            int n = (p = this.pieces).Length;
            for (int i = 0; i < n; i++)
            {
                yield return p[i];
            }
        }

        public List<Tuple<int, int>> NextMoves(Player player)
        {
            List<Tuple<int, int>> nextMoves = new List<Tuple<int, int>>();

            for (int i = 0; i < boardSize; i++)
            {
                for (int j = 0; j < boardSize; j++)
                {
                    if (!PieceAt(i, j))
                    {
                        List<Tuple<int, int>> pieceReverse = PieceReverse(i, j, player);
                        if (pieceReverse.Count > 0)
                        {
                            nextMoves.Add(new Tuple<int, int>(i, j));
                        }
                    }
                }
            }

            return nextMoves;
        }

        private List<Tuple<int, int>> PieceReverse(int row, int column, Player player)
        {
            List<Tuple<int, int>> pieceReverse = new List<Tuple<int, int>>();
            int[] x = { 0, 1, 1, 1, 0, -1, -1, -1 };
            int[] y = { 1, 1, 0, -1, -1, -1, 0, 1 };
            for (int i = 0; i < x.Length; i++)
            {
                int cnt = 1;
                int r = row + x[i], c = column + y[i];
                if (PieceAt(r, c, player.Other()))
                {
                    while (true)
                    {
                        r += x[i];
                        c += y[i];
                        if (IsValid(r, c))
                        {
                            if (PieceAt(r, c, player))
                            {
                                for (int j = 0; j < cnt; j++)
                                {
                                    r -= x[i];
                                    c -= y[i];
                                    pieceReverse.Add(new Tuple<int, int>(r, c));
                                }
                            }
                            else if (PieceAt(r, c, player.Other()))
                            {
                                cnt++;
                            }
                            else
                            {
                                break;
                            }
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }
            return pieceReverse;
        }
    }
}
