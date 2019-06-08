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

namespace Coursework
{
    public partial class Form1 : Form
    {
        Debug_Interpretator start;

        int present_token = 0;
        List<int> Stack3 = new List<int>();
        int Count_stack = 0;
        int next_state = 1;

        public Form1()
        {
            InitializeComponent();

            tabControl1.TabPages.Remove(tabPage2);
            tabControl1.TabPages.Remove(tabPage3);
            tabControl1.TabPages.Remove(tabPage4);
        }

        //save
        private void зберегтиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (way != "")
            {
                FileStream file1 = new FileStream(way, FileMode.Create);
                StreamWriter writer = new StreamWriter(file1);

                writer.Write(richTextBox1.Text);
                writer.Close();
            }
            else
            {
                зберегтиЯкToolStripMenuItem_Click(this, e);
            }
        }

        //save as
        private void зберегтиЯкToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "txt files |*.txt|All files |*.*";

            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                way = saveFile.FileName;
                StreamWriter writer = new StreamWriter(saveFile.FileName, false);

                writer.WriteLine(richTextBox1.Text);
                writer.Close();
            }
        }

        //open
        private void відкритиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog oppenFile = new OpenFileDialog();

            if (oppenFile.ShowDialog() == DialogResult.OK)
            {
                way = oppenFile.FileName;
                richTextBox1.Text = File.ReadAllText(oppenFile.FileName);
            }

            this.Text = "Файл - " + oppenFile.FileName;
        }

        //close
        private void закритьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            way = "";
            richTextBox1.Clear();
        }

        //printing
        private void друкToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrintDialog printFile = new PrintDialog();
            printFile.ShowDialog();
        }

        //otput
        private void вихідToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        public int getWidth()
        {
            int w = 25;
            int line = richTextBox1.Lines.Length;

            if (line <= 99)
            {
                w = 20 + (int)LineNumberTextBox.Font.Size;
            }
            else if (line <= 999)
            {
                w = 30 + (int)LineNumberTextBox.Font.Size;
            }
            else
            {
                w = 50 + (int)LineNumberTextBox.Font.Size;
            }

            return w;
        }

        public void AddLineNumbers()
        {
            Point pt = new Point(0, 0);
            int First_Index = richTextBox1.GetCharIndexFromPosition(pt);
            int First_Line = richTextBox1.GetLineFromCharIndex(First_Index);

            LineNumberTextBox.Text = "";
            LineNumberTextBox.Width = getWidth();
            int count = richTextBox1.Lines.Count();
            if (count == 0)
            {
                count = 1;
            }
            for (int i = First_Index; i <= count - 1; i++)
            {
                LineNumberTextBox.Text += i + 1 + "\n";
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LineNumberTextBox.Font = richTextBox1.Font;
            LineNumberTextBox.SelectionAlignment = HorizontalAlignment.Center;
            LineNumberTextBox.Width = getWidth();
            LineNumberTextBox.Text = 1 + "\n";
        }

        private void richTextBox1_SelectionChanged(object sender, EventArgs e)
        {
            Point pt = richTextBox1.GetPositionFromCharIndex(richTextBox1.SelectionStart);
            if (pt.X == 1)
            {
                AddLineNumbers();
            }
        }

        private void richTextBox1_VScroll(object sender, EventArgs e)
        {
            LineNumberTextBox.Text = "";
            AddLineNumbers();
            LineNumberTextBox.Invalidate();
        }

        private void LineNumberTextBox_MouseDown(object sender, MouseEventArgs e)
        {
            richTextBox1.Select();
            LineNumberTextBox.DeselectAll();
        }

        private void richTextBox2_MouseDown(object sender, MouseEventArgs e)
        {
            richTextBox1.Select();
        }

        //Start
        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView4.DataSource = null;
            dataGridView5.DataSource = null;

            start = new Debug_Interpretator(richTextBox1.Text);


            dataGridView1.DataSource = start.table_lexem();
            dataGridView2.DataSource = start.table_id();
            dataGridView3.DataSource = start.table_const();
            dataGridView9.DataSource = start.Get_Mitka();

            richTextBox3.Text = start.GetW();

            if (start.get_check_error())
            {
                dataGridView4.Visible = true;
                dataGridView4.DataSource = start.Get_error_message();
                int a = dataGridView4.Size.Width;
                int b = dataGridView4.Columns[0].Width;
                dataGridView4.Columns[1].Width = a - b - 3;

                tabControl1.TabPages.Remove(tabPage2);
                tabControl1.TabPages.Remove(tabPage3);
                tabControl1.TabPages.Remove(tabPage4);
            }
            else
            {
                if (start.Get_count_Lexem() > 1)
                {
                    dataGridView5.DataSource = start.Get_MPA();
                    button1.Enabled = true;

                    if (tabControl1.TabPages.IndexOf(tabPage2) == -1)
                    {
                        tabControl1.TabPages.Add(tabPage2);
                        tabControl1.TabPages.Add(tabPage3);
                        tabControl1.TabPages.Add(tabPage4);
                    }
                }

                //Debug_Poliz a = new Debug_Poliz(richTextBox1.Text);

                dataGridView6.DataSource = start.Get_Data_Stan();
            }
        }



        private void Form1_Resize(object sender, EventArgs e)
        {
            if (dataGridView4.Visible == true)
            {
                int a = dataGridView4.Size.Width;
                int b = dataGridView4.Columns[0].Width;

                dataGridView4.Columns[1].Width = a - b - 3;
            }
            this.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (start.Get_count_Lexem() == 0)
            {
                button1.Enabled = false;
                return;
            }

            dataGridView4.DataSource = start.Get_error_message();

            if (present_token < start.Get_count_Lexem() && !start.get_check_error())
            {
                int q = present_token;
                if (q + 1 >= start.Get_count_Lexem())
                {
                    q = start.Get_count_Lexem() - 2;
                }
                label6.Text = start.get_lexem(q + 1);
                next_state = start.next_step(next_state, present_token);
                dataGridView4.DataSource = start.Get_error_message();


                for (int i = 0; i < dataGridView5.Rows.Count; i++)
                {
                    if (next_state == Convert.ToUInt32(dataGridView5.Rows[i].Cells[0].Value))
                    {
                        dataGridView5.Rows[i].Selected = true;
                    }
                    else
                    {
                        dataGridView5.Rows[i].Selected = false;
                    }
                }

                if (next_state == 0 && Count_stack == 0 && present_token + 1 == start.Get_count_Lexem())
                {
                    button1.Enabled = false;
                    label6.Text = string.Empty;

                    present_token = 0;
                    Stack3 = new List<int>();
                    Count_stack = 0;
                    next_state = 1;
                    start.restart();
                }
            }
            else
            {
                if (present_token == start.Get_count_Lexem())
                {
                    if (start.get_lexem(present_token - 1) != "}")
                    {
                        start.setError();
                    }
                }

                label6.Text = string.Empty;
                button1.Enabled = false;

                present_token = 0;
                Stack3 = new List<int>();
                Count_stack = 0;
                next_state = 1;
            }


            if (dataGridView4.Rows.Count == 0 && Count_stack <= start.Get_count())
            {
                present_token++;
            }


            Stack3 = start.Get_Stack();
            Count_stack = start.Get_count();

            string str = string.Empty;
            for (int j = 0; j < Stack3.Count(); j++)
            {
                str += "  " + Stack3[j];
            }
            label5.Text = str;
        }


        private void button2_Click(object sender, EventArgs e)
        {
            present_token = 0;
            Stack3 = new List<int>();
            Count_stack = 0;
            next_state = 1;
            start.restart();

            for (int i = 0; i < dataGridView5.Rows.Count; i++)
            {
                dataGridView5.Rows[i].Selected = false;
            }
            dataGridView5.Rows[0].Selected = true;

            button1.Enabled = true;
            label6.Text = "program";
            label5.Text = "";
        }


        private void richTextBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                startToolStripMenuItem_Click(sender, e);
            }
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void файлToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
