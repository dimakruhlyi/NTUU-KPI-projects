using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheWorker
{
    [Serializable]
    public class Worker
    {
        public int Id
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public string Surname
        {
            get;
            set;
        }

        public int Salary
        {
            get;
            set;
        }

        public string Address
        {
            get;
            set;
        }
    }
}
