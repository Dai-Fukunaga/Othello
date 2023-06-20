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
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
            // init the board
            prcInit();
        }

        // init the board
        private void prcInit()
        {
            btn44.Image = Properties.Resources.black;
            btn54.Image = Properties.Resources.white;
            btn45.Image = Properties.Resources.white;
            btn55.Image = Properties.Resources.black;
        }

        private void btn44_Click(object sender, EventArgs e)
        {

        }

        private void btn11_Click(object sender, EventArgs e)
        {

        }
    }
}
