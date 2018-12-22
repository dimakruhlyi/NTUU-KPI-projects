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
using System.Text.RegularExpressions;

namespace WindowsFormsApp1
{
    public partial class Book_code_Form : Form
    {
        public Book_code_Form()
        {
            InitializeComponent();
            label3.Text = "Введіть N, S і \nпослідовність чисел у форматі X X X ... X";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            count_line = richTextBox1.Lines.Length;
            key = new string[count_line];
            int count = count_line;
            key_for_backpack = richTextBox1.Text;

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

        public void Get_button4_Visible(bool check_type)
        {
            if (check_type == true)
            {
                button4.Visible = true;
                button1.Visible = false;

                textBox1.Visible = true;
                textBox2.Visible = true;
                textBox3.Visible = true;

                label1.Visible = true;
                label2.Visible = true;
                label3.Visible = true;
                label4.Visible = true;

                richTextBox1.Size = new Size(richTextBox1.Size.Width, richTextBox1.Size.Height - 28);
                richTextBox1.Location = new Point(richTextBox1.Location.X, 40);
            }
            else
            {
                button1.Visible = true;
                button4.Visible = false;

                textBox1.Visible = false;
                textBox2.Visible = false;
                textBox3.Visible = false;

                label1.Visible = false;
                label2.Visible = false;
                label3.Visible = false;
                label4.Visible = false;

                richTextBox1.Size = new Size(richTextBox1.Size.Width, 371);
                richTextBox1.Location = new Point(richTextBox1.Location.X, 12);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Regex myRegex = new Regex(@"[0-9]+$", RegexOptions.IgnorePatternWhitespace);

            int i = 0;

            if (textBox1.Text != string.Empty && textBox2.Text != string.Empty && textBox3.Text != string.Empty && richTextBox1.Text != string.Empty)
            {
                while (richTextBox1.Text[richTextBox1.TextLength - i - 1] == ' ')
                {
                    i++;
                }
                richTextBox1.Text = richTextBox1.Text.Remove(richTextBox1.TextLength - i, i);

                if (myRegex.IsMatch(richTextBox1.Text))
                {
                    key_for_backpack = richTextBox1.Text;
                    N = Convert.ToInt32(textBox1.Text);
                    M = Convert.ToInt64(textBox2.Text);
                    T = Convert.ToInt64(textBox3.Text);

                    if (NSD(M, T) == 1)
                    {
                        this.Close();
                    }
                }
            }

           
        }


        private long NSD(long a, long b)
        {
            while (a != b)
            {
                if (a > b)
                {
                    long tmp = a;
                    a = b;
                    b = tmp;
                }
                b = b - a;
            }
            return a;
        }

        private void Book_code_Form_Load(object sender, EventArgs e)
        {

        }
    }
}
