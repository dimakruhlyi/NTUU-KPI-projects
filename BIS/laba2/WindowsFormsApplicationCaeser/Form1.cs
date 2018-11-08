using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplicationCaeser
{
    interface Icipher
    {
        void Encrypt();
        void EncryptBySlogan();
        void Decrypt();
        void DecryptBySlogan();
    }

    public partial class WindowTrithemius : Form, Icipher
    {
        private string alphaUpper = null;
        private string alphaLower = null;
        private string sourceString = null;
        private string result = null;
        private string slogan = null;
        private string symbols = "0123456789!#$%^&*()+=-_'?.,| /`~№:;@[]{}";

        private int alphSize = 0;
        private int key = 0;
        private int A = 0;
        private int B = 0;
        private int C = 0;

        // numbers array

        public WindowTrithemius()
        {
            InitializeComponent();
            //this.comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;

            englishToolStripMenuItem.Checked = true;

            alphaUpper = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            alphaLower = "abcdefghijklmnopqrstuvwxyz";
            russianToolStripMenuItem.Checked = false;
        }

        private void Initial()
        {
           

            //if (comboBox1.Text.ToString().Equals("Eng"))
            //{
            //    alphaUpper = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            //    alphaLower = "abcdefghijklmnopqrstuvwxyz";
            //}
            //else
            //{
            //    alphaUpper = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";
            //    alphaLower = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";
            //}

            slogan = textBox6.Text.Length == 0 ? null : textBox6.Text.ToString();

            //MessageBox.Show(slogan.GetHashCode().ToString());
            
            alphSize = alphaLower.Length;
            if (!int.TryParse(textBox2.Text, out A)) A = 0;
            if (!int.TryParse(textBox4.Text, out B)) B = 0;
            if (!int.TryParse(textBox5.Text, out C)) C = 0;
            

            /*
            if (A < 0 || B < 0 || C < 0)
            {
                MessageBox.Show("Wrong input data");
                Application.Exit();
            }
            */

            sourceString = textBox1.Text.ToString();

            result = null;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Initial();
            if (slogan != null)
            {
                
                EncryptBySlogan();
            }
            else
            {
                
                Encrypt();
            }
        }

        public void EncryptBySlogan()
        {
            Initial();
            key = Math.Abs(alphSize + slogan.GetHashCode());

            
            for (var i = 0; i < sourceString.Length; i++)
            {

                int index = 0;

      
                if (Char.IsLower(sourceString[i]))
                {
                    index = alphaLower.IndexOf(sourceString[i]);
                    result += alphaLower[(key + index) % alphSize];
                }
                else if (Char.IsUpper(sourceString[i]))
                {
                    index = alphaUpper.IndexOf(sourceString[i]);
                    result += alphaUpper[(key + index) % alphSize];
                }
                else
                {
                    index = symbols.IndexOf(sourceString[i]);
                    result += symbols[(key + index) % symbols.Length];
                }
                


            }

            textBox1.Text = null;
            textBox1.Text = result;

            //MessageBox.Show($"Encrypted text : {result}");
        }

        public void Encrypt()
        {
            for (var i = 0; i < sourceString.Length; i++)
            {

                int index = 0;

                key = (!int.TryParse(textBox5.Text, out C)) ? A * i + B : A * i * i + B * i + C;
                key = Math.Abs(alphSize + key);

                if (Char.IsLower(sourceString[i]))
                {
                    //MessageBox.Show($"key {key}");
                    index = alphaLower.IndexOf(sourceString[i]);
                    result += alphaLower[(key + index) % alphSize];
                    
                }
                else if (Char.IsUpper(sourceString[i]))
                {
                    index = alphaUpper.IndexOf(sourceString[i]);
                    result += alphaUpper[(key + index) % alphSize];
                }
                else
                {
                    index = symbols.IndexOf(sourceString[i]);
                    result += symbols[(key + index) % symbols.Length];
                }


            }

            textBox1.Text = null;
            textBox1.Text = result;
            

        }



        private void button2_Click(object sender, EventArgs e)
        {
            Initial();

            if (slogan != null)
            {
                DecryptBySlogan();
            }
            else
            {
                Decrypt();
            }
        }

        public void DecryptBySlogan()
        {
            Initial();

            key = Math.Abs(alphSize + slogan.GetHashCode());
            


            //key = Math.Abs(alphSize - key);
            //Encrypt();

            for (var i = 0; i < sourceString.Length; i++)
            {

                int index = 0;


                if (Char.IsLower(sourceString[i]))
                {
                    index = alphaLower.IndexOf(sourceString[i]);
                    result += alphaLower[(index + alphSize - (key % alphSize)) % alphSize];
                }
                else if (Char.IsUpper(sourceString[i]))
                {
                    index = alphaUpper.IndexOf(sourceString[i]);
                    result += alphaUpper[(index + alphSize - (key % alphSize)) % alphSize];
                }
                else
                {
                    index = symbols.IndexOf(sourceString[i]);
                    result += symbols[(index + symbols.Length - (key % symbols.Length)) % symbols.Length];
                }



            }

            textBox1.Text = null;
            textBox1.Text = result;
        }

        public void Decrypt()
        {

            for (var i = 0; i < sourceString.Length; i++)
            {

                int index = 0;

                key = (!int.TryParse(textBox5.Text, out C)) ? A * i + B : A * i * i + B * i + C;
                key = Math.Abs(alphSize + key);

                if (Char.IsLower(sourceString[i]))
                {
                    index = alphaLower.IndexOf(sourceString[i]);
                    result += alphaLower[(index + alphSize - (key % alphSize)) % alphSize];
                }
                else if (Char.IsUpper(sourceString[i]))
                {
                    index = alphaUpper.IndexOf(sourceString[i]);
                    result += alphaUpper[(index + alphSize - (key % alphSize)) % alphSize];
                }
                else
                {
                    index = symbols.IndexOf(sourceString[i]);
                    result += symbols[(index + symbols.Length - (key % symbols.Length)) % symbols.Length];
                }


            }

            textBox1.Text = null;
            textBox1.Text = result;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void Window_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

       

        private void encryptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Initial();
            if (slogan != null)
            {

                EncryptBySlogan();
            }
            else
            {

                Encrypt();
            }
        }

        private void decryptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Initial();

            if (slogan != null)
            {
                DecryptBySlogan();
            }
            else
            {
                Decrypt();
            }
        }

        private void languageToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void englishToolStripMenuItem_Click(object sender, EventArgs e)
        {
            englishToolStripMenuItem.Checked = true;

            alphaUpper = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            alphaLower = "abcdefghijklmnopqrstuvwxyz";
            russianToolStripMenuItem.Checked = false;
        }

        private void comboBox1_Click(object sender, EventArgs e)
        {

        }

        private void russianToolStripMenuItem_Click(object sender, EventArgs e)
        {
            russianToolStripMenuItem.Checked = true;

            alphaUpper = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";
            alphaLower = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";
            englishToolStripMenuItem.Checked = false;
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
           
        }

        private void readToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = File.ReadAllText(dialog.FileName);
            }

        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog2 = new SaveFileDialog();
            dialog2.Filter = "txt files |*.txt|All files |*.*";
           
            if (dialog2.ShowDialog() == DialogResult.OK)
            {
                StreamWriter writer = new StreamWriter(dialog2.FileName, false);

                writer.WriteLine(textBox1.Text);
                writer.Close();
            }
                
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dialog = new DialogResult();

            dialog = MessageBox.Show("Вите надо выйти?", "Alert!", MessageBoxButtons.YesNo);

            if (dialog == DialogResult.Yes)
            {
                System.Environment.Exit(1);
            }
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrintDialog PrintDialog1 = new PrintDialog();
            PrintDialog1.ShowDialog();
        }

        private void informationToolStripMenuItem_Click(object sender, EventArgs e)
        {

            DialogResult dialog = new DialogResult();

            dialog = MessageBox.Show("Dima Kruhlyi\nTR-61\nTrithemius Cipher", "Alert!", MessageBoxButtons.OK);
        }

      
    }
}
