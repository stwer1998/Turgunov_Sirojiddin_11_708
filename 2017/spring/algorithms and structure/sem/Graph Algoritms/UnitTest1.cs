using System;
using ConsoleApp2;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        public void FordBellman3()
        {
            var d = new Graph();
            d.MakeGraph(5);
            d.Connect(0, 1, 7);
            d.Connect(0, 2, 2);
            d.Connect(0, 3, 2);
            d.Connect(2, 4, 3);
            d.Connect(2, 1, 2);
            d.Connect(3, 4, 5);
            d.Connect(3, 1, 1);
            var res = d.FordBellman(0);
            Assert.AreEqual(3, res[1]);
            Assert.AreEqual(5, res[4]);
        }

        [TestMethod]
        public void FordBellman4()
        {
            var a = new Graph();
            a.MakeGraph(8);
            a.Connect(0, 1, 1);
            a.Connect(0, 2, 3);
            a.Connect(0, 3, 2);
            a.Connect(1, 2, 1);
            a.Connect(1, 4, 1);
            a.Connect(1, 5, 3);
            a.Connect(2, 5, 1);
            a.Connect(3, 5, 1);
            a.Connect(3, 6, 1);
            a.Connect(4, 7, 5);
            a.Connect(5, 7, 1);
            a.Connect(6, 7, 3);
            var res = a.FordBellman(0);
            Assert.AreEqual(2, res[4]);
            Assert.AreEqual(3, res[6]);
            Assert.AreEqual(4, res[7]);

        }
        [TestMethod]
        public void Dijkstra4()
        {
            var a = new Graph();
            a.MakeGraph(8);
            a.Connect(0, 1, 1);
            a.Connect(0, 2, 3);
            a.Connect(0, 3, 2);
            a.Connect(1, 2, 1);
            a.Connect(1, 4, 1);
            a.Connect(1, 5, 3);
            a.Connect(2, 5, 1);
            a.Connect(3, 5, 1);
            a.Connect(3, 6, 1);
            a.Connect(4, 7, 5);
            a.Connect(5, 7, 1);
            a.Connect(6, 7, 3);
            var res = a.Dijkstra(0);
            Assert.AreEqual(2, res[4]);
            Assert.AreEqual(3, res[6]);
            Assert.AreEqual(4, res[7]);

        }

        [TestMethod]
        public void FordBellman1()
        {
            var a = new Graph();
            a.MakeGraph(4);
            a.Connect(0, 1, 1);
            a.Connect(0, 2, 2);
            a.Connect(0, 3, 6);
            a.Connect(1, 3, 4);
            a.Connect(2, 3, 2);
            var res = a.Dijkstra(0);
            Assert.AreEqual(4, res[3]);
        }
        [TestMethod]
        public void Dijkstra1()
        {
            var a = new Graph();
            a.MakeGraph(4);
            a.Connect(0, 1, 1);
            a.Connect(0, 2, 2);
            a.Connect(0, 3, 6);
            a.Connect(1, 3, 4);
            a.Connect(2, 3, 2);
            var res = a.Dijkstra(0);
            Assert.AreEqual(4, res[3]);
        }

        [TestMethod]
        public void Dijkstra2()
        {
            var a = new Graph();
            a.MakeGraph(6);
            a.Connect(0, 1, 1);
            a.Connect(1, 2, 1);
            a.Connect(1, 3, 3);
            a.Connect(2, 3, 1);
            a.Connect(2, 4, 3);
            a.Connect(4, 5, 1);
            a.Connect(3, 4, 1);
            a.Connect(5, 4, 1);
            a.Connect(5, 2, 1);
            a.Connect(5, 3, 1);
            a.Connect(5, 1, 1);
            var res = a.Dijkstra(0);
            Assert.AreEqual(0, res[0]);
            Assert.AreEqual(1, res[1]);
            Assert.AreEqual(2, res[2]);
            Assert.AreEqual(3, res[3]);
            Assert.AreEqual(4, res[4]);
            Assert.AreEqual(5, res[5]);
        }

        [TestMethod]
        public void Dijkstra3()
        {
            var a = new Graph();
            a.MakeGraph(5);
            a.Connect(0, 1, 7);
            a.Connect(0, 2, 2);
            a.Connect(0, 3, 2);
            a.Connect(2, 4, 3);
            a.Connect(2, 1, 2);
            a.Connect(3, 4, 5);
            a.Connect(3, 1, 1);
            var res = a.Dijkstra(0);
            Assert.AreEqual(3, res[1]);
            Assert.AreEqual(5, res[4]);

        }

        [TestMethod]
        public void FordBellman2()
        {
            var a = new Graph();
            a.MakeGraph(6);
            a.Connect(0, 1, 1);
            a.Connect(1, 2, 1);
            a.Connect(1, 3, 3);
            a.Connect(2, 3, 1);
            a.Connect(2, 4, 3);
            a.Connect(4, 5, 1);
            a.Connect(3, 4, 1);
            a.Connect(5, 4, 1);
            a.Connect(5, 2, 1);
            a.Connect(5, 3, 1);
            a.Connect(5, 1, 1);
            var res = a.FordBellman(0);
            Assert.AreEqual(0, res[0]);
            Assert.AreEqual(1, res[1]);
            Assert.AreEqual(2, res[2]);
            Assert.AreEqual(3, res[3]);
            Assert.AreEqual(4, res[4]);
            Assert.AreEqual(5, res[5]);

        }

    }
}
