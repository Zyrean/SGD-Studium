using System;

namespace Testen
{

    class Testen
    {
        public void Fahrstuhl(uint Stockwerk)
        {
            switch(Stockwerk)
            {
                case 0:
                    Console.WriteLine("Sie befinden sich im Ergeschoss");
                    break;
                case 1:
                    Console.WriteLine("Sie befinden sich im 1st Obergeschoss");
                    break;
                case 2:
                    Console.WriteLine("Sie befinden sich im 2nd Obergeschoss");
                    break;
                case 3:
                    Console.WriteLine("Sie befinden sich im 3rd Obergeschoss");
                    break;
                case 4:
                    Console.WriteLine("Sie befinden sich im Dachgeschoss");
                    break;
                default:
                    Console.WriteLine("Error! Dieses Stockwerk existiert nicht");
                    break;
            }
        }

        public void Fahrstuhl1(uint Stockwerk)
        {
            if (Stockwerk == 0)
            {
                Console.WriteLine("Sie befinden sich im Ergeschoss");
            }
            else if (Stockwerk == 1)
            {
                Console.WriteLine("Sie befinden sich im 1st Obergeschoss");
            }
            else if (Stockwerk == 2)
            {
                Console.WriteLine("Sie befinden sich im 2nd Obergeschoss");
            }
            else if (Stockwerk == 3)
            {
                Console.WriteLine("Sie befinden sich im 3rd Obergeschoss");
            }
            else if (Stockwerk == 4)
            {
                Console.WriteLine("Sie befinden sich im Dachgeschoss");
            }
            else
            {
                Console.WriteLine("Error! Dieses Stockwerk existiert nicht");
            }
        }


        public void SwtichZaehler(int n)
        {
            string ausgabe = "Wir zaehlen: ";
            string ende = "Error!, ";

            switch(n > 5? 5 : n)
            {
                case 1: ausgabe += "eins, ";
                    goto case 2;
                case 2: ausgabe += "zwei, ";
                    goto case 3;
                case 3: ausgabe += "drei, ";
                    goto case 4;
                case 4: ausgabe += "vier, ";
                    goto case 5;
                case 5: ausgabe += "fuenf, ";
                    goto case 6;
                case 6: ausgabe += "ganz viele, ";
                    break;
                default: ende += "kann nicht zaehlen";
                    break;

            }

            Console.WriteLine(ausgabe);
        }

        public void Zaehlen()
        {
            for (int i = 100; i >= 0; i -= 10)
                Console.WriteLine(i);
        }
    }

    class Go
    {

        public static void Main(string[] args)
        {
            Testen test1 = new Testen();
            test1.Zaehlen();


        }
    }
}
