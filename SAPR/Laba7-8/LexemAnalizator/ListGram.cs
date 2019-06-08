using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Coursework
{
    class ListGram
    {
        List<string> Lexems = new List<string>();

        public ListGram()
        {
            //OpenFileDialog oppenFile = new OpenFileDialog();
            //if (oppenFile.ShowDialog() != DialogResult.OK)
            //{
            //    MessageBox.Show("File not found!", "Error");
            //}
            //else
            //{
            //    FileStream file = new FileStream(oppenFile.FileName, FileMode.Open);
            //    StreamReader reader = new StreamReader(file);

            //    while (!reader.EndOfStream)
            //    {
            //        string str = reader.ReadLine();
            //        Lexems.Add(str.Substring(str.IndexOf(' ') + 1));
            //    }

            //    reader.Close();
            //}



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
