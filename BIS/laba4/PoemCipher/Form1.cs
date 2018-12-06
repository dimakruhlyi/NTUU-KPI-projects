using System;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Collections.Generic;

namespace PoemCipher
{
    interface ICipher
    {
        string GetNumb(char letter);

        string Decryption();
    }

    public partial class PoemMain : Form, ICipher
    {

        string symbols = "0123456789!#$%^&*()+=-_'?.,| /`~№:;@[]{}";

        string source = null;
        string encrypted = null;
        string decrypted = null;

        const int N = 14;
        const int M = 14;

        char[,] table = new char[N, M];


        public PoemMain()
        {
            InitializeComponent();
            string line;
            int i = 0;

            StreamReader sr = new StreamReader(@"C:\Users\Dima Kruhlyi\Desktop\PoemCipher\poem.txt", Encoding.Default);
            while ((line = sr.ReadLine()) != null)
            {
                int search = 0;

                if (i < N)
                {
                    for (var j = 0; j < M; j++)
                    {
                        char tempLetter;
                        tempLetter = Convert.ToChar(line.Substring(search, 1));
                        /*
                        while (symbols.Contains(tempLetter.ToString()))
                        {
                            search++;
                            tempLetter = Convert.ToChar(line.Substring(search, 1));
                        }
                        */

                        table[i, j] = tempLetter;
                        search++;
                    }
                    i++;
                }
                //else sr.Close();
            }

            ShowTable();

        }

        internal void ShowTable()
        {
            for (int m = 0; m < N; m++)
            {
                for (int n = 0; n < M; n++)
                {
                    textBox2.Text += table[m, n] + " ";
                }
                textBox2.Text += Environment.NewLine;
            }
        }


        public string GetNumb(char letter)
        {
            Random rnd = new Random();
            List<string> letters = new List<string>();

            for (int m = 0; m < N; m++)
            {
                for (int n = 0; n < M; n++)
                {
                    if (letter == table[m, n])
                    {
                        letters.Add(String.Format($"{m}/{n},"));
                    }
                }
            }

            return letters[rnd.Next(0, letters.Count)];


        }


        public string Decryption()
        {
            string decrypted = string.Empty;
            string[] words = encrypted.Split(',');

            int[] indexes = new int[encrypted.Length * 2];
            int i = 0;
            foreach (var word in words)
            {
                string[] numbers = word.Split('/');

                foreach (var num in numbers)
                {
                    int.TryParse(num, out int parsedResult);
                    indexes[i] = parsedResult;
                    i++;
                }

            }

            for (int j = 0; j < indexes.Length / 4; j += 2)
            {
                decrypted += table[indexes[j], indexes[j + 1]];
            }

            return decrypted;

        }


        private void button1_Click(object sender, EventArgs e)
        {
            source = textBox1.Text.Length == 0 ? null : textBox1.Text.ToString();
            encrypted = null;
            for (var i = 0; i < source.Length; i++)
            {
                encrypted += GetNumb(source[i]);
            }

            
            textBox2.Text = encrypted;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            encrypted = textBox1.Text.Length == 0 ? null : textBox1.Text.ToString();
            decrypted = Decryption();
            textBox2.Text = decrypted;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            System.IO.File.WriteAllText(@"C:\Users\Dima Kruhlyi\Desktop\PoemCipher\result.txt", textBox2.Text);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
