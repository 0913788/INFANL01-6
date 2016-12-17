using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nunit_Singleton_MultiThreadeded_Broken
{
    public class Singleton
    {
        private static readonly object Lock = new object();
        private static Singleton ActiveSingleton = null;
        public int valueX,
                   valueY;

        private Singleton(int x, int y)
        {
            valueX = x;
            valueY = y;
            testCollector.GetCurrentInstance();
            testCollector.AddToTotal(x + y);
        }

        public static Singleton NewInstance(int x, int y)
        {
            if (ActiveSingleton == null)
            {
                ActiveSingleton = new Singleton(x, y);
            }
            return ActiveSingleton;
        }

        public static void RemoveActiveSingleton()
        {
            ActiveSingleton = null;
        }
    }
}
