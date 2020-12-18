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
        public Form1()
        {
            InitializeComponent();
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
            Debug_Lexem program = new Debug_Lexem();
            program.Split_Lexem(richTextBox1.Text + '\n');

            dataGridView1.DataSource = program.table_lexem();
            dataGridView2.DataSource = program.table_const();
            dataGridView3.DataSource = program.table_id();
        }
    }
}
