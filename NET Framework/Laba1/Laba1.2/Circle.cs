using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Reflection;

//[assembly: AssemblyVersion("2.0.0.0")]
namespace Laba1._2
{
    public class Circle
    {
        int radius;
        int a, b;
        public double P()
        {
            return 2 * Math.PI * radius;
        }
        public Circle(int a2, int b2, int radius2)
        {
            a = a2;
            b = b2;
            radius = radius2;
        }
        public Circle()
        {
            a = 0;
            b = 0;
            radius = 1;
        }
    }
}
