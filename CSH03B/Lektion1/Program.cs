using System;
using System.Threading;


namespace Lektion1
{
    delegate void TransponderDel(string kennung, Position pos);

    delegate void FliegerRegisterDel();

    interface ITransponder { }

    enum Düsenflugzeugtyp { A300 = 280, A310 = 240, A318 = 260, A319 = 250, A320 = 290, A321 = 320, A330 = 350, A340 = 310, A350 = 253, A380 = 550, Boeing_717, Boeing_737, Boeing_747, Boeing_767, Boeing_777, Boeing_BBJ }

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
        protected Position startPos;
        protected Düsenflugzeugtyp typ;
        protected Position zielPos, pos;
        protected int streckeProTrakt;
        protected int flughöhe;
        protected int steighöheProTakt;
        protected int sinkhöheProTakt;
        protected bool steigt = false;
        protected bool sinkt = false;


        public Luftfahrzeug() : base()
        { }

        public Luftfahrzeug(string kennung, Position startPos)
        {
            this.kennung = kennung;
            this.startPos = startPos;
        }

        public string Kennung
        {
            set { kennung = value; }
            get { return kennung; }
        }

        public void Start(Position zielPos, int streckeProTrakt, int flughöhe, int steighöheProTakt, int sinkhöheProTakt)
        {
            this.zielPos = zielPos;
            this.streckeProTrakt = streckeProTrakt;
            this.flughöhe = flughöhe;
            this.steighöheProTakt = steighöheProTakt;
            this.sinkhöheProTakt = sinkhöheProTakt;
            this.steigt = true;
        }

        public abstract void Steigen(int meter);

        public abstract void Sinken(int meter);

    }

    class Flugzeug : Luftfahrzeug
    {
        public Flugzeug(string kennung, Position startPos) : base(kennung, startPos)
        { }

        public override void Steigen(int meter)
        {
            startPos.PositionÄndern(0, 0, meter);
            Console.WriteLine(kennung + " steigt " + meter + " Meter, neue Hoehe " + startPos.h);
        }

        public override void Sinken(int meter)
        {
            startPos.PositionÄndern(0, 0, -meter);
            Console.WriteLine(kennung + " steigt " + meter + " Meter, neue Hoehe " + startPos.h);

        }
    }

    class Starrflügelflugzeug : Flugzeug, ITransponder
    {
        double a, b, alpha, a1, b1;
        bool gelandet = false;

        public Starrflügelflugzeug(string kennung, Position startPos) : base(kennung, startPos)
        {
            Go.transponder += new TransponderDel(Transpond);
            Go.fliegerRegister += new FliegerRegisterDel(Steuern);
        }

        public void Steuern()
        {
            if (steigt)
            {
                if (this.SinkenEinleiten())
                {
                    steigt = false;
                    sinkt = true;
                }
                else if (pos.h > flughöhe)
                {
                    steigt = false;
                }
            }
            else if (sinkt)
            {
                if (pos.h <= zielPos.h + sinkhöheProTakt)
                    gelandet = true;
            }
            else
            {
                if (this.SinkenEinleiten())
                {
                    sinkt = true;
                }
            }

            if (!gelandet)
            {
                Go.transponder(kennung, startPos);
                a = zielPos.x - startPos.x;
                b = zielPos.y - startPos.y;
                alpha = Math.Atan2(b, a);
                a1 = Math.Cos(alpha) * streckeProTrakt;
                b1 = Math.Sin(alpha) * streckeProTrakt;
                startPos.PositionÄndern((int)a1, (int)b1, 0);

                if (steigt)
                {
                    double strecke = Math.Sqrt(Math.Pow(streckeProTrakt, 2) - Math.Pow(steighöheProTakt, 2));
                    this.PositionBerechnen(strecke, steighöheProTakt);
                }
                else if (sinkt)
                {
                    double strecke = Math.Sqrt(Math.Pow(streckeProTrakt, 2) - Math.Pow(sinkhöheProTakt, 2));
                    this.PositionBerechnen(strecke, -sinkhöheProTakt);
                }
                else 
                {
                    this.PositionBerechnen(steighöheProTakt, 0);
                }
            

            else
            {
                Go.fliegerRegister -= this.Steuern;
                Go.transponder -= this.Transpond;
                Console.WriteLine("\n{0} gelandet (Zieldistanz = {1}, Höhendistanz = {2}", kennung, Zieldistanz(), pos.h - zielPos.h);
            }

             /*   if (Math.Sqrt(Math.Pow(a, 2) + Math.Pow(b, 2)) < streckeProTrakt)
                {
                    gelandet = true;
                    Console.WriteLine("\n{0} an Position " + " x= {1}, y= {2}, geladent", kennung, pos.x, pos.y);
                    Go.fliegerRegister -= this.Steuern;
                }
          */}
        }

        private bool SinkenEinleiten()
        {
            double strecke = Math.Sqrt(Math.Pow(streckeProTrakt, 2) - Math.Pow(sinkhöheProTakt, 2));
            int sinkstrecke = (int)(strecke * (pos.h - zielPos.h) / sinkhöheProTakt);
            int zieldistanz = Zieldistanz();

            if (sinkstrecke >= zieldistanz)
            {
                Console.WriteLine("{0} Sinkstrecke {1} >= Zieldistanz {2}", kennung, sinkstrecke, zieldistanz);
                return true;
            }
            else
                return false;
        }

        private int Zieldistanz()
        {
            return (int)Math.Sqrt(Math.Pow(zielPos.x - pos.x, 2) + Math.Pow(zielPos.y - pos.y, 2));
        }

        private void PositionBerechnen(double strecke, int steighöheProTakt)
        {
            a = zielPos.x - startPos.x;
            b = zielPos.y - startPos.y;
            alpha = Math.Atan2(b, a);
            a1 = Math.Cos(alpha) * streckeProTrakt;
            b1 = Math.Sin(alpha) * streckeProTrakt;
            startPos.PositionÄndern((int)a1, (int)b1, steighöheProTakt);
        }

        public void Transpond(string kennung, Position pos)
        {
            if (kennung.Equals(this.kennung))
            {
                this.pos = pos;
                Console.WriteLine("{0} an Position x= {1}, y= {2}", kennung, pos.x, pos.y);
                Math.Pow(zielPos.x - pos.x, 2);
            }
        }
    }


    class Düsenflugzeug : Starrflügelflugzeug
    {
        private int sitzplätze;
        private int fluggäste;
        private int Fluggäste;

        public Düsenflugzeug(string kennung, Position startPos, Düsenflugzeugtyp typ) : base(kennung, startPos)
        {
            this.typ = typ;
            sitzplätze = (int)typ;
            Console.WriteLine("Der Flieger vom Typ {0} hat {1} Plätze", this.typ, sitzplätze);
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
            flieger1.Start(new Position(1000, 500, 200), 200, 300, 20, 10);
            Starrflügelflugzeug flieger2 = new Starrflügelflugzeug("LH 1106", new Position(11000, 6600, 550));
            flieger2.Start(new Position(1000, 500, 200), 260, 350, 25, 15);

            while (fliegerRegister != null)
            {

                fliegerRegister();
                Console.WriteLine();
                Thread.Sleep(1000);
            }

        }


        public void Kennung()
        {
            Flugzeug flieger = new Flugzeug("LH 500 ", new Position(500, 300, 20));
            Console.WriteLine("Kennung = {0}", flieger.Kennung);
            flieger.Kennung = "LH 333";
            Console.WriteLine("Kennung = {0}", flieger.Kennung);
        }

        
        public void testen()
        {
            Console.WriteLine(Math.Sqrt(9));
        }

        public static void Main(string[] args)
        {
            Go test1 = new Go();
            test1.ProgrammTakten();
        }
    }
}
