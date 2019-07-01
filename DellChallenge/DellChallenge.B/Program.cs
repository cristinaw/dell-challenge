using System;
using System.Collections.Generic;

namespace DellChallenge.B
{
    class Program
    {
        static void Main(string[] args)
        {
            // Given the classes and interface below, please constructor the proper hierarchy.
            // Feel free to refactor and restructure the classes/interface below.
            // (Hint: Not all species and Fly and/or Swim)

            IList<ISpecies> species = new List<ISpecies>();
            species.Add(new Human());
            species.Add(new Bird());
            species.Add(new Fish());

            foreach (ISpecies s in species)
            {
                s.GetSpecies();
                s.Drink();
                s.Eat();
                s.Fly();
                s.Swim();

                Console.WriteLine();
            }
        }
    }

    public interface ISpecies
    {
        void Eat();
        void Drink();
        void Fly();
        void Swim();
        void GetSpecies();
    }

    public abstract class Species: ISpecies
    {
        public virtual void GetSpecies()
        {
            Console.WriteLine($"Echo who am I?");
        }

        public void Drink()
        {
            Console.WriteLine($"I drink.");
        }

        public void Eat()
        {
            Console.WriteLine($"I eat.");
        }

        public abstract void Fly();

        public abstract void Swim();
    }

    public class Human : Species
    {
        public override void GetSpecies()
        {
            Console.WriteLine($"I am Human.");
        }

        public override void Fly()
        {
            Console.WriteLine($"Humans don't fly by themselves, they use flying means.");
        }

        public override void Swim()
        {
            Console.WriteLine($"Human can swim.");
        }
    }

    public class Bird: Species
    {
        public override void GetSpecies()
        {
            Console.WriteLine($"I am a Bird");
        }

        public override void Fly()
        {
            Console.WriteLine($"Bird is flying");
        }

        public override void Swim()
        {
            Console.WriteLine($"Some birds can swim (swan, goose).");
        }
    }

    public class Fish:Species
    {
        public override void GetSpecies()
        {
            Console.WriteLine($"I am a Fish.");
        }

        public override void Fly()
        {
            Console.WriteLine($"Fish is not flying.");
        }

        public override void Swim()
        {
            Console.WriteLine($"Fish is swiming.");
        }
    }
}

