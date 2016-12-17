using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nunit_Singleton_MultiThreadeded_Broken
{
    class testCollector
    {
        private static testCollector activeObject = null;
        private static readonly object AddLock = new object();
        private static readonly object CreateLock = new object();

        private static int total = 0;

        private testCollector()
        {

        }

        public static testCollector newInstance()
        {
            if (activeObject == null)
            {
                lock (CreateLock)
                {
                    if (activeObject == null)
                    {
                        activeObject = new testCollector();
                    }
                }
            }
            return activeObject;
        }

        public static int getTotal()
        {
            return total;
        }

        public static testCollector GetCurrentInstance()
        {
            return activeObject;
        }

        public static void AddToTotal(int value)
        {
            lock (AddLock)
            {
                total += value;
            }
        }

        public static void Reset()
        {
            total = 0;
        }
    }
}