using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyDictionary;

namespace Mydictionary.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Testadd()
        {
            var a = new MyDictionary.MyDictionary();
            a.Add("aaa","bbb");
            int res = a.alikeWords;
            Assert.AreEqual(1, res);
        }
        [TestMethod]
        public void Testaddnewvalue()
        {
            var a = new MyDictionary.MyDictionary();
            a.Add("aaa", "bbb");
            a.Add("aaa", "bsaas");
            int res1 = a.alikeWords;
            Assert.AreEqual(1, res1);
            
        }
        [TestMethod]
        public void Testdelete()
        {
            var a = new MyDictionary.MyDictionary();
            a.Add("aaa", "bbb");
            a.Add("aaa", "bsaas");
            a.Delete("aaa");
            int v = a.alikeWords;
            Assert.AreEqual(0, v);
        }
        [TestMethod]
        public void Testd()
        {
            var a = new MyDictionary.MyDictionary();
            a.Add("aaa", "bbb");
            a.Add("nhf", "baaaa");
            a.Collector();
            var n = a.wordswithonevalue.Count;
            Assert.AreEqual(2, n); 
        }
    }
}
