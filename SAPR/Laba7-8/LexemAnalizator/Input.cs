using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Coursework
{
    public partial class Input : Form
    {
        public Input()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            str = richTextBox1.Text;
            this.Close();
        }

        private void Input_FormClosing(object sender, FormClosingEventArgs e)
        {
            str = richTextBox1.Text;
        }
    }
}
