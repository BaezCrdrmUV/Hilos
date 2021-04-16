using System;
using System.Threading;

namespace Threads
{
    class Program
    {
        static int total = 100;
        static void Main(string[] args)
        {
            // Validación y asignación de número personalizado de vueltas
            if(args.Length > 1 && String.IsNullOrEmpty(args[1]))
            {
                try
                {
                    total = Int32.Parse(args[1]);
                }
                catch (System.Exception) { }
            }

            if(args.Length == 0 || args[0] == "mono")
            {
                MonoCount("1MonoCount1", total);
                MonoCount("2MonoCount2", total, 200);
            }
            else if(args[0] == "multi")
            {
                // Nuevo hilo
                Thread thread = new Thread(new ThreadStart(MultiCount));
                thread.Start();

                // Hilo principal
                MonoCount("1MonoCount1", total, 100);
                // Sincronización
                thread.Join();
            }
        }

        public static void MonoCount(string name = "thread", int loops = 100, int millisecond = 500)
        {
            for (int i = 0; i < loops; i++)
            {
                Console.WriteLine("{0} L-{1}", name, i);
                Thread.Sleep(millisecond);
            }
        }

        public static void MultiCount()
        {
            MonoCount("Multi-Count", total, 700);
        }
    }
}
