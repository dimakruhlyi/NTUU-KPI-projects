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

namespace Backpack
{
    public partial class BackCipher : Form
    {
        public BackCipher()
        {
            InitializeComponent();
        }


        string Rus = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯабвгдеёжзийклмнопрстуфхцчшщъыьэюя";
        string symbols = "0123456789!#$%^&*()+=-_'?.,| /`~№:;@[]{}";
        List<int> SumResults;
        int[] openKey = null;
        bool isRussian = false;

        int[] inputWeights = { 12, 20, 33, 72, 142, 289, 580, 1854 };


        private void button1_Click(object sender, EventArgs e)
        {
            textBox4.Text = null;
            textBox5.Text = null;
            textBox22.Text = null;
            isRussian = false;
            int q = textBox1.Text.Length == 0 ? 0 : Convert.ToInt32(textBox1.Text);
            int r = textBox2.Text.Length == 0 ? 0 : Convert.ToInt32(textBox2.Text);
            string source = textBox3.Text.Length == 0 ? null : Convert.ToString(textBox3.Text);


            List<int> Sums = new List<int>();

            foreach (var letter in source)
            {
                string fbits = null;
                string rbits = null;

                //  && !symbols.Contains(letter.ToString())
                if (Rus.Contains(letter.ToString()))
                {
                    byte[] utf8String = Encoding.UTF8.GetBytes(letter.ToString());


                    isRussian = true;
                    fbits = Convert.ToString(utf8String[1], 2).PadLeft(8, '0');
                    rbits = Convert.ToString(utf8String[0], 2).PadLeft(8, '0');

                    Sums.Add(GetSumLetter(ref q, ref r, fbits));
                    Sums.Add(GetSumLetter(ref q, ref r, rbits));

                }
                else if (symbols.Contains(letter.ToString()) && isRussian)
                {
                    byte[] utf8String = Encoding.UTF8.GetBytes(letter.ToString());

                    fbits = Convert.ToString(utf8String[0], 2).PadLeft(8, '0');

                    Sums.Add(GetSumLetter(ref q, ref r, fbits));
                    Sums.Add(-1);
                }
                else
                {
                    fbits = Convert.ToString(Encoding.UTF8.GetBytes(letter.ToString())[0], 2).PadLeft(8, '0');
                    Sums.Add(GetSumLetter(ref q, ref r, fbits));
                }

                textBox5.AppendText(String.Format(fbits + rbits));
                textBox5.AppendText(Environment.NewLine);

            }
            SumResults = new List<int>();
            SumResults.AddRange(Sums);

            foreach (var s in SumResults)
            {
                textBox22.AppendText(s.ToString());
                textBox22.AppendText(Environment.NewLine);
            }



            // q r
            textBox1.Text = q.ToString();
            textBox2.Text = r.ToString();

            // w[]
            textBox25.Text = textBox6.Text;
            textBox26.Text = textBox8.Text;
            textBox27.Text = textBox7.Text;
            textBox28.Text = textBox13.Text;
            textBox29.Text = textBox12.Text;
            textBox30.Text = textBox11.Text;
            textBox31.Text = textBox10.Text;
            textBox32.Text = textBox9.Text;


            textBox3.Text = null;

        }

        int GetSumLetter(ref int q, ref int r, string bits)
        {
            int[] weights = new int[8];
            if (textBox1.Text != string.Empty)
            {
                weights[0] = Convert.ToInt32(textBox6.Text);
                weights[1] = Convert.ToInt32(textBox8.Text);
                weights[2] = Convert.ToInt32(textBox7.Text);
                weights[3] = Convert.ToInt32(textBox13.Text);
                weights[4] = Convert.ToInt32(textBox12.Text);
                weights[5] = Convert.ToInt32(textBox11.Text);
                weights[6] = Convert.ToInt32(textBox10.Text);
                weights[7] = Convert.ToInt32(textBox9.Text);
            }
            else
            {
                openKey = new int[8];
                openKey[0] = Convert.ToInt32(textBox14.Text);
                openKey[1] = Convert.ToInt32(textBox21.Text);
                openKey[2] = Convert.ToInt32(textBox15.Text);
                openKey[3] = Convert.ToInt32(textBox16.Text);
                openKey[4] = Convert.ToInt32(textBox17.Text);
                openKey[5] = Convert.ToInt32(textBox18.Text);
                openKey[6] = Convert.ToInt32(textBox19.Text);
                openKey[7] = Convert.ToInt32(textBox20.Text);
            }

            if (openKey == null)
            {
                MessageBox.Show("No open key generated");
                Application.Exit();
            }



            int S = EncryptByOpenKey(ref bits, ref openKey);

            /*
                textBox14.Text = B[0].ToString();
                textBox21.Text = B[1].ToString();
                textBox15.Text = B[2].ToString();
                textBox16.Text = B[3].ToString();
                textBox17.Text = B[4].ToString();
                textBox18.Text = B[5].ToString();
                textBox19.Text = B[6].ToString();
                textBox20.Text = B[7].ToString();
            */


            return S;
        }

        int GetSumLetterTodecr(ref int q, ref int r, string bits)
        {
            int[] weights = new int[8];
            weights[0] = Convert.ToInt32(textBox6.Text);
            weights[1] = Convert.ToInt32(textBox8.Text);
            weights[2] = Convert.ToInt32(textBox7.Text);
            weights[3] = Convert.ToInt32(textBox13.Text);
            weights[4] = Convert.ToInt32(textBox12.Text);
            weights[5] = Convert.ToInt32(textBox11.Text);
            weights[6] = Convert.ToInt32(textBox10.Text);
            weights[7] = Convert.ToInt32(textBox9.Text);

            int[] B = new int[weights.Length];


            B[0] = Convert.ToInt32(textBox14.Text);
            B[1] = Convert.ToInt32(textBox21.Text);
            B[2] = Convert.ToInt32(textBox15.Text);
            B[3] = Convert.ToInt32(textBox16.Text);
            B[4] = Convert.ToInt32(textBox17.Text);
            B[5] = Convert.ToInt32(textBox18.Text);
            B[6] = Convert.ToInt32(textBox19.Text);
            B[7] = Convert.ToInt32(textBox20.Text);


            int S = EncryptByOpenKey(ref bits, ref B);


            return S;
        }

        private int EncryptByOpenKey(ref string bits, ref int[] B)
        {
            int S = 0;
            for (var i = 0; i < B.Length; i++)
            {
                S += Convert.ToInt32(bits[i].ToString()) * B[i];

                textBox4.AppendText(Convert.ToString(Convert.ToInt32(B[i])));
                textBox4.AppendText(Environment.NewLine);

            }
            textBox4.AppendText(Environment.NewLine);


            return S;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int q = textBox1.Text.Length == 0 ? 0 : Convert.ToInt32(textBox1.Text);
            int r = textBox2.Text.Length == 0 ? 0 : Convert.ToInt32(textBox2.Text);
            string encryptedBits = null;
            string encryptedText = null;

            SumResults = new List<int>();

            string[] resSum = textBox22.Text.Split('\n');
            foreach (var s in resSum)
            {
                if (s != "")
                {
                    SumResults.Add(Convert.ToInt32(s));
                }

            }


            if (isRussian)
            {
                for (int i = 0; i < SumResults.Count - 1; i += 2)
                {
                    encryptedBits = null;

                    if (SumResults[i + 1] == -1)
                    {
                        encryptedBits += GetLetterBits(ref q, ref r, SumResults[i]);
                    }
                    else
                    {
                        encryptedBits += GetLetterBits(ref q, ref r, SumResults[i]);
                        encryptedBits += GetLetterBits(ref q, ref r, SumResults[i + 1]);
                    }

                    var encryptedBytes = GetBytesDa(encryptedBits);
                    encryptedText += Encoding.UTF8.GetString(encryptedBytes);
                }
            }
            else
            {
                foreach (var S in SumResults)
                {

                    encryptedBits = null;
                    encryptedBits += GetLetterBits(ref q, ref r, S);
                    //MessageBox.Show("Reslut encryptedBits" + encryptedBits);
                    var encryptedBytes = GetBytesDa(encryptedBits);
                    encryptedText += Encoding.UTF8.GetString(encryptedBytes);
                }
            }

            textBox3.Text = encryptedText;

        }




        string GetLetterBits(ref int q, ref int r, int S)
        {
            int[] weights = new int[8];
            weights[0] = Convert.ToInt32(textBox6.Text);
            weights[1] = Convert.ToInt32(textBox8.Text);
            weights[2] = Convert.ToInt32(textBox7.Text);
            weights[3] = Convert.ToInt32(textBox13.Text);
            weights[4] = Convert.ToInt32(textBox12.Text);
            weights[5] = Convert.ToInt32(textBox11.Text);
            weights[6] = Convert.ToInt32(textBox10.Text);
            weights[7] = Convert.ToInt32(textBox9.Text);



            int temp = 1;
            while (r * temp % q != 1 % q)
            {
                temp++;
            }
            int multiReverse = r * temp / r;

            int startPos = S * multiReverse % q;

            string encryptedByteStr = null;
            for (var i = 0; i < 8; i++)
            {
                encryptedByteStr += "0";
            }

            int curremtPos = startPos;

            /*
            try
            {
            */
            while (curremtPos - FindLessNumb(ref weights, curremtPos) > -1)
            {
                ReplaceCharInString(ref encryptedByteStr, Array.IndexOf(weights, FindLessNumb(ref weights, curremtPos)), '1');

                curremtPos -= FindLessNumb(ref weights, curremtPos);

                if (curremtPos == 0) break;
            }
            /*
        }

        catch (Exception)
        {
            encryptedByteStr = "10100111";
        }
        */



            return encryptedByteStr;
        }


        private static byte[] GetBytesDa(string bitString)
        {
            byte[] result = Enumerable.Range(0, bitString.Length / 8).
                Select(pos => Convert.ToByte(
                    bitString.Substring(pos * 8, 8),
                    2)
                ).ToArray();

            List<byte> mahByteArray = new List<byte>();
            for (int i = result.Length - 1; i >= 0; i--)
            {
                mahByteArray.Add(result[i]);
            }

            return mahByteArray.ToArray();
        }



        public static void ReplaceCharInString(ref String str, int index, Char newSymb)
        {
            str = str.Remove(index, 1).Insert(index, newSymb.ToString());
        }

        public static int FindLessNumb(ref int[] weights, int curremtPos)
        {
            if (curremtPos < weights[0])
            {
                return weights[0];
            }

            for (var i = 0; i < weights.Length; i++)
            {
                if (curremtPos < weights[i])
                {
                    return weights[i - 1];
                }
            }

            return weights[weights.Length - 1];
        }

        public static class Array<T>
        {
            public static T[] Empty()
            {
                return Empty(0);
            }

            public static T[] Empty(int size)
            {
                return new T[size];
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            System.IO.File.WriteAllText(@"C:\Users\Dima Kruhlyi\Desktop\Backpack\Backpack\result1.txt", textBox4.Text);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            System.IO.File.WriteAllText(@"C:\Users\Dima Kruhlyi\Desktop\Backpack\Backpack\result2.txt", textBox5.Text);
        }


        private void BackCipher_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            string filename = openFileDialog1.FileName;
            string readfile = File.ReadAllText(filename, Encoding.GetEncoding(1251));
            textBox3.Text = readfile;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int q = textBox1.Text.Length == 0 ? 0 : Convert.ToInt32(textBox1.Text);
            int r = textBox2.Text.Length == 0 ? 0 : Convert.ToInt32(textBox2.Text);


            int[] weights = new int[8];
            weights[0] = Convert.ToInt32(textBox6.Text);
            weights[1] = Convert.ToInt32(textBox8.Text);
            weights[2] = Convert.ToInt32(textBox7.Text);
            weights[3] = Convert.ToInt32(textBox13.Text);
            weights[4] = Convert.ToInt32(textBox12.Text);
            weights[5] = Convert.ToInt32(textBox11.Text);
            weights[6] = Convert.ToInt32(textBox10.Text);
            weights[7] = Convert.ToInt32(textBox9.Text);



            int[] B = new int[weights.Length];
            for (var i = 0; i < weights.Length; i++)
            {
                B[i] = weights[i] * r % q;
            }


            textBox14.Text = B[0].ToString();
            textBox21.Text = B[1].ToString();
            textBox15.Text = B[2].ToString();
            textBox16.Text = B[3].ToString();
            textBox17.Text = B[4].ToString();
            textBox18.Text = B[5].ToString();
            textBox19.Text = B[6].ToString();
            textBox20.Text = B[7].ToString();

            openKey = new int[B.Length];
            Array.Copy(B, openKey, B.Length);
        }

        private void textBox34_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox35_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged_1(object sender, EventArgs e)
        {

        }
    }

}

namespace WindowsFormsApp1
{
    class Backpack
    {
        long[] mas_close;
        long[] mas_open;
        int N;
        long M;
        long T;

        //public Backpack()
        //{
        //    //Book_code_Form new_form = new Book_code_Form();
        //    new_form.Text = "Backpack";
        //    new_form.Get_button4_Visible(true);
        //    new_form.ShowDialog();

        //    N = new_form.Get_N();
        //    T = new_form.Get_T();
        //    M = new_form.Get_M();

        //    string key = new_form.Get_Key_backpack();
        //    string[] mas_key = key.Split(new char[] { ' ', '\n', '\t' }, StringSplitOptions.RemoveEmptyEntries);

        //    mas_close = new long[mas_key.Count()];
        //    mas_open = new long[mas_key.Count()];

        //    for (int i = 0; i < mas_key.Count(); i++)
        //    {
        //        mas_close[i] = Convert.ToInt32(mas_key[i]);
        //    }
        //}

        public string encryption(string str)
        {
            string myText = string.Empty;
            string decryption_text = string.Empty;

            foreach (string letter in str.Select(c => Convert.ToString(c, 2)))
            {
                string example = letter;

                if (letter.Length != 7)
                {
                    while (example.Length != 7)
                    {
                        example = example.Insert(0, "0");
                    }
                }

                myText += example;
            }

            int i;
            for (i = 0; i < mas_close.Count(); i++)
            {
                mas_open[i] = (T * mas_close[i]) % M;
            }

            i = 0;
            int count = 0;
            for (i = 0; i < myText.Length / N; i++)
            {
                count = 0;

                for (int j = 0; j < N; j++)
                {

                    count += Convert.ToInt32(mas_open[j] * int.Parse(myText[j + i * N].ToString()));
                }

                decryption_text += count + " ";
            }

            return decryption_text;
        }

        public string decryption(string str)
        {
            T = T1();
            str.Remove(str.Length - 1);
            string[] mesage = str.Split(new char[] { ' ', '\n', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            string text_beginner = string.Empty;
            string byte_symbol = string.Empty;

            for (int i = 0; i < mesage.Count(); i++)
            {
                long count = (T * int.Parse(mesage[i])) % M;

                for (int j = 0; j < N; j++)
                {
                    if (count >= mas_close[N - j - 1])
                    {
                        byte_symbol += "1";
                        count -= mas_close[N - j - 1];
                    }
                    else
                    {
                        byte_symbol += "0";
                    }
                }
            }

            return Split_byte(byte_symbol);
        }

        private char get_char_from_byte(string Mas_byte)
        {
            int count = 0;
            for (int i = 0; i < 7; i++)
            {
                count += int.Parse(Mas_byte[7 - 1 - i].ToString()) * Convert.ToUInt16(Math.Pow(2, i));
            }

            return Convert.ToChar(count);
        }

        private long T1()
        {
            int i = 0;
            for (i = 0; (T * i) % M != 1; i++) ;

            return i;
        }

        private string Split_byte(string mas_byte)
        {
            string resoult_byte = string.Empty;
            string resoult = string.Empty;

            for (int i = 1; i < mas_byte.Count() / N + 1; i++)
            {
                for (int j = N * i - 1; j > N * (i - 1) - 1; j--)
                {
                    resoult_byte += mas_byte[j];
                }
            }

            string symbol = string.Empty;
            for (int i = 0; i < resoult_byte.Count(); i++)
            {
                symbol += resoult_byte[i];

                if (symbol.Count() == 7)
                {
                    resoult += get_char_from_byte(symbol);
                    symbol = string.Empty;
                }
            }

            return resoult;
        }
    }
}