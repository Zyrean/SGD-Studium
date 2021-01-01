using System;

namespace Lektion1
{
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
    }

    
    class Uebungen
    {

        public void Konsolenausgabe()
        {
            string ort = "Darmstadt";
            int jahr = 2012;
            int ausgabe = 227;
            string waehrung = "Euro";

            Console.WriteLine(" Die Einwohner von {0} haben im Jahr {1} {2} Millionen {3} ausgegeben ", ort, jahr, ausgabe, waehrung);
        }

        public void ObjectMethoden()
        {
            Luftfahrzeug flieger1 = new Luftfahrzeug("LH 1000");
            Luftfahrzeug flieger2 = new Luftfahrzeug("LH 2000");
            Luftfahrzeug flieger3 = flieger1;

            Console.WriteLine("flieger 1 = flieger 2 ? {0}", flieger1.Equals(flieger2));
            Console.WriteLine("flieger 1 = flieger 3 ? {0}", flieger1.Equals(flieger3));
            Console.WriteLine("flieger 1 - Hashcode {0}", flieger1.GetHashCode());
            Console.WriteLine("flieger 2 - Hashcode {0}", flieger2.GetHashCode());
            Console.WriteLine("flieger 3 - Hashcode {0}", flieger3.GetHashCode());
            //Console.WriteLine("flieger 1 To.String: {0}", flieger1.ToString());
            Console.WriteLine("fliefer 1 Kennung: {0}", flieger1.ToString());

        }

        public void ObjektZuweisen()
        {
            object obj1 = new object();
            object obj2 = new Luftfahrzeug(" LH 2000 ");
            object obj3 = 12;
            object obj4 = "Stephan";

            Console.WriteLine(obj1);
            Console.WriteLine(obj2);
            Console.WriteLine(obj3);
            Console.WriteLine(obj4);

            Console.WriteLine(obj1.GetType());
            Console.WriteLine(obj2.GetType());
            Console.WriteLine(obj3.GetType());
            Console.WriteLine(obj4.GetType());

        }
    }

    class Go
    {
        public static void Main(string[] args)
        {
            Uebungen ue = new Uebungen();
            ue.ObjektZuweisen();
            
            

        }
    }
}
