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
using System.Resources;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Othello
{
    public partial class FormMain : Form
    {
        public US_Game game;
        public US_StartMenu startMenu;
        public FormMain()
        {
            InitializeComponent();
            startMenu.Visible = true;
            game.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Agent black, white;
            if (startMenu.radioButton1.Checked)
            {
                black = new Human();
                if (startMenu.comboBox1.SelectedIndex == 0)
                {
                    white = new Random();
                }
                else
                {
                    white = new Human();
                }
            }
            else
            {
                white = new Human();
                if (startMenu.comboBox1.SelectedIndex == 0)
                {
                    black = new Random();
                }
                else
                {
                    black = new Human();
                }
            }

            game.SetAgent(black, white);
            game.RefreshBoard();
            button1.Visible = false;
            startMenu.Visible = false;
            game.Visible = true;
            this.Refresh();

            if (!(black is Human))
            {
                State choice = black.ChooseMove(game.state);
                if (choice == null)
                {
                    return;
                }
                if (choice != game.state)
                {
                    game.blackMoves++;
                    game.blackStates += choice.previous.CountDescendants();
                }
                game.state = choice;
                game.RefreshBoard();
            }
        }
    }
}
