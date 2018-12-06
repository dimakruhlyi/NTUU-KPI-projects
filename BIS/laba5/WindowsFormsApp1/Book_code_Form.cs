using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApp1
{
    public partial class Book_code_Form : Form
    {
        public Book_code_Form()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            count_line = richTextBox1.Lines.Length;
            key = new string[count_line];
            int count = count_line;

            if (richTextBox1.Text.Length != 0)
            {
                int number = 0;
                for (int i = 0; i < count; i++)
                {
                    string q = richTextBox1.Lines[i];
                    if (q != "")
                    {
                        key[number] = richTextBox1.Lines[i];
                        number++;
                    }
                    else
                    {
                        count_line--;
                    }
                }
            }

            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog oppenFile = new OpenFileDialog();

            if (oppenFile.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.Text = File.ReadAllText(oppenFile.FileName);
            }
        }
    }
}
