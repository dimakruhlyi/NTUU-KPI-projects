using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WindowsFormsApp1
{
    class Backpack
    {
        long[] mas_close;
        long[] mas_open;
        int N;
        long M;
        long T;

        public Backpack()
        {
            Book_code_Form new_form = new Book_code_Form();
            new_form.Text = "Backpack";
            new_form.Get_button4_Visible(true);
            new_form.ShowDialog();

            N = new_form.Get_N();
            T = new_form.Get_T();
            M = new_form.Get_M();

            string key = new_form.Get_Key_backpack();
            string [] mas_key = key.Split(new char[] {' ', '\n', '\t'}, StringSplitOptions.RemoveEmptyEntries);

            mas_close = new long[mas_key.Count()];
            mas_open = new long[mas_key.Count()];

            for (int i = 0; i < mas_key.Count(); i++)
            {
                mas_close[i] = Convert.ToInt32( mas_key[i]);
            }
        }

        public string encryption(string str)
        {
            string myText = string.Empty;
            string decryption_text = string.Empty;

            foreach (string letter in str.Select(c => Convert.ToString(c, 2)))
            {
                string example = letter;

                if (letter.Length != 7)
                {
                    while(example.Length != 7)
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
            for (i = 0; (T * i) % M != 1; i++);

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
