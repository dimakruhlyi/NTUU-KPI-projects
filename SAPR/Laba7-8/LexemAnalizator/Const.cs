using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coursework
{
    class Const
    {
        int _index_const;
        string _name;

        public int Index_const
        {
            get
            {
                return _index_const;
            }

            set
            {
                _index_const = value;
            }
        }

        public string Name
        {
            get
            {
                return _name;
            }

            set
            {
                _name = value;
            }
        }
    }
}
