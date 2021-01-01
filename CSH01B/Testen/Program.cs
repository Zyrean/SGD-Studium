using System;

namespace Testen
{

    class Go
    {
        public static void Main(string[] args)
        {
            B bObjekt = new B();
            bObjekt.TuWas();
            bObjekt.TuNochWas();
        }
    }

    interface Interface
    {

    }

    abstract class A
    {
        public abstract void TuWas();
        
    }

    class B : A, Interface
    {
        public override void TuWas()
        {
            Console.WriteLine("Ich tu was");
        }

        public void TuNochWas()
        {
            Console.WriteLine("Ich tu noch was");
        }
    }
}
