using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class gamm : str
    {
        string st_key = "";

        public gamm()
        {
            Caeasar_form a = new Caeasar_form();
            a.Text = "Gamm";
            a.ShowDialog();

            st_key = a.Get_Key();
        }
        
        public string encryption(string b)
        {
            String a = "";
            int i = 0;
            int n = 0;

            if (st_key.Length == 0)
            {
                return b;
            }

            if (st_key.Length < b.Length)
            {
                Random random_number = new Random();
                for (int value = b.Length - st_key.Length; value > 0; value--)
                { 
                    st_key += st_all[random_number.Next(1, st_all.Length)];
                }
            }

            while (i != b.Length)
            {
                if (st_all.Contains(b[i]))
                {
                    int q1 = st_all.IndexOf(b[i]);
                    int q2 = st_all.IndexOf(st_key[n]);
                    int index_key = q1 ^ q2;

                    int y = (index_key + st_all.Length) % st_all.Length;
                    a += st_all[y];
                    n++;
                }
                else
                {
                    a += b[i];
                }

                i++;

                if (st_key.Length == n)
                {
                    n = 0;
                }
            }

            
            return a;
        }

        public string decryption(string b)
        {
            return encryption(b);
        }

        public string str_key()
        {
            return st_key;
        }
    }
}
