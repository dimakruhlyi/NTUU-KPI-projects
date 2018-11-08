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
    public partial class Form1 : System.Windows.Forms.Form
    {
        String way = "";
        
        
        public Form1()
        {
            InitializeComponent();
        }


        //About the program
        private void проПрограмуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Dima Kruhlyi.  \nГрупа ТР-61    \ndimakruhly@gmail.com", "Info", MessageBoxButtons.OK);
        }

        //Open
        private void откритьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog oppenFile = new OpenFileDialog();
            
            if (oppenFile.ShowDialog() == DialogResult.OK)
            {
                way = oppenFile.FileName;
                richTextBox1.Text = File.ReadAllText(oppenFile.FileName);
            }

            this.Text = "Шифрування - " + oppenFile.FileName;
        }

        //Save
        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
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
                сохранитьКакToolStripMenuItem_Click(this, e);
            }
        }

        //Save as
        private void сохранитьКакToolStripMenuItem_Click(object sender, EventArgs e)
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

        //Close
        private void закритьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            way = "";
            richTextBox1.Clear();
            
        }

        //Printing
        private void друкToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrintDialog printFile = new PrintDialog();
            printFile.ShowDialog();
        }

        //Output
        private void вихідToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        //encryption
        private void шифруванняToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Tritemius a = new Tritemius();
            //richTextBox1.Text = a.encryption(richTextBox1.Text, false);

            //Caesar a = new Caesar();
            //richTextBox1.Text = a.encryption(richTextBox1.Text);

            gamm a = new gamm();
            richTextBox1.Text = a.encryption(richTextBox1.Text);
        }

        //decryption
        private void дишифруванняToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Tritemius a = new Tritemius();
            //richTextBox1.Text = a.decryption(richTextBox1.Text);

            gamm a = new gamm();
            richTextBox1.Text = a.decryption(richTextBox1.Text);

            //Caesar a = new Caesar();
            //richTextBox1.Text = a.decryption(richTextBox1.Text);
        }   
    }
}
