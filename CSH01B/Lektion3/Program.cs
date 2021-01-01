using System;

namespace Lektion3
{
    interface ITransponder { }
    
    enum Düsenflugzeugtyp { A300, A310, A318, A319, A320, A321, A330, A340, A350, A380, Boeing_717, Boeing_737, Boeing_747, Boeing_767, Boeing_777, Boeing_BBJ }

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

    abstract class Luftfahrzeug
    {
        protected string kennung;
        protected Position pos;
        protected Düsenflugzeugtyp typ;

        public Luftfahrzeug() : base()
        { }

        public Luftfahrzeug(string kennung, Position pos)
        {
            this.kennung = kennung;
            this.pos = pos;
        }

        public abstract void Steigen(int meter);

        public abstract void Sinken(int meter);

    }

    class Flugzeug : Luftfahrzeug
    {
        public Flugzeug(string kennung, Position pos) : base(kennung, pos)
        { }

        public override void Steigen(int meter)
        {
            pos.PositionÄndern(0, 0, meter);
            Console.WriteLine(kennung + " steigt " + meter + " Meter, neue Hoehe " + pos.h);
        }

        public override void Sinken(int meter)
        {
            pos.PositionÄndern(0, 0, -meter);
            Console.WriteLine(kennung + " steigt " + meter + " Meter, neue Hoehe " + pos.h);

        }
    }

    class Starrflügelflugzeug : Luftfahrzeug, ITransponder
    {
        public Starrflügelflugzeug(string kennung, Position pos) : base(kennung, pos)
        {
            this.Transpond(kennung, pos);
        }

        public override void Steigen(int meter)
        {
            pos.PositionÄndern(0, 0, meter);
            Console.WriteLine(kennung + " steigt " + meter + " Meter, neue Hoehe " + pos.h);
        }

        public override void Sinken(int meter)
        {
            pos.PositionÄndern(0, 0, -meter);
            Console.WriteLine(kennung + " steigt " + meter + " Meter, neue Hoehe " + pos.h);
        }

        public void Transpond(string kennung, Position pos)
        {
            Console.WriteLine("Flieger funkt Kennung '" + kennung + " ' " + " und Position " + pos.x + " , " + pos.y + " , " + pos.h + " , ");
        }

    }

    class Düsenflugzeug : Luftfahrzeug
    {
        public Düsenflugzeug(string kennung, Position pos) : base(kennung, pos)
        { }

        public override void Steigen(int meter)
        {
            pos.PositionÄndern(0, 0, meter);
            Console.WriteLine(kennung + " steigt " + meter + " Meter, neue Hoehe " + pos.h);
        }

        public override void Sinken(int meter)
        {
            pos.PositionÄndern(0, 0, -meter);
            Console.WriteLine(kennung + " steigt " + meter + " Meter, neue Hoehe " + pos.h);
        }
    }

    class Go
    {
        public static void Main(string[] args)
        {
            Starrflügelflugzeug Stephan1 = new Starrflügelflugzeug("LH 3000", new Position(100, 500, 20));
            Stephan1.Steigen(500);
            Stephan1.Sinken(100);
           

        }
    }
}
