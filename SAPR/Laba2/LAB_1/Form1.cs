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

namespace LAB_1
{
    public partial class Form1 : Form
    {
        bool check_debug_program = false;

        public Form1()
        {
            InitializeComponent();

            dataGridView1.Visible = false;
            dataGridView2.Visible = false;
            dataGridView3.Visible = false;

            richTextBox1.Visible = true;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;

            tableToolStripMenuItem.Visible = false;

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




        private void debugToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = false;
            dataGridView2.Visible = false;
            dataGridView3.Visible = false;

            richTextBox1.Visible = true;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            LineNumberTextBox.Visible = true;


            debugToolStripMenuItem1.Visible = true;
        }

        private void tableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = true;
            dataGridView2.Visible = true;
            dataGridView3.Visible = true;

            richTextBox1.Visible = true;
            label2.Visible = true;
            label3.Visible = true;
            label4.Visible = true;
            LineNumberTextBox.Visible = true;
            

            debugToolStripMenuItem1.Visible = false;

        }

        private void debugToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (!check_debug_program)
            {
                Debug_Syntax program = new Debug_Syntax(richTextBox1.Text + '\n');

                dataGridView4.DataSource = program.Get_error_message();
                dataGridView1.DataSource = program.table_lexem();
                dataGridView2.DataSource = program.table_const();
                dataGridView3.DataSource = program.table_id();
                int a = dataGridView4.Size.Width;
                int b = dataGridView4.Columns[0].Width;
                int c = dataGridView4.Columns[1].Width;
                dataGridView4.Columns[1].Width = a - b - 43;
            }

            
            if (dataGridView4.RowCount == 0 && dataGridView1.RowCount > 0 && !check_debug_program)
            {
                tableToolStripMenuItem_Click(this, e);
                tableToolStripMenuItem.Visible = true;
            }
            check_debug_program = true;

        }


        public int getWidth()
        {
            int w = 25;
            // get total lines of richTextBox1    
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
            // get First Index & First Line from richTextBox1    
            int First_Index = richTextBox1.GetCharIndexFromPosition(pt);
            int First_Line = richTextBox1.GetLineFromCharIndex(First_Index);
            // set X & Y coordinates of Point pt to ClientRectangle Width & Height respectively    

            LineNumberTextBox.Text = "";
            LineNumberTextBox.Width = getWidth();
            // now add each line number to LineNumberTextBox upto last line   
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

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            check_debug_program = false;
        }

        private void richTextBox1_FontChanged(object sender, EventArgs e)
        {
            //LineNumberTextBox.Font = richTextBox1.Font;
            //richTextBox1.Select();
            //AddLineNumbers();
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

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
