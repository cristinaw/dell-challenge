using System;

namespace DellChallenge.A
{
    class Program
    {
        static void Main(string[] args)
        {
            // State and explain console output order.
            /*
             The output order is:
             A.A()
             B.B()
             A.Age

            Explaination:
             A.A() // base constructor of derived class
             B.B() // constructor of derived class
             A.Age // setter property of Age

            The instantiation of B is done using default constructor of B. 
            B is derived from A. Default constructor of a base class is called automatically when an instance of derived class
            is created (new B()), thus A.A() is written, then Console.WriteLine from B's constructor displays B.B().
            and then because of set Age = 0 in B's constructor Console.WriteLine("A.Age"); from Age setter will output A.Age.
             */
            new B();
            Console.ReadKey();
        }
    }

    class A
    {
        private int _age;
        public int Age
        {
            get { return _age; }
            set
            {
                _age = value;
                Console.WriteLine("A.Age");
            }
        }


        public A()
        {
            Console.WriteLine("A.A()");
        }
    }

    class B : A
    {
        public B()
        {
            Console.WriteLine("B.B()");
            Age = 0;
        }
    }
}
