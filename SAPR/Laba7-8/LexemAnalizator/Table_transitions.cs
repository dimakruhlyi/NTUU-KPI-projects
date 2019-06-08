using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Coursework
{
    class Table_transitions
    {
        int Current_state;
        string Mitka;
        int Next_state;
        string Stack;
        string Subroutine;

        public int Current_state1
        {
            get
            {
                return Current_state;
            }

            set
            {
                Current_state = value;
            }
        }

        public string Mitka1
        {
            get
            {
                return Mitka;
            }

            set
            {
                Mitka = value;
            }
        }

        public int Next_state1
        {
            get
            {
                return Next_state;
            }

            set
            {
                Next_state = value;
            }
        }

        public string Stack1
        {
            get
            {
                return Stack;
            }

            set
            {
                Stack = value;
            }
        }

        public string Subroutine1
        {
            get
            {
                return Subroutine;
            }

            set
            {
                Subroutine = value;
            }
        }
    }
}