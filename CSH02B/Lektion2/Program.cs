using System;

namespace Lektion2
{

    class Uebung
    {

        public void Arrayhandling()
        {
            int[] Quadratzahlen = new int[5];
            Quadratzahlen[0] = 2 * 2;
            Quadratzahlen[1] = 3 * 3;
            Quadratzahlen[2] = 4 * 4;
            Quadratzahlen[3] = 5 * 5;
            Quadratzahlen[4] = 6 * 6;

            //Console.WriteLine(Quadratzahlen[3]);

            Console.WriteLine(Quadratzahlen[Quadratzahlen.Length - 1]);
        }
    }



    class Luftfahrzeug
    {
        protected string kennung;
        public Luftfahrzeug(string kennung)
        {
            this.kennung = kennung;
        }

        public override string ToString()
        {
            return "Luftfahrzeug mit der Kennung:" + kennung;
        }

        private Luftfahrzeug[] Fliegerarray = new Luftfahrzeug[3] {
        new Luftfahrzeug("LH 100"),
        new Luftfahrzeug("LH 200"),
        new Luftfahrzeug("LH 300"),
        };

    }

    class Stringtypen
    {
        public string name;
        public Stringtypen (string name)
        {
            this.name = name;
        }
    }
  

    class StringtypTesten
    {
        public void Stringtypen()
        {
            Stringtypen a = new Stringtypen("Hans");
            Stringtypen b = a;
                Console.WriteLine("Stringtyp a = " + a.name);
                a.name = "Stephan";
                Console.WriteLine("Stringtyp b nach aenderung von a = " + b.name);
        }
        
    }

    class Zeichenketten
    {
        public void Zeichenkette()
        {
            char[] zeichen = { 'Z','e','i','c','h','e','n','k','e','t','t','e' };
            String Zeichenkette = new string(zeichen);
            Console.WriteLine(Zeichenkette);
        }
    }
        


    class Go
    {
        public static void Main(string[] args)
        {
            StringtypTesten test1 = new StringtypTesten();
            test1.Stringtypen();
            Zeichenketten test2 = new Zeichenketten();
            test2.Zeichenkette();

        }
    }
}
