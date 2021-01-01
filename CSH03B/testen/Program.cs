using System;
using System.Threading;

namespace testen

{
    class Go
    {

        public void Testen()
        {
            while(true)
            {

                Console.WriteLine("{0}:{1}:{2}", DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
                //Console.WriteLine("\a{0}:",DateTime.Now); ;
                Thread.Sleep(1000);
                Console.WriteLine();
            }
        }

        public static void Main(string[] args)
        {
            Go test1 = new Go();
            test1.Testen();

            
        }
    }
}

