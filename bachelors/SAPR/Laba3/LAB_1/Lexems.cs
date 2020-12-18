using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB_1
{
    class Lexems
    {
        int _line;
        string _subcategory;
        int _index;
        string _key;

        public int Line
        {
            get
            {
                return _line;
            }

            set
            {
                _line = value;
            }
        }

        public string Subcategory
        {
            get
            {
                return _subcategory;
            }

            set
            {
                _subcategory = value;
            }
        }

        
        public int Index
        {
            get
            {
                return _index;
            }

            set
            {
                _index = value;
            }
        }

        public string Key
        {
            get
            {
                return _key;
            }

            set
            {
                _key = value;
            }
        }
    }
}
