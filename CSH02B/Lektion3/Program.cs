using System;

namespace Lektion3
{

    class Operatoren
    {
        public void UnaereOperatoren()
        {
            int var1 = 1234;
            int var2 = -1234;

            string Auswertung = var1 == var2 ? "gleich" : "ungleich";

            Console.WriteLine("{0} == {1} ? {2} ", var1, var2, Auswertung);


        }

        public void InkrementUndDekrement()
        {
            int var = 1;
            Console.WriteLine("var++ = {0}", var++);
            Console.WriteLine("var = {0}", var);
            Console.WriteLine("var-- = {0}", var--);
            Console.WriteLine("var = {0}", var);
            var = 1;
            Console.WriteLine("++var = {0}", ++var);
            Console.WriteLine("var = {0}", var);
            Console.WriteLine("--var = {0}", --var);
            Console.WriteLine("var = {0}", var);

        }

        public void TestMethode()
        {
            int intVar3 = 1234;
            int intVar4 = 13;

            Console.WriteLine("intVar3 % intVar4 = {0} ", intVar3 % intVar4);

            double doubleVar3 = 22.33;
            double doubleVar4 = 6.6;
            Console.WriteLine("doubleVar3 % doubleVar4 = {0} ", doubleVar3 % doubleVar4);
        }

        public void TestMethode1()
        {
            double x = 2.39;
            double y = 2.37;
            bool Ergebnis = x >= y;

            Console.WriteLine("double x >= double y = {0} ", x >= y, Ergebnis);
        }

        public void TestMethode2()
        {
            int var1 = -1234;
            int var2 = 1234;
            int var3 = 1234;

            Console.WriteLine("var1 < var2 == var3 >= var2: {0} ", var1 < var2 == var3 >= var2);
        }

        public void TestMethode3()
        {
            string a = "test";
            string b = a;

            Console.WriteLine("a == b : {0} ", a == b );
        }

        public void TestMethode4()
        {
            bool volljaehrig = true;
            bool buerge = true;
            int verdienst = 2000;
            bool kreditwuerdig = true;

            kreditwuerdig = volljaehrig & (verdienst > 2000 | buerge);

            Console.WriteLine("Kredigwuerdig: {0}", kreditwuerdig);

        }

        public void TestMethode5()
        {
            int a = 9;
            int b = a << 2;
            int c = a >> 2;

            Console.WriteLine(b);
            Console.WriteLine(c);

        }

        public void TestMethode6()
        {
            int intValue = 12345;
            Console.WriteLine(intValue <<= 3);

            int b = 2;

            Console.WriteLine(++b);
        }

        public void TestMethode7()
        {
            Console.WriteLine("12345 & 8 : {0} ", 12345 & 8);

            Console.WriteLine("12345 & 512 : {0} ", 12345 & 512);

            Console.WriteLine("12345 & 8192 : {0} ", 12345 & 8192);

        }

        public void Testentesten()
        {

            double Value = 1000000;
            Console.WriteLine(" value * value : {0} ", Value * Value);
        }
    }

    class Go
    {
        public static void Main(string[] args)
        {
            Operatoren test1 = new Operatoren();
            test1.Testentesten();
        }
    }
}
