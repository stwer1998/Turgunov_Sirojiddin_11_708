using NUnit.Framework;
using System;
using System.Collections.Generic;
using TimeInterval;

namespace UnitTestsForTimeInterval
{
    public class Tests
    {
        //[SetUp]
        //public void Setup()
        //{
        //}

        [Test]
        public void InitializationTest()
        {
            var start = new DateTime(2015, 12, 12, 12, 12, 12);
            var finish = new DateTime(2015, 12, 12, 12, 12, 13);
            var interval = new TimeInterval.TimeInterval(start, finish);
            Assert.IsTrue(interval.StartOfInterval==start&&interval.EndOfInterval==finish);
        }
        [Test]
        public void InitializationTest1()
        {
            var start = new DateTime(2015, 12, 12, 12, 12, 12);
            var finish = new DateTime(2015, 12, 12, 12, 12, 13);
            var interval = new TimeInterval.TimeInterval(finish,start);
            Assert.IsTrue(interval.StartOfInterval == start && interval.EndOfInterval == finish);
        }

        [Test]
        public void InitializationTestExeption() 
        {
            var start = new DateTime(2015, 12, 12, 12, 12, 12);
            try
            {
                var interval = new TimeInterval.TimeInterval(start, start);
            }
            catch (ArgumentException ex) 
            {
                Assert.AreEqual("Начало и конец не может быть одинаковым", ex.Message);
            }

        }

        [Test]
        public void EqualTest()
        {
            var start = new DateTime(2015, 12, 12, 12, 12, 12);
            var finish = new DateTime(2015, 12, 12, 12, 12, 13);
            var interval = new TimeInterval.TimeInterval(finish, start);
            var interval1=new TimeInterval.TimeInterval(start,finish);
            Assert.IsTrue(interval.Equals(interval1));
        }

        [Test]
        public void NotEqualTest()
        {
            var start = new DateTime(2015, 12, 12, 12, 12, 12);
            var finish = new DateTime(2015, 12, 12, 12, 12, 13);
            var date=new DateTime();
            var interval = new TimeInterval.TimeInterval(date, start);
            var interval1 = new TimeInterval.TimeInterval(start, finish);
            Assert.IsFalse(interval.Equals(interval1));
        }

        [Test]
        public void OperatorEqualTest()
        {
            var start = new DateTime(2015, 12, 12, 12, 12, 12);
            var finish = new DateTime(2015, 12, 12, 12, 12, 13);
            var interval = new TimeInterval.TimeInterval(finish, start);
            var interval1 = new TimeInterval.TimeInterval(start, finish);
            Assert.IsTrue(interval==interval1);
        }

        [Test]
        public void OperatorNotEqualTest()
        {
            var start = new DateTime(2015, 12, 12, 12, 12, 12);
            var finish = new DateTime(2015, 12, 12, 12, 12, 13);
            var date = new DateTime();
            var interval = new TimeInterval.TimeInterval(date, start);
            var interval1 = new TimeInterval.TimeInterval(start, finish);
            Assert.IsFalse(interval!=interval1);
        }

        [Test]
        public void CompareOperationTest() 
        {
            var start = new DateTime(2015, 12, 12, 10, 12, 12);
            var finish = new DateTime(2015, 12, 12, 18, 12, 13);
            var date = new DateTime(2015,12,12,14,12,12);
            var interval = new TimeInterval.TimeInterval(start, finish);
            var interval1 = new TimeInterval.TimeInterval(date, finish);
            Assert.IsTrue(interval < interval1);
        }

        [Test]
        public void CompareOperationTest1()
        {
            var start = new DateTime(2015, 12, 12, 10, 12, 12);
            var finish = new DateTime(2015, 12, 12, 18, 12, 13);
            var date = new DateTime(2015, 12, 12, 14, 12, 12);
            var interval = new TimeInterval.TimeInterval(start, finish);
            var interval1 = new TimeInterval.TimeInterval(date, finish);
            Assert.IsFalse(interval > interval1);
        }

        [Test]
        public void IntersectionTest()
        {
            var start = new DateTime(2015, 12, 12, 10, 12, 12);
            var finish = new DateTime(2015, 12, 12, 18, 12, 13);
            var date = new DateTime(2015, 12, 12, 14, 12, 12);
            var interval = new TimeInterval.TimeInterval(start, finish);
            var interval1 = new TimeInterval.TimeInterval(date, finish);
            Assert.IsTrue(interval.Intersection(interval1)&&interval1.Intersection(interval));
        }

        [Test]
        public void IntersectionTest1()
        {
            var start = new DateTime(2015, 12, 12, 10, 12, 12);
            var finish = new DateTime(2015, 12, 12, 18, 12, 13);
            var date = new DateTime(2015, 12, 12, 14, 12, 12);
            var interval = new TimeInterval.TimeInterval(start, date);
            var interval1 = new TimeInterval.TimeInterval(date, finish);
            Assert.IsFalse(interval.Intersection(interval1));
        }

        [Test]
        public void IntersectionTimeTest()
        {
            var start = new DateTime(2015, 12, 12, 10, 12, 12);
            var finish = new DateTime(2015, 12, 12, 18, 12, 13);
            var date = new DateTime(2015, 12, 12, 14, 12, 12);
            var interval = new TimeInterval.TimeInterval(start, finish);
            var interval1 = new TimeInterval.TimeInterval(date, finish);
            Assert.AreEqual(interval.IntersectionTime(interval1),finish-date);
        }

         [Test]
        public void IntersectionTimeTest1()
        {
            var start = new DateTime(2015, 12, 12, 10, 12, 12);
            var finish = new DateTime(2015, 12, 12, 18, 12, 13);
            var date = new DateTime(2015, 12, 12, 14, 12, 12);
            var interval = new TimeInterval.TimeInterval(start, new DateTime());
            var interval1 = new TimeInterval.TimeInterval(date, finish);
            try
            {
                interval.IntersectionTime(interval1);
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("Интервалы не пересекаются", ex.Message);
            }

        }

        [Test]
        public void IntersectionIntervalTest()
        {
            var start = new DateTime(2015, 12, 12, 10, 12, 12);
            var finish = new DateTime(2015, 12, 12, 18, 12, 13);
            var date = new DateTime(2015, 12, 12, 14, 12, 12);
            var interval = new TimeInterval.TimeInterval(start, finish);
            var interval1 = new TimeInterval.TimeInterval(date, finish);
            Assert.IsTrue(interval.IntersectionInterval(interval1).Equals(new TimeInterval.TimeInterval(date,finish))); 
        }

        [Test]
        public void IntersectionIntervalTest1()
        {
            var start = new DateTime(2015, 12, 12, 10, 12, 12);
            var finish = new DateTime(2015, 12, 12, 18, 12, 13);
            var date = new DateTime(2015, 12, 12, 14, 12, 12);
            var interval = new TimeInterval.TimeInterval(start, new DateTime());
            var interval1 = new TimeInterval.TimeInterval(date, finish);
            try
            {
                interval.IntersectionInterval(interval1);
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("Интервалы не пересекаются", ex.Message);
            }

        }

        [Test]
        public void GetIntervalsWithOutInrersectionTest()
        {
            var a = new DateTime(2019, 10, 25, 0, 0, 0);
            var b = new DateTime(2019, 10, 25, 7, 0, 0);
            var c = new DateTime(2019, 10, 25, 10, 0, 0);
            var d = new DateTime(2019, 10, 25, 3, 0, 0);
            var e = new DateTime(2019, 10, 25, 2, 0, 0);
            var i1 = new TimeInterval.TimeInterval(a, e);
            var i2 = new TimeInterval.TimeInterval(a, d);
            var i3 = new TimeInterval.TimeInterval(b, c);

            var intervals = new List<TimeInterval.TimeInterval> {i1,i2,i3};
            intervals=intervals.GetIntervalsWithOutInrersection();
            var results=new List<TimeInterval.TimeInterval> { 
            new TimeInterval.TimeInterval(a,e),
            new TimeInterval.TimeInterval(e,new DateTime(2019,10,25,4,0,0)),
            new TimeInterval.TimeInterval(d,new DateTime(2019,10,25,7,0,0))
            };
            var flag = true;
            for (int i = 0; i < results.Count; i++)
            {
                if (intervals[i] != results[i]) 
                {
                    flag = false;
                }
            }
            Assert.IsTrue(flag);
        }

    }
}