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
            key = key % st_all.Length;

            while (i != b.Length)
            {
                if (st_all.Contains(b[i]))
                {
                    int index = st_all.IndexOf(b[i]);
                    int y = (index + key + st_all.Length) % st_all.Length;
                    a += st_all[y];
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
            key = -1 * key % st_all.Length;
            return encryption(b);
        }
    }
}

