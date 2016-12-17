using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using NUnit.Framework;

namespace Nunit_Singleton_MultiThreadeded_Fixed
{
    [TestFixture]
    public class SingletonTest
    {
        [Test]
        public void SingletonCreationTest()
        {
            testCollector.newInstance();
            Thread T1 = new Thread(() => Singleton.NewInstance(1));
            Thread T2 = new Thread(() => Singleton.NewInstance(10));
            Thread.Sleep(10);
            T1.Start();
            T2.Start();
            Thread.Sleep(1000);
            CollectionAssert.Contains(new[] { 1, 10 }, testCollector.getTotal());
        }
    }
}