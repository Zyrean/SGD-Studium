using System;

namespace Einsendeaufgaben
{
    class Aufgaben
    {
        public void Aufgabe1()
        {
            Console.WriteLine("Vordefinierte Typen sind alle Typen aus dem .NET Framework (zB: System. Console. Object. ...)");
        }
        public void Aufgabe2()
        {
            Console.WriteLine("Einfache Typen sind ");
            Console.WriteLine("uint, int, ushort, short, ulong, long, string, double, float, char, bool, decimal, object, system");
            Console.WriteLine("class, enum, interface, struct");
        }

        public void Aufgabe3(int n)
        {
            int ergebnis = 1;
            int zahl = 1;

            for (zahl = 1; zahl <= n; zahl++ )
            {
                ergebnis *= zahl++;
                Console.WriteLine("Fakultaet von {0} = {1}", n, ergebnis);
            }

        }

        public void UlamVermutung()
        {

            decimal zahl1 = 100;
            decimal ergebnis = zahl1;

            while (zahl1 > 0)
            {

            }
            Console.WriteLine(ergebnis);

            if (zahl1 != 1 & zahl1 < 0)//"gerade")
            {
                zahl1>> ;
                Console.WriteLine("Ergebnis gerade: {0} ", ergebnis);
            }
            else if (zahl1 != 1 & zahl1 > 0)//"ungerade")
            {
                zahl1 *= zahl1++;
                Console.WriteLine("Ergebnis ungerade: {0} ", ergebnis);
            }

        }

        public void Testen(int n)
        {
            double zahl = 1;
            double ergebnis = 1;

            ergebnis *= zahl++;
            Console.WriteLine(ergebnis);
        }

    }

    class Go
    {
        public static void Main(string[] args)
        {
            Aufgaben test1 = new Aufgaben();
            //test1.Aufgabe1();
            //test1.Aufgabe2();
            /*test1.Aufgabe3(2);
            test1.Aufgabe3(3);
            test1.Aufgabe3(5);
            test1.Aufgabe3(7);
            test1.Aufgabe3(10);*/
            test1.UlamVermutung();
        }
    }
}
