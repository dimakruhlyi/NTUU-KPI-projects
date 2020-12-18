using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.IO;

namespace LAB_1
{
    class ListGrammar
    {
        List<string> Lexems = new List<string>();

        public ListGrammar()
        {
            FileStream file = new FileStream("gram.txt", FileMode.Open);
            StreamReader reader = new StreamReader(file);

            while (!reader.EndOfStream)
            {
                string str = reader.ReadLine();
                Lexems.Add(str.Substring(str.IndexOf(' ') + 1));
            }

            reader.Close();
        }

        public int Find_Lexem(string str)
        {
            return Lexems.IndexOf(str) + 1;
        }
    }
}
