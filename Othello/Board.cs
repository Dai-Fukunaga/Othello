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

        private static Piece[] INITIAL = {new Piece(new Player(1), 3, 3), new Piece(new Player(0), 4, 3), new Piece(new Player(0), 3, 4), new Piece(new Player(1), 4, 4)};

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
            Piece [] p = toClone.pieces;
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
            for (int i = 0; i < size; i++)
            {
                yield return this.pieces[i];
            }
        }
    }
}
