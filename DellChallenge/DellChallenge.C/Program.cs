using System;

namespace DellChallenge.C
{
    class Program
    {
        static void Main(string[] args)
        {
            // Please refactor the code below whilst taking into consideration the following aspects:
            //      1. clean coding
            //      2. naming standards
            //      3. code reusability, hence maintainability
            StartHere();
            Console.ReadKey();
        }

        private static void StartHere()
        {
            MyObject _myNewObject = new MyObject();
            int num1 = _myNewObject.Do(1, 3);
            int num2 = _myNewObject.DoExtended(1, 3, 5);
            Console.WriteLine(num1);
            Console.WriteLine(num2);
        }
    }

   class MyObject
    {
        public int Do(int a, int b)
        {
            return a + b;
        }

        public int DoExtended(int a, int b, int c)
        {
            return Do(a, b) + c;
        }
    }
}
