using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB_1
{
    class Rules
    {
        string Name_Rules;
        string[] Values_Rules;

        public string Name_Rules1
        {
            get
            {
                return Name_Rules;
            }

            set
            {
                Name_Rules = value;
            }
        }

        public string[] Values_Rules1
        {
            get
            {
                return Values_Rules;
            }

            set
            {
                Values_Rules = value;
            }
        }

        //public void Set_size_Values_Rules(int size)
        //{
        //    Values_Rules = new string[size];
        //}

        public int Get_size_Values_Rules()
        {
            return Values_Rules1.Count();
        }

        //public void Set_Values_Rules(string[] values)
        //{
        //    Values_Rules1 = values;
        //}
    }
}
