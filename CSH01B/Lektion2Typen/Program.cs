using System;

namespace Lektion2Typen
{
    class Referenztyp
    {
        public int value;
        public Referenztyp(int value)
        {
            this.value = value;
        }
    }

    class Program
    {
        static void ReferenztypTesten()
        {
            Referenztyp a = new Referenztyp(12345);
            Referenztyp b = a;

            Console.WriteLine("b = " + b.value);

            a.value = 0;

            Console.WriteLine("b nach aenderung von a = " + b.value);
        }

        static void WerttypenTesten()
        {
            int a = 12345;
            int b = a;

            Console.WriteLine("b = " + b);

            a = 0;

            Console.WriteLine("b nach aenderung von a = " + b);
        }

        static void Main(string[] args)
        {
            Program.WerttypenTesten();
            Program.ReferenztypTesten();
            
        }
    }
}
