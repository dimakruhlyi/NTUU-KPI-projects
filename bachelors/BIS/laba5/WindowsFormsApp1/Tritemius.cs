using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class Tritemius : str
    {
        int variable_A, variable_B, variable_C;
        int key = 0;
        string st_key = "";

        public Tritemius()
        {
            Tritemius_Form Q = new Tritemius_Form();
            Q.ShowDialog();

            variable_A = Q.A();
            variable_B = Q.B();
            variable_C = Q.C();
            st_key = Q.Motto_Key();
        }

        public string encryption(string b, bool dec)
        {
            String a = "";
            int i = 0;

            while (i != b.Length)
            {
                if (st_all.Contains(b[i]))
                {
                    int index = st_all.IndexOf(b[i]);
                    key = (variable_C == 0) ? variable_A * i + variable_B : variable_A * i * i + variable_B * i + variable_C;

                    if (dec) key = -1 * key % st_all.Length;

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


            if (st_key.Length != 0 && dec == false)
            {
                return encryption_motto(a, false);
            }
            return a;
        }

        public string encryption_motto(string b, bool dec)
        {
            String a = "";
            int i = 0;
            int n = 0;

            while (i != b.Length)
            {
                if (st_all.Contains(b[i]) && st_all.Contains(st_key[n]))
                {
                    int index = st_all.IndexOf(b[i]);
                    int index_key = st_all.IndexOf(st_key[n]);

                    if (dec) index_key *= -1;

                    int y = (index + index_key + st_all.Length) % st_all.Length;
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

            key = 0;
            return a;
        }

        public string decryption(string b)
        {
            if (st_key.Length != 0)
            {
                string a = encryption_motto(b, true);
                return encryption(a, true);
            }

            return encryption(b, true);
        }
    }
}
