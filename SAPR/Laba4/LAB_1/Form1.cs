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
        Debug_Syntax_2 program;
        int next_state = 1;
        Debug_syntax_3 New_object;
        int present_token = 0;
        List<int> Stack3 = new List<int>();
        int Count_stack = 0;
        int state = 0;

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

            label5.Text = string.Empty;
            button3_Click(this, null);
            button1.Enabled = false;
            label6.Text = string.Empty;

            dataGridView5.Visible = false;
            button1.Visible = false;
            label1.Visible = false;
            label6.Visible = false;
            label7.Visible = false;
            button3.Visible = false;
            dataGridView6.Visible = false;
            dataGridView7.Visible = false;
            button2.Visible = false;
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
            dataGridView4.Visible = true;

            dataGridView5.Visible = false;
            button1.Visible = false;
            label1.Visible = false;
            label6.Visible = false;
            label7.Visible = false;
            button3.Visible = false;
            dataGridView6.Visible = false;
            dataGridView7.Visible = false;
            button2.Visible = false;

            debugToolStripMenuItem1.Visible = true;
        }

        private void tableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = true;
            dataGridView2.Visible = true;
            dataGridView3.Visible = true;
            dataGridView4.Visible = false;

            richTextBox1.Visible = false;
            label2.Visible = true;
            label3.Visible = true;
            label4.Visible = true;
            label4.Location = new System.Drawing.Point(322, 323);
            label4.Text = "Teble con";
            LineNumberTextBox.Visible = false;

            dataGridView5.Visible = false;
            button1.Visible = false;
            label1.Visible = false;
            label6.Visible = false;
            label7.Visible = false;
            button3.Visible = false;

            dataGridView6.Visible = false;
            dataGridView7.Visible = false;
            button2.Visible = false;

            debugToolStripMenuItem1.Visible = false;

        }

        private void debugToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (!check_debug_program)
            {
                Debug_Syntax_1 program = new Debug_Syntax_1(richTextBox1.Text + '\n');

                dataGridView4.DataSource = program.Get_error_message();
                dataGridView1.DataSource = program.table_lexem();
                dataGridView2.DataSource = program.table_const();
                dataGridView3.DataSource = program.table_id();
                int a = dataGridView4.Size.Width;
                int b = dataGridView4.Columns[0].Width;
                int c = dataGridView4.Columns[1].Width;
                dataGridView4.Columns[1].Width = a - b - 43;
            }


            //if (dataGridView4.RowCount == 0 && dataGridView1.RowCount > 0 && !check_debug_program)
            //{
            //    //tableToolStripMenuItem_Click(this, e);
            //    tableToolStripMenuItem.Visible = true;
            //}
            //else
            //{
            //    tableToolStripMenuItem.Visible = false;
            //}
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

        private void debugSyntaxMPAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!check_debug_program)
            {
                //dataGridView5.DataSource = program.Get_MPA();


                //dataGridView1.DataSource = program.table_lexem();
                //dataGridView2.DataSource = program.table_const();
                //dataGridView3.DataSource = program.table_id();
                //int a = dataGridView4.Size.Width;
                //int b = dataGridView4.Columns[0].Width;
                //int c = dataGridView4.Columns[1].Width;
                //dataGridView4.Columns[1].Width = a - b - 43;
            }


            if (dataGridView4.RowCount == 0 && dataGridView1.RowCount > 0 && !check_debug_program)
            {
                //tableToolStripMenuItem_Click(this, e);
                tableToolStripMenuItem.Visible = true;
            }
            else
            {
                tableToolStripMenuItem.Visible = false;
            }
            check_debug_program = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (program.Get_count_Lexem() == 0)
            {
                program.error("No keyword Program", "");
            }

            dataGridView4.DataSource = program.Get_error_message();
            if (present_token < program.Get_count_Lexem() && !program.get_check_error())
            {
                int q = present_token;
                if (q + 1 >= program.Get_count_Lexem())
                {
                    q = program.Get_count_Lexem() - 2;
                }
                label6.Text = program.get_lexem(q + 1);
                next_state = program.next_step(next_state, present_token);
                dataGridView4.DataSource = program.Get_error_message();
                

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

                if (next_state == 0 && Count_stack == 0 && present_token + 1 == program.Get_count_Lexem())
                {
                    button1.Enabled = false;
                    MessageBox.Show("The program is completed successfully");
                    label6.Text = string.Empty;
                }
            }
            else
            {
                label6.Text = string.Empty;
                button1.Enabled = false;
                MessageBox.Show("It is not possible to continue to program the program", "Error");
            }

            
            if (dataGridView4.Rows.Count == 0 && Count_stack <= program.Get_count())
            {
                present_token++;
            }
            

            Stack3 = program.Get_Stack();
            Count_stack = program.Get_count();

            string str = string.Empty;
            for (int j = 0; j < Stack3.Count(); j++)
            {
                str += "  " + Stack3[j];
            }
            label5.Text = str;
            //dataGridView4.DataSource = program.Get_error_message();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            program = new Debug_Syntax_2(richTextBox1.Text + '\n');
            if (richTextBox1.Text != string.Empty)
            {
                label6.Text = program.get_lexem(0);
            }

            dataGridView5.DataSource = program.Get_MPA();
            dataGridView5.Rows[0].Selected = true;
           

            dataGridView1.DataSource = program.table_lexem();
            dataGridView2.DataSource = program.table_const();
            dataGridView3.DataSource = program.table_id();
            dataGridView4.DataSource = program.Get_error_message();

            int a = dataGridView4.Size.Width;
            int b = dataGridView4.Columns[0].Width;
            int c = dataGridView4.Columns[1].Width;
            dataGridView4.Columns[1].Width = a - b - 43;

            button1.Enabled = true;

            present_token = 0;
            next_state = 1;

            
        }

        private void debugSyntax2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            label1.Text = "Stack ---";
            label1.Location = new System.Drawing.Point(754, 30);
            dataGridView1.Visible = false;
            dataGridView2.Visible = false;
            dataGridView3.Visible = false;

            richTextBox1.Visible = true;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            LineNumberTextBox.Visible = true;
            dataGridView4.Visible = true;
            label1.Visible = false;
            dataGridView5.Visible = true;
            button1.Visible = true;
            label1.Visible = true;
            label6.Visible = true;
            label7.Visible = true;
            button3.Visible = true;
            dataGridView6.Visible = false;
            dataGridView7.Visible = false;
            button2.Visible = false;

            debugToolStripMenuItem1.Visible = true;
        }

        private void infoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Debug_syntax_1 = Recursive descent\nDebug_syntax_2 = MPA disassembly\nDebug_syntax_3 = Simple forward", "Info", MessageBoxButtons.OK);
        }

        private void debugSyntax3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            New_object = new Debug_syntax_3(richTextBox1.Text + '\n');
            dataGridView6.DataSource = New_object.Get_Data();


            dataGridView7.Location = new System.Drawing.Point(590, 533);
            dataGridView7.Size = new System.Drawing.Size(450, 200);

            label1.Text = "Матриця відношення == EQ";
            label4.Text = "Таблиця\nFIRST*";
            label1.Location = new System.Drawing.Point(850, 30);
            label4.Location = new System.Drawing.Point(515, 600);
            state = 0;
            button2.Visible = true;
            dataGridView6.Visible = true;
            dataGridView1.Visible = false;
            dataGridView2.Visible = false;
            dataGridView3.Visible = false;
            dataGridView7.Visible = false;
            label1.Visible = true;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            LineNumberTextBox.Visible = true;
            dataGridView4.Visible = false;

            dataGridView5.Visible = false;
            button1.Visible = false;
            label6.Visible = false;
            label7.Visible = false;
            button3.Visible = false;
            richTextBox1.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            switch (state)
            {
                case 0:
                    New_object.Initial_relation_state2();
                    dataGridView7.DataSource = New_object.Get_First();
                    dataGridView7.Visible = true;
                    label4.Visible = true;
                    break;

                case 1:
                    New_object.Initial_relation_state2_3();
                    label4.Visible = false;
                    dataGridView7.Visible = false;
                    break;

                case 2:
                    New_object.Initial_relation_state3();
                    dataGridView7.DataSource = New_object.Get_Last();
                    dataGridView7.Visible = true;
                    label4.Text = "Таблиця\nLAST*";
                    label4.Visible = true;
                    break;

                case 3:
                    New_object.Initial_relation_state2_4();
                    label4.Visible = false;
                    dataGridView7.Visible = false;
                    break;

                case 4:
                    dataGridView7.DataSource = New_object.Get_Stack();
                    dataGridView7.Location = new System.Drawing.Point(46, 533);
                    dataGridView7.Size = new System.Drawing.Size(994, 200);
                    dataGridView7.Visible = true;
                    New_object.Last_relation_state();
                    break;
            }

            state++;
        }
    }
}
