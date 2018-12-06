using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    class Book_code : str
    {
        string[] st_key;
        int count_line;
        char[,] mas_key;

        List<mas_count_letters> list = new List<mas_count_letters>();

        public Book_code()
        {
            Book_code_Form new_form = new Book_code_Form();
            new_form.ShowDialog();

            count_line = new_form.Get_count();
            st_key = new string[count_line];
            st_key = new_form.Get_Key();
        }

        public string encryption(string b)
        {
            String a = "";
            int q = 0;
            Random myRandom = new Random();

            b = b.ToLower();
            initial_mas();

            if (st_key == null)
            {
                return b;
            }

            while (q < b.Length)
            {
                a += find_index_letter_for_encryption(b[q], myRandom);
                q++;
            }

            a = a.Remove(a.Length - 2, 2);
            return a;
        }

        public string decryption(string b)
        {
            String a = "";
            int q = 0;

            string[] result = b.Split(new char[] { '/', ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
            initial_mas();

            while (q < result.Length - 1)
            {
                a += mas_key[Convert.ToInt32(result[q]), Convert.ToInt32(result[q + 1])];
                q += 2;
            }

            return a;
        }


        private void initial_mas()
        {
            mas_key = new char[count_line, 10];

            for (int i = 0; i < count_line; i++)
            {
                int count = 0;

                try
                {
                    for (int j = 0; j < 10; j++)
                    {
                        st_key[i] = st_key[i].ToLower();
                        while (st_letters.IndexOf(st_key[i][count]) == -1)
                        {
                            count++;
                        }

                        mas_key[i, j] = st_key[i][count];

                        int result = IndexOf(list, st_key[i][count]);
                        if (result != -1)
                        {
                            list[result].Count += 1;
                        }
                        else
                        {
                            list.Add(new mas_count_letters() { Letter = st_key[i][count], Count = 1 });
                        }

                        count++;
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Кількість літер у рядку повинна бути більше 10", "Error", MessageBoxButtons.OK);
                    return;
                }
            }
        }

        private int IndexOf(List<mas_count_letters> list, char example)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Letter == example)
                {
                    return i;
                }
            }
            return -1;
        }

        private string find_index_letter_for_encryption(char symbol, Random myRandom)
        {
            int index_list = IndexOf(list, symbol);
            int value_random = -1;

            if (index_list != -1)
            {
                value_random = myRandom.Next(1, list[index_list].Count + 1);
            }
            else
            {
                return "";
            }

            int count = 0;
            for (int i = 0; i < count_line; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (symbol == mas_key[i, j])
                    {
                        count++;

                        if (value_random == count)
                        {
                            return i.ToString() + "/" + j.ToString() + ", ";
                        }
                    }
                }
            }

            return "";
        }
    }
}
