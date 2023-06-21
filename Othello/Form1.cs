using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Othello
{
    public partial class FormMain : Form
    {
        IDictionary<int, Button> buttons;

        private const int size = 8;

        public FormMain()
        {
            InitializeComponent();

            InitButtons();

            Board board = new Board();
            foreach (Piece piece in board.PieceIterator())
            {
                int row = piece.row, column = piece.column;
                if (piece.player.Equal(Player.Color.BLACK))
                {
                    buttons[row + column * size].Image = Properties.Resources.black;
                }
                else if (piece.player.Equal(Player.Color.WHITE))
                {
                    buttons[row + column * size].Image = Properties.Resources.white;
                }
            }
        }

        private void InitButtons()
        {
            buttons = new Dictionary<int, Button>();
            buttons.Add(0, btn11);
            buttons.Add(1, btn21);
            buttons.Add(2, btn31);
            buttons.Add(3, btn41);
            buttons.Add(4, btn51);
            buttons.Add(5, btn61);
            buttons.Add(6, btn71);
            buttons.Add(7, btn81);
            buttons.Add(8, btn12);
            buttons.Add(9, btn22);
            buttons.Add(10, btn32);
            buttons.Add(11, btn42);
            buttons.Add(12, btn52);
            buttons.Add(13, btn62);
            buttons.Add(14, btn72);
            buttons.Add(15, btn82);
            buttons.Add(16, btn13);
            buttons.Add(17, btn23);
            buttons.Add(18, btn33);
            buttons.Add(19, btn43);
            buttons.Add(20, btn53);
            buttons.Add(21, btn63);
            buttons.Add(22, btn73);
            buttons.Add(23, btn83);
            buttons.Add(24, btn14);
            buttons.Add(25, btn24);
            buttons.Add(26, btn34);
            buttons.Add(27, btn44);
            buttons.Add(28, btn54);
            buttons.Add(29, btn64);
            buttons.Add(30, btn74);
            buttons.Add(31, btn84);
            buttons.Add(32, btn15);
            buttons.Add(33, btn25);
            buttons.Add(34, btn35);
            buttons.Add(35, btn45);
            buttons.Add(36, btn55);
            buttons.Add(37, btn65);
            buttons.Add(38, btn75);
            buttons.Add(39, btn85);
            buttons.Add(40, btn16);
            buttons.Add(41, btn26);
            buttons.Add(42, btn36);
            buttons.Add(43, btn46);
            buttons.Add(44, btn56);
            buttons.Add(45, btn66);
            buttons.Add(46, btn76);
            buttons.Add(47, btn86);
            buttons.Add(48, btn17);
            buttons.Add(49, btn27);
            buttons.Add(50, btn37);
            buttons.Add(51, btn47);
            buttons.Add(52, btn57);
            buttons.Add(53, btn67);
            buttons.Add(54, btn77);
            buttons.Add(55, btn87);
            buttons.Add(56, btn18);
            buttons.Add(57, btn28);
            buttons.Add(58, btn38);
            buttons.Add(59, btn48);
            buttons.Add(60, btn58);
            buttons.Add(61, btn68);
            buttons.Add(62, btn78);
            buttons.Add(63, btn88);
        }
    }
}
