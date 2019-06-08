using Microsoft.VisualStudio.TestTools.UnitTesting;
using Deque;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deque.Tests
{
    [TestClass()]
    public class DequeTests
    {
        [TestMethod()]
        public void AddFirstTest()
        {
            var d1 = new Deque<int>();
            int a = 5;

            d1.AddFirst(a);

            Assert.AreEqual<int>(a, d1.RemoveFirst());
        }

        [TestMethod()]
        public void RemoveFirstTest()
        {
            var d1 = new Deque<int>();
            int a = 5;

            d1.AddFirst(a);

            Assert.AreEqual<int>(a, d1.RemoveFirst());
        }

        [TestMethod()]
        public void RemoveLastTest()
        {
            var d1 = new Deque<int>();
            int a = 5;

             d1.AddLast(a);
  
            Assert.AreEqual<int>(a, d1.RemoveLast());
        }

       
        [TestMethod()]
        public void ContainsTest()
        {
            var d1 = new Deque<int>();
            int a = 5;
            int b = 10; 

            d1.AddLast(a);
            d1.AddFirst(b);

            Assert.IsTrue(d1.Contains(a));
        }

        [TestMethod()]
        public void TryingTest()
        {
            var d1 = new Deque<int>();
            int a = 5;

            d1.AddFirst(a);
            d1.AddLast(5);

            Assert.AreEqual<int>(a, d1.RemoveLast());
            
        }

    }
}