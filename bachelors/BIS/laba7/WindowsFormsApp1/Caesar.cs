using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class Caesar : str
    {
        int key = 0;
        

        public Caesar()
        {
            Caeasar_form Q = new Caeasar_form();
            Q.ShowDialog();

            if (Q.Get_Key() != "")
            {
                key = Convert.ToInt32(Q.Get_Key());
            }
        }

        public string encryption(string b)
        {
            String a = "";
            int i = 0;
            key = key % st_letters.Length;

            while (i != b.Length)
            {
                if (st_letters.Contains(b[i]))
                {
                    int index = st_letters.IndexOf(b[i]);
                    int y = (index + key + st_letters.Length) % st_letters.Length;
                    a += st_letters[y];
                }
                else
                {
                    a += b[i];
                }

                i++;
            }
            key = 0;

            return a;
        }

        public string decryption(string b)
        {
            key = -1 * key % st_letters.Length;
            return encryption(b);
        }
    }
}

