using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesignPattensInCSharp.SingletonPatten;
using DesignPattensInCSharp.FactoryMethod;

namespace DesignPattensInCSharp.TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Application Starting ...");

            var inst1 = Singleton.Instance;
            var inst2 = Singleton.Instance;

            Console.WriteLine("(inst1 == inst2) = {0}", inst1 == inst2);

            var lazyInst1 = LazySingleton.Instance;
            var lazyInst2 = LazySingleton.Instance;

            Console.WriteLine("(lazyInst1 == lazyInst2) = {0}", lazyInst1 == lazyInst2);

            var dog = CreateAnimal(AnimalType.Dog);
            dog.Move();

            var bird = CreateAnimal(AnimalType.Bird);
            bird.Move();

            Console.ReadLine();
        }

        static IAnimal CreateAnimal(AnimalType type)
        {
            Creator creator;
            switch (type)
            {
                case AnimalType.Bird:
                    creator = new BirdCreator();
                    break;
                case AnimalType.Dog:
                    creator = new DogCreator();
                    break;
                default:
                    creator = new DogCreator();
                    break;
            }

            return creator.CreatAnimal();
        }
    }

}
