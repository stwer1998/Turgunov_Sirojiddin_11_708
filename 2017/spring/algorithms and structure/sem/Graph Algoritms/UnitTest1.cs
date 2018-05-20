using System;
using ConsoleApp2;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Dijkstra()
        {
            var a = new Graph();
            a.MakeGraph(4);
            a.Connect(0, 1, 1);
            a.Connect(0, 2, 2);
            a.Connect(0, 3, 6);
            a.Connect(1, 3, 4);
            a.Connect(2, 3, 2);
            var res=a.Dijkstra(0);
            Assert.AreEqual(4, res[3]);
        }
        [TestMethod]
        public void FordBellman()
        {
            var a = new Graph();
            a.MakeGraph(4);
            a.Connect(0, 1, 1);
            a.Connect(0, 2, 2);
            a.Connect(0, 3, 6);
            a.Connect(1, 3, 4);
            a.Connect(2, 3, 2);
            var res = a.FordBellman(0);
            Assert.AreEqual(4, res[3]);
        }
    }
}
