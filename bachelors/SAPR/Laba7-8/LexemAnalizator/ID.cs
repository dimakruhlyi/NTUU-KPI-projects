using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coursework
{
    class ID
    {
        int _index_id;
        string _name;
        string _type;
        string _value;

        public int Index_id
        {
            get
            {
                return _index_id;
            }

            set
            {
                _index_id = value;
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

        public string Type
        {
            get
            {
                return _type;
            }

            set
            {
                _type = value;
            }
        }

        public string Value { get => _value; set => _value = value; }
    }
}
