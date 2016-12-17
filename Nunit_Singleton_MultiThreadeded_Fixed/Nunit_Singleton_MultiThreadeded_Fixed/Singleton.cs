using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nunit_Singleton_MultiThreadeded_Fixed
{
    public class Singleton
    {
        private static readonly object Lock = new object();
        private static Singleton ActiveSingleton = null;
        public int valueX;

        private Singleton(int x)
        {
            valueX = x;
            testCollector.GetCurrentInstance();
            testCollector.AddToTotal(x);
        }

        public static Singleton NewInstance(int x)
        {
            if (ActiveSingleton == null)
            {
                lock (Lock)
                {
                    if (ActiveSingleton == null)
                    {
                        ActiveSingleton = new Singleton(x);
                    }
                }
            }
            return ActiveSingleton;
        }

        public static void RemoveActiveSingleton()
        {
            ActiveSingleton = null;
        }
    }
}
