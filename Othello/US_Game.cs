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
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;

namespace Othello
{
    public partial class US_Game : UserControl
    {
        private IDictionary<int, Button> buttons;

        private const int boardSize = 8;

        private Agent black;
        private Agent white;

        internal State state = new State();

        public int blackMoves = 0;
        public int blackStates = 0;
        public int whiteMoves = 0;
        public int whiteStates = 0;

        public US_Game()
        {
            InitializeComponent();

            InitButtons();

            RefreshBoard();
        }

        internal void SetAgent(Agent black, Agent white)
        {
            this.black = black;
            this.white = white;
        }

        /// <summary>
        /// Initialize this.buttons
        /// </summary>
        private void InitButtons()
        {
            buttons = new Dictionary<int, Button>
            {
                { 0, btn11 },
                { 1, btn21 },
                { 2, btn31 },
                { 3, btn41 },
                { 4, btn51 },
                { 5, btn61 },
                { 6, btn71 },
                { 7, btn81 },
                { 8, btn12 },
                { 9, btn22 },
                { 10, btn32 },
                { 11, btn42 },
                { 12, btn52 },
                { 13, btn62 },
                { 14, btn72 },
                { 15, btn82 },
                { 16, btn13 },
                { 17, btn23 },
                { 18, btn33 },
                { 19, btn43 },
                { 20, btn53 },
                { 21, btn63 },
                { 22, btn73 },
                { 23, btn83 },
                { 24, btn14 },
                { 25, btn24 },
                { 26, btn34 },
                { 27, btn44 },
                { 28, btn54 },
                { 29, btn64 },
                { 30, btn74 },
                { 31, btn84 },
                { 32, btn15 },
                { 33, btn25 },
                { 34, btn35 },
                { 35, btn45 },
                { 36, btn55 },
                { 37, btn65 },
                { 38, btn75 },
                { 39, btn85 },
                { 40, btn16 },
                { 41, btn26 },
                { 42, btn36 },
                { 43, btn46 },
                { 44, btn56 },
                { 45, btn66 },
                { 46, btn76 },
                { 47, btn86 },
                { 48, btn17 },
                { 49, btn27 },
                { 50, btn37 },
                { 51, btn47 },
                { 52, btn57 },
                { 53, btn67 },
                { 54, btn77 },
                { 55, btn87 },
                { 56, btn18 },
                { 57, btn28 },
                { 58, btn38 },
                { 59, btn48 },
                { 60, btn58 },
                { 61, btn68 },
                { 62, btn78 },
                { 63, btn88 }
            };
        }

        /// <summary>
        /// refresh board to show
        /// </summary>
        internal void RefreshBoard()
        {
            CleanBoard();
            Board board = state.board;
            if (state.outcome == State.Outcome.PLAYING)
            {
                labelStatus.Text = (state.player.Equal(Player.Black())) ? "Black Turn" : "White Turn";
            }
            else
            {
                switch (state.outcome)
                {
                    case State.Outcome.DRAW:
                        labelStatus.Text = "Draw";
                        break;
                    case State.Outcome.BLACK_WIN:
                        labelStatus.Text = "Black WIN";
                        break;
                    case State.Outcome.WHITE_WIN:
                        labelStatus.Text = "White WIN";
                        break;
                }
            }
            foreach (Piece piece in board.Pieces())
            {
                int row = piece.row, column = piece.column;
                if (piece.player.Equal(Player.Color.BLACK))
                {
                    buttons[row + column * boardSize].Image = Properties.Resources.black;
                }
                else if (piece.player.Equal(Player.Color.WHITE))
                {
                    buttons[row + column * boardSize].Image = Properties.Resources.white;
                }
            }

            List<Tuple<int, int>> nextMove = board.NextMoves(state.player);
            foreach (Tuple<int, int> pair in nextMove)
            {
                int row = pair.Item1, column = pair.Item2;
                buttons[row + column * boardSize].Image = Properties.Resources.redCircle;
            }
            this.Update();
        }

        /// <summary>
        /// clean board
        /// </summary>
        private void CleanBoard()
        {
            for (int i = 0; i < boardSize; i++)
            {
                for (int j = 0; j < boardSize; j++)
                {
                    buttons[i * boardSize + j].Image = null;
                }
            }
        }

        /// <summary>
        /// action when you click the button
        /// </summary>
        /// <param name="sender">Button</param>
        /// <param name="e"></param>
        private void Button_Click(object sender, EventArgs e)
        {
            if (!(sender is Button))
            {
                return;
            }
            Button button = (Button)sender;
            if (state.player.Equal(Player.Color.BLACK) && black is Human human)
            {
                int row = (int)Char.GetNumericValue(button.Name[3]);
                int column = (int)Char.GetNumericValue(button.Name[4]);
                human.SetRow(row - 1);
                human.SetColumn(column - 1);
            }
            else if (state.player.Equal(Player.Color.WHITE) && white is Human human1)
            {
                int row = (int)Char.GetNumericValue(button.Name[3]);
                int column = (int)Char.GetNumericValue(button.Name[4]);
                human1.SetRow(row - 1);
                human1.SetColumn(column - 1);
            }

            State choice;
            while (true)
            {
                RefreshBoard();
                if (this.state.player.Equal(Player.Color.BLACK))
                {
                    choice = this.black.ChooseMove(this.state);
                    if (choice == null)
                    {
                        return;
                    }
                    if (choice != this.state)
                    {
                        this.blackMoves++;
                        this.blackStates += choice.previous.CountDescendants();
                    }
                }
                else
                {
                    choice = this.white.ChooseMove(this.state);
                    if (choice == null)
                    {
                        return;
                    }
                    if (choice != this.state)
                    {
                        this.whiteMoves++;
                        this.whiteStates += choice.previous.CountDescendants();
                    }
                }
                this.state = choice;
                RefreshBoard();
                if ((state.player.Equals(Player.Black()) && (black is Human)) || (state.player.Equals(Player.White()) && (white is Human)))
                {
                    break;
                }
            }

            return;
        }
    }
}
