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
            Form2 Q = new Form2();
            Q.ShowDialog();
            
            key = Convert.ToInt32(Q.Get_Key());
        }

        public string encryption(string b)
        {
            String a = "";
            int i = 0;
            key = key % st.Length;

            while (i != b.Length)
            {
                if (st.Contains(b[i]))
                {
                    int index = st.IndexOf(b[i]);
                    int y = (index + key + st.Length) % st.Length;
                    a += st[y];
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
            key = -1 * key % st.Length;
            return encryption(b);
        }
    }
}

