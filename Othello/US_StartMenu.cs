using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Othello
{
    public partial class US_StartMenu : UserControl
    {
        public US_StartMenu()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            radioButton1.Select();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            radioButton2.Select();
        }
    }
}
