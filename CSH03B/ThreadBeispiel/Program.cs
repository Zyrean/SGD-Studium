using System;
using System.Threading;

namespace ThreadBeispiel

{

    class Go
    {
        public void PorgrammTakten()
        {
            while (true)
            {
                Console.WriteLine("\r{0}",DateTime.Now);
                Thread.Sleep(1000);
            }
        }


        public static void Main(string[] args)
        {
            Go test1 = new Go();
            test1.PorgrammTakten();
            //Console.WriteLine(DateTime.Today);
            //Console.WriteLine(DateTime.Now);

        }
    }
}
