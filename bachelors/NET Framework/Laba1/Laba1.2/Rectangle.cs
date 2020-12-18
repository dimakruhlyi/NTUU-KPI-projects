using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba1._2
{
    public class Rectangle
    {
        int a, b;
        public double Perymetr()
        {
            return (a + b) * 2; ;
        }
        public Rectangle(int a2, int b2)
        {
            a = a2;
            b = b2;
        }
        public Rectangle()
        {
            a = 1;
            b = 1;
        }
    }
}
