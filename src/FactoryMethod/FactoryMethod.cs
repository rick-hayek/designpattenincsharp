using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattensInCSharp.FactoryMethod
{
    /// <summary>
    /// Define an interface for creating an object, but let subclasses decide which class to instantiate. 
    /// Factory Method lets a class defer instantiation to subclasses.
    /// Product
    ///    This defines the interface of objects the factory method creates
    /// ConcreteProduct
    ///    This is a class which implements the Product interface.
    /// Creator
    ///    This is an abstract class and declares the factory method, which returns an object of type Product.
    ///    This may also define a default implementation of the factory method that returns a default ConcreteProduct object.
    ///    This may call the factory method to create a Product object.
    /// ConcreteCreator
    ///    This is a class which implements the Creator class and overrides the factory method to return an instance of a ConcreteProduct.
    /// </summary>
    public interface IAnimal
    {
        void Move();
    }

    public class Bird : IAnimal
    {
        public void Move()
        {
            Fly();
        }

        protected void Fly()
        {
            Console.WriteLine("Bird is flying");
        }
    }

    public class Dog : IAnimal
    {
        public void Move()
        {
            Run();
        }

        protected void Run()
        {
            Console.WriteLine("Dog is running");
        }
    }

    public abstract class Creator
    {
        public Creator()
        {
            CreatAnimal();
        }

        public abstract IAnimal CreatAnimal();
    }

    public class BirdCreator : Creator
    {
        public override IAnimal CreatAnimal()
        {
            return new Bird();
        }
    }

    public class DogCreator : Creator
    {
        public override IAnimal CreatAnimal()
        {
            return new Dog();
        }
    }

    public enum AnimalType
    {
        Dog,
        Bird,
        Fish
    }
}
