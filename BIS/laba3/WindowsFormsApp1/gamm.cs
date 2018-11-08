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
            Form2 a = new Form2();
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
          
            while (i != b.Length)
            {
                if (st.Contains(b[i]))
                {
                    int q1 = st.IndexOf(b[i]);
                    int q2 = st.IndexOf(st_key[n]);
                    int index_key = q1 ^ q2;

                    int y = (index_key + st.Length) % st.Length; 
                    a += st[y];
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
    }
}
