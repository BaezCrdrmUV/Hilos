using System;
using System.Threading;

namespace Threads
{
    class Program
    {
        static void Main(string[] args)
        {
            MonoCount();
        }

        public static void MonoCount(string name = "thread", int loops = 100, int millisecond = 500)
        {
            for (int i = 0; i < loops; i++)
            {
                Console.WriteLine("{0} L-{1}", name, i);
                Thread.Sleep(millisecond);
            }
        }
    }
}
