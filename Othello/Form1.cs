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
