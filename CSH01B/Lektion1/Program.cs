using System;

namespace Lektion1
{

    class Luftfahrzeug
    {
        protected string kennung;
        protected string Herkunftsland;

        public Luftfahrzeug() : base ()
        { }

        public Luftfahrzeug(string kennung)
        {
            this.kennung = kennung;
        }

        public void Steigen(int meter)
        {
        Console.WriteLine(kennung + " steigt " + meter + " Meter ");
        }

        public void Sinken(int meter)
        {
        Console.WriteLine(kennung + " sinkt " + meter + " Meter ");
        }

    }
    class Flugzeug : Luftfahrzeug 
    {
        public Flugzeug(string kennung) : base(kennung)
        { }
    }
    class Starrflügelflugzeug : Luftfahrzeug
    {
        public Starrflügelflugzeug(string kennung) : base(kennung)
        { }
    }
    class Düsenflugzeug : Luftfahrzeug
    {
        public Düsenflugzeug(string kennung) : base(kennung)
        { }
    }

    class Program
    {
        public void Message(string Message)
        {
            Console.WriteLine(Message);
        }
    }

    class Go
    {
        public static void Main(string[] args)
        {
            //Luftfahrzeug Stephan = new Luftfahrzeug("LH 4080");
            //Stephan.Steigen(100);
            Program Message1 = new Program();
            Message1.Message("Hallo peter ich bins Stephan");
            
        }
    }
 }
