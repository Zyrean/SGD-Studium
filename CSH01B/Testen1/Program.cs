using System;

namespace Testen1
{
    class Go
    {
        public static void Main(string[] args)
        {
            Rechteck Rechteck = new Rechteck(10, 50);
            Rechteck.Umfang();
            Rechteck.Flaeche();
            Quadrat Quadrat = new Quadrat(10, 50);
            Quadrat.Umfang();
            Quadrat.Flaeche();

        }
    }

    abstract class Figur
    {
        public int breite, hoehe;

        public Figur() : base() { }

        public Figur (int breite, int hoehe)
        {
            this.breite = breite;
            this.hoehe = hoehe;
        }

        public abstract void Umfang();

        public abstract void Flaeche();
    }

    class Rechteck : Figur
    {
        public Rechteck(int breite, int hoehe) : base(breite, hoehe)
        { }

        public override void Umfang()
        {
            int RechteckUmfang = 2 * (breite + hoehe);
            Console.WriteLine("Umfang des Rechtecks: " + RechteckUmfang);
        }

        public override void Flaeche()
        {
            int RechteckFlaeche = breite * hoehe;
            Console.WriteLine("Flaeche des Rechtecks: " + (breite * hoehe));
        }
    }

    class Quadrat : Figur
    {
        public Quadrat(int breite, int hoehe) : base(breite, hoehe)
        { }

        public override void Umfang()
        {
            int QuadratUmfang = 4 * breite;
            Console.WriteLine("Umfang des Quadrat " + QuadratUmfang);
        }

        public override void Flaeche()
        {
            int QuadratFlaeche = breite * breite;
            Console.WriteLine("Flaeche des Quadrat: " + QuadratFlaeche);
        }
    }
}
