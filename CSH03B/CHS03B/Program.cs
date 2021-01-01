using System;
using System.Threading;

namespace CHS03B

{
    delegate void TransponderDel(string kennung, Position pos);

    delegate void FliegerRegisterDel();

    interface ITransponder { }

    enum Düsenflugzeugtyp { A300=280, A310=240, A318=260, A319=250, A320=290, A321=320, A330=350, A340=310, A350=253, A380=550, Boeing_717, Boeing_737, Boeing_747, Boeing_767, Boeing_777, Boeing_BBJ }

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

        public string Kennung
        {
            set { kennung = value; }
            get { return kennung; }
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

    class Starrflügelflugzeug : Flugzeug, ITransponder
    {
        public Starrflügelflugzeug(string kennung, Position pos) : base(kennung, pos)
        {
            Go.transponder += new TransponderDel(Transpond);
            Go.fliegerRegister += new FliegerRegisterDel(Steuern);
        }

        public void Steuern()
        {
            Go.transponder(kennung, pos);
        }

        public void Transpond(string kennung, Position pos)
        {
            if (kennung.Equals(this.kennung))
            {
                Console.WriteLine(this.kennung + " erkennt Eingang eigenes Signal");
            }
            else
            {
                Console.WriteLine("{0} empfaengt Position von {1}: x= {2}, y= {3}, h= {4} ", this.kennung, kennung, pos.x, pos.y, pos.h);
            }   
        }
    }

    class Düsenflugzeug : Starrflügelflugzeug
    {
        private int sitzplätze;
        private int fluggäste;
        private int Fluggäste;
       
        public Düsenflugzeug(string kennung, Position pos, Düsenflugzeugtyp typ) : base(kennung, pos)
        {
            this.typ = typ;
            sitzplätze = (int)typ;
            Console.WriteLine("Der Flieger vom Typ {0} hat {1} Plätze" , this.typ, sitzplätze);
        }

        public int FLuggäste
        {
            set
            {
                if (sitzplätze < (fluggäste + value))
                    Console.WriteLine("Keine Buching: Die " + " Fluggastzahl würde mit der Zubuchung " + " von {0} Plätzen die verfügbaren Plätze " + " von {1} um {2} übersteigen!", value, sitzplätze, value + fluggäste - sitzplätze);
                else
                    fluggäste += value;
            }
            get { return fluggäste; }
        }

        public void Buchen(int plätze)
        {
            Fluggäste = plätze;
        }
    }

    
    class Go
    {
        public static TransponderDel transponder;
        public static FliegerRegisterDel fliegerRegister;


        public void ProgrammTakten()
        {
            Starrflügelflugzeug flieger1 = new Starrflügelflugzeug("LH 2810", new Position(5000, 3000, 200));
            Starrflügelflugzeug flieger2 = new Starrflügelflugzeug("LH 1106", new Position(11000, 6600, 550));

            while (true)
            {

                fliegerRegister();
                Console.WriteLine();
                Thread.Sleep(1000);
            }

        }

        public void TransponderTest()
        {
            Starrflügelflugzeug flieger1 = new Starrflügelflugzeug("LH 3000", new Position(3000, 2000, 100));
            flieger1.Steuern();
            Console.WriteLine();
            Starrflügelflugzeug flieger2 = new Starrflügelflugzeug("LH 500", new Position(3500, 1500, 180));
            flieger1.Steuern();
            flieger2.Steuern();
            Console.WriteLine();
            Starrflügelflugzeug flieger3 = new Starrflügelflugzeug("LH 444", new Position(17300, 23400, 780));
            flieger1.Steuern();
            flieger2.Steuern();
            flieger3.Steuern();
            Console.WriteLine();
            transponder -= flieger2.Transpond;
            flieger1.Steuern();
            flieger3.Steuern();
        }

        public void Kennung()
        {
            Flugzeug flieger = new Flugzeug("LH 500 ", new Position(500, 300, 20));
            Console.WriteLine("Kennung = {0}", flieger.Kennung);
            flieger.Kennung = "LH 333";
            Console.WriteLine("Kennung = {0}", flieger.Kennung);
        }

        public static void Main(string[] args)
        {
            //Sonstige test = new Sonstige();
            //test.Kennung();
            //Düsenflugzeug Dü1 = new Düsenflugzeug("LH 5000", new Position(500, 500, 500), Düsenflugzeugtyp.Boeing_717);
            //Console.WriteLine(Dü1.Kennung);
            Go test1 = new Go();
            test1.ProgrammTakten();

        }
    }
}
