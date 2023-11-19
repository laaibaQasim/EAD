using System;

namespace DesignPatterns
{
    //Example 1
    public interface IAnimal
    {
        void makeSound();
    }
    public interface IAnimalFactory
    {
        IAnimal createAnimal();
    }
    public class Dog: IAnimal
    {
        public void makeSound()
        {
            Console.WriteLine("Dog is making sound Woof! Woof!");
        }
    }
    public class Cat : IAnimal
    {
        public void makeSound()
        {
            Console.WriteLine("Cat is making sound Meow! Meow!");
        }
    }
    public class OddEvenFactory:IAnimalFactory
    {
        private static int count = 0;
        public IAnimal createAnimal()
        {
            count++;
            if (count%2 == 0)
            {
                return new Dog();
            }
            else
            {
                return new Cat();
            }
        }
    }
    
    //Example 2
    public interface IShape
    {
        void draw();
    }
    public interface IShapeFactory
    {
        IShape CreateShape();
    }
    public class RandomizedFactory: IShapeFactory
    {
        public IShape CreateShape()
        {
            Random random = new Random();
            // Generate a random number between 1 and 10 (inclusive)
            int randomNumber = random.Next(1, 11);
            if (randomNumber <5)
            {
                return new Circle();
            }
            else
            {
                return new Square();
            }
        }
    }
    public class Circle : IShape
    {
        public void draw()
        {
            Console.WriteLine("Drawing shape: Circle");
        }
    }
    public class Square : IShape
    {
        public void draw()
        {
            Console.WriteLine("Drawing shape: Square");
        }
    }

}
