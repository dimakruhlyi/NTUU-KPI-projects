using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Tritemius_Form : Form
    {
        public Tritemius_Form()
        {
            InitializeComponent();
        }

        //OK
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length != 0)
            {
                a = Convert.ToInt16(textBox1.Text);
            }
            

            if (textBox2.Text.Length != 0)
            {
                b = Convert.ToInt16(textBox2.Text);
            }
            

            if (textBox3.Text.Length != 0)
            {
                c = Convert.ToInt16(textBox3.Text);
            }

            motto = richTextBox1.Text;
            this.Close();
        }

        //Cancel
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
