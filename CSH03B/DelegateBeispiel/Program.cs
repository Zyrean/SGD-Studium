using System;

namespace DelegateBeispiel
{

    delegate void Nachricht(string sender);


    class program
    {
        public void GutenTag(string sender)
        {
            Console.WriteLine(sender + " sagt guten Tag.");
        }

        public void AufWiedersehen(string sender)
        {
            Console.WriteLine(sender + " sagt auf Wiedersehen. ");
        }

        public void DelegateAnwenden()
        {
            Nachricht info1 = new Nachricht(GutenTag);
            info1 += new Nachricht(AufWiedersehen);
            info1("Ihr Administrator");
            
        }

    }

    class MainClass
    {
        public static void Main(string[] args)
        {
            program test1 = new program();
            test1.DelegateAnwenden();
         
        }
    }
}
