using System;

namespace Lektion4
{

    class Uebungen
    {
        public void Sequenz(int a, int b, int c, int d, int e)
        {
            int r1 = b * c;
            Console.WriteLine("{0} = {1} * {2}", r1 = b * c);
            int r2 = a + r1;
            Console.WriteLine("{0} = {1} * {2}", r2 = a + r1);
            int r3 = d - e;
            Console.WriteLine("{0} = {1} * {2}", r3 = d - e);
            int r4 = r2 * r3;
            Console.WriteLine("{0} = {1} * {2}", r4 = r2 * r3);

            Console.WriteLine("Kontrolle: {0}", (a + b * c) - (d - e));
            
        }

        public void EinfacheAuswahl(int alter, string name)
        {
            const int volljaehrig = 18;

            if (alter == volljaehrig)
            {
                Console.WriteLine("{0}, du bist volljaehrig und darfst waehlen", name);
            }
            else if (alter > volljaehrig)
            {
                Console.WriteLine("{0}, du bist volljaehrig und darfst waehlen", name);
            }
            else
            {
                Console.WriteLine("{0}, du bist NICHT volljaehrig", name);
            }
        }

        public void AlternativeAuswahl(bool CSHinteressiert, bool VBinteressiert)
        {
          
            if (CSHinteressiert)
            {
                Console.WriteLine("Wir schicken ihnen Unterlagen zum CSH Lehrgang");
            }
            else if (VBinteressiert)
            {
                Console.WriteLine("Wir schicken ihnen Unterlagen zum VB Lehrgang");
            }
            else
            {
                Console.WriteLine("Wir schicken ihnen Unterlagen zu anderen Lehrgaengen");
            }
        }

        public void Fahrstuhl(uint Stockwerk)
        {
            switch(Stockwerk)
            {
                case 0:
                    Console.WriteLine("Sie haben Stockwerk 'Erdgeschoss' erreicht!");
                    break;
                case 1:
                    Console.WriteLine("Sie haben Stockwerk '1 Obergeschoss' erreicht!");
                    break;
                case 2:
                    Console.WriteLine("Sie haben Stockwerk '2 Obergeschoss' erreicht!");
                    break;
                case 3:
                    Console.WriteLine("Sie haben Stockwerk 'Dachgeschoss' erreicht!");
                    break;
                default:
                    Console.WriteLine("Error! Stockwerk exisitiert nicht!");
                    break;

            }
        }

        public double FakultaetWhile(int n)
        {
            double ergebnis = 1;
            int zaehler = 1;

            while (zaehler <= n)
            {
                ergebnis *= zaehler++;
            }

            Console.WriteLine("Fakultaet von {0} ({0}!) = {1}", n, ergebnis );
            return ergebnis;
        }

        public double FakultaetDoWhile(int n)
        {
            double ergebnis = 1;
            int zaehler = 1;

            do
            {
                ergebnis *= zaehler++;
            }
            while (zaehler <= n);

                Console.WriteLine("Fakultaet von {0} ({0}!) = {1}", n, ergebnis);
            return ergebnis;
        }

        public void ForEach(string [] Values)
        {
            foreach (string value in Values)
            {
                Console.WriteLine(value);
            }
        }

        public void ForEachNames(string[] Names)
        {
            foreach (string value in Names)
            {
                Console.WriteLine(value);
            }
        }
    }

    
    class Go
    {
        public static void Main(string[] args)
        {
            Uebungen test1 = new Uebungen();
            
            string[] Values = { "eins", "zwei", "drei", "vier" };
            test1.ForEach(Values);
            string[] Names = { "Stephan", "Florian", "Monika", "Roland" };
            int[] Age = {29, 32, 65, 69};
            test1.ForEachNames(Names);



        }
    }
}
