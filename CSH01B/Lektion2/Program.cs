using System;

namespace Lektion2
{

    enum Airbus { A300, A310, A318, A319, A320, A321, A330, A340, A350, A380 }
    
    struct Position
    {
        public int x, y, h;

        public Position(int x, int y, int h)
        {
            this.x = x;
            this.y = y;
            this.h = h;
        }

        public void PositionÄndern(int DeltaX, int DeltaY, int DeltaH)
        {
            x = x + DeltaX;
            y = y + DeltaY;
            h = h + DeltaH;
        }

    }

    class Luftfahrzeug
    {
        protected string kennung;
        protected string Herkunftsland;

        public Airbus typ;

        public Position pos;

        public Luftfahrzeug() : base()
        { }

        public Luftfahrzeug(string kennung, Position pos)
        {
            this.kennung = kennung;
            this.pos = pos;
        }

        public void Steigen(int meter)
        {
            pos.PositionÄndern(0, 0, meter);
            Console.WriteLine(kennung + " steigt " + meter + " Meter," + " neue Hoehe = " + pos.h);
        }

        public void Sinken(int meter)
        {
            pos.PositionÄndern(0, 0, -meter);
            Console.WriteLine(kennung + " sinkt " + meter + " Meter," + " neue Hoehe = " + pos.h);
        }

    }
    class Flugzeug : Luftfahrzeug
    {
        public Flugzeug(string kennung, Position pos) : base(kennung, pos)
        { }
    }
    class Starrflügelflugzeug : Luftfahrzeug
    {
        public Starrflügelflugzeug(string kennung, Position pos) : base(kennung, pos)
        { }
    }
    class Düsenflugzeug : Luftfahrzeug
    {
        public Düsenflugzeug(string kennung, Position pos) : base(kennung, pos)
        { }
    }

    class Go
    {
        public static void Main(string[] args)
        {
            


            Düsenflugzeug Stephan1 = new Düsenflugzeug("Stephan2020", new Position(15020, 30800, 110));
            Stephan1.typ = Airbus.A320;
            Console.WriteLine(Stephan1.typ);
            Console.WriteLine(Airbus.A320.GetType());
            Console.WriteLine(Airbus.A380);
            Console.WriteLine((int)Airbus.A320);
        }
    }
}




