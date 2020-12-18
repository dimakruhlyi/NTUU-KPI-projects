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
using System.Security.Cryptography;

namespace WindowsFormsApp1
{
    public partial class Main : System.Windows.Forms.Form
    {
        String way = "";
        DESCryptoServiceProvider cryptic;
        RSACryptoServiceProvider rsa;

        
        byte[] RSA;
        public Main()
        {
            InitializeComponent();
            cryptic = new DESCryptoServiceProvider();
            

            checkBox7.Checked = true;
            number_decryption = 7;

            //checkBox8.Visible = false;
            
        }


        //About the program
        private void проПрограмуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Круглий Д.В.  \nГрупа ТР-61    \ndimakruhly@gmail.com", "a bit about me", MessageBoxButtons.OK);
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
            switch (number_decryption)
            {
                case 1:
                    Caesar encryption_Caesar = new Caesar();
                    richTextBox1.Text = encryption_Caesar.encryption(richTextBox1.Text);
                    break;

                case 2:
                    Tritemius encryption_Tritemius = new Tritemius();
                    richTextBox1.Text = encryption_Tritemius.encryption(richTextBox1.Text, false);
                    break;

                case 3:
                    gamm encryption_Gamm = new gamm();
                    richTextBox1.Text = encryption_Gamm.encryption(richTextBox1.Text);
                    //label1.Text = encryption_Gamm.str_key();
                    break;

                case 4:
                    Book_code encryption_Book_code = new Book_code();
                    richTextBox1.Text = encryption_Book_code.encryption(richTextBox1.Text);
                    break;

                case 5:
                    DES encryption_DES = new DES();
                    richTextBox1.Text = encryption_DES.encryption(richTextBox1.Text, cryptic.Key, cryptic.IV);
                    break;

                case 6:
                    Backpack encryption_Backpack = new Backpack();
                    richTextBox1.Text = encryption_Backpack.encryption(richTextBox1.Text);
                    break;

                case 7:
                    RSA encryption_RSA = new RSA ();
                    Book_code_Form q = new Book_code_Form();
                    q.Get_button4_Visible(false);
                    q.ShowDialog();
                    string st_key = q.Get_Key_backpack();

                    richTextBox1.Text = encryption_RSA.encryption(richTextBox1.Text, st_key);
                    RSA = encryption_RSA.Encrypti_byte;
                    label1.Text = rsa.ToXmlString(false) + "\n" + rsa.ToXmlString(true);
                    //label1.Visible = true;
                    break;
                       
                case 0:
                    MessageBox.Show("Виберіть метод шифрування", "Error:", MessageBoxButtons.OK);
                    break;
            } 
        }

        //decryption
        private void дишифруванняToolStripMenuItem_Click(object sender, EventArgs e)
        {
            switch (number_decryption)
            {
                case 1:
                    Caesar decryption_Caesar = new Caesar();
                    richTextBox1.Text = decryption_Caesar.decryption(richTextBox1.Text);
                    break;

                case 2:
                    Tritemius decryption_Tritemius = new Tritemius();
                    richTextBox1.Text = decryption_Tritemius.decryption(richTextBox1.Text);
                    break;

                case 3:
                    gamm decryption_Gamm = new gamm();
                    richTextBox1.Text = decryption_Gamm.decryption(richTextBox1.Text);
                    break;

                case 4:
                    Book_code decryption_Book_code = new Book_code();
                    richTextBox1.Text = decryption_Book_code.decryption(richTextBox1.Text);
                    break;

                case 5:
                    DES decryption_DES = new DES();
                    richTextBox1.Text = decryption_DES.decryption(richTextBox1.Text, cryptic.Key, cryptic.IV);
                    break;

                case 6:
                    Backpack decryption_Backpack = new Backpack();
                    richTextBox1.Text = decryption_Backpack.decryption(richTextBox1.Text);
                    break;

                case 7:
                    RSA decryption_RSA = new RSA();
                    decryption_RSA.Encrypti_byte = RSA;
                    Book_code_Form q = new Book_code_Form();
                    q.Get_button4_Visible(false);
                    q.ShowDialog();
                    string st_key = q.Get_Key_backpack();

                    richTextBox1.Text = decryption_RSA.decryption(richTextBox1.Text, st_key);
                    //label1.Visible = false;
                    break;

                case 0:
                    MessageBox.Show("Виберіть метод дешифрування", "Error:", MessageBoxButtons.OK);
                    break;
            }
        }


        //private void checkBox1_Click(object sender, EventArgs e)
        //{
        //    checkBox2.Checked = false;
        //    checkBox3.Checked = false;
        //    checkBox4.Checked = false;
        //    checkBox5.Checked = false;
        //    checkBox6.Checked = false;
        //    checkBox7.Checked = false;
        //    checkBox8.Checked = false;

        //    number_decryption = 1;
        //    if (!checkBox1.Checked)
        //    {
        //        number_decryption = 0;
        //    }
        //}

        //private void checkBox2_Click(object sender, EventArgs e)
        //{
        //    checkBox1.Checked = false;
        //    checkBox3.Checked = false;
        //    checkBox4.Checked = false;
        //    checkBox5.Checked = false;
        //    checkBox6.Checked = false;
        //    checkBox7.Checked = false;
        //    checkBox8.Checked = false;

        //    number_decryption = 2;
        //    if (!checkBox2.Checked)
        //    {
        //        number_decryption = 0;
        //    }
        //}

        //private void checkBox3_Click(object sender, EventArgs e)
        //{
        //    checkBox1.Checked = false;
        //    checkBox2.Checked = false;
        //    checkBox4.Checked = false;
        //    checkBox5.Checked = false;
        //    checkBox6.Checked = false;
        //    checkBox7.Checked = false;
        //    checkBox8.Checked = false;

        //    number_decryption = 3;
        //    if (!checkBox3.Checked)
        //    {
        //        number_decryption = 0;
        //    }
        //}

        //private void checkBox4_Click(object sender, EventArgs e)
        //{
        //    checkBox1.Checked = false;
        //    checkBox2.Checked = false;
        //    checkBox3.Checked = false;
        //    checkBox5.Checked = false;
        //    checkBox6.Checked = false;
        //    checkBox7.Checked = false;
        //    checkBox8.Checked = false;

        //    number_decryption = 4;
        //    if (!checkBox4.Checked)
        //    {
        //        number_decryption = 0;
        //    }
        //}

        //private void checkBox5_Click(object sender, EventArgs e)
        //{
        //    checkBox1.Checked = false;
        //    checkBox2.Checked = false;
        //    checkBox3.Checked = false;
        //    checkBox4.Checked = false;
        //    checkBox6.Checked = false;
        //    checkBox7.Checked = false;
        //    checkBox8.Checked = false;

        //    number_decryption = 5;
        //    if (!checkBox5.Checked)
        //    {
        //        number_decryption = 0;
        //    }
        //}

        //private void checkBox6_Click(object sender, EventArgs e)
        //{
        //    checkBox1.Checked = false;
        //    checkBox2.Checked = false;
        //    checkBox3.Checked = false;
        //    checkBox4.Checked = false;
        //    checkBox5.Checked = false;
        //    checkBox7.Checked = false;
        //    checkBox8.Checked = false;

        //    number_decryption = 6;
        //    if (!checkBox6.Checked)
        //    {
        //        number_decryption = 0;
        //    }
        //}

        private void checkBox7_Click(object sender, EventArgs e)
        {
            //checkBox1.Checked = false;
            //checkBox2.Checked = false;
            //checkBox3.Checked = false;
            //checkBox4.Checked = false;
            //checkBox5.Checked = false;
            //checkBox6.Checked = false;
            //checkBox8.Checked = false;

            number_decryption = 7;
            if (!checkBox7.Checked)
            {
                number_decryption = 0;
            }
        }

        //private void checkBox8_Click(object sender, EventArgs e)
        //{
        //    checkBox1.Checked = false;
        //    checkBox2.Checked = false;
        //    checkBox3.Checked = false;
        //    checkBox4.Checked = false;
        //    checkBox5.Checked = false;
        //    checkBox6.Checked = false;
        //    checkBox7.Checked = false;

        //    number_decryption = 8;
        //    if (!checkBox8.Checked)
        //    {
        //        number_decryption = 0;
        //    }
        //}

        private void згенеруватиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rsa = new RSACryptoServiceProvider(2048);
            rsa.PersistKeyInCsp = false;


            string publicK = rsa.ToXmlString(false);
            string privateK = rsa.ToXmlString(true);
            Key a = new Key();
            a.Get_key(publicK, privateK);
            a.ShowDialog();


        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBox33_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
