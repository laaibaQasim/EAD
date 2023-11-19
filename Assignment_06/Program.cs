using System;
namespace DesignPatterns
{
    class Program
    {
        static void Main(string[] args) 
        {
            SingletonTester singletonTester = new SingletonTester();
            singletonTester.test();

            FactoryTester factoryTester = new FactoryTester();
            factoryTester.test();

            AbstractFactoryTester abstractFactoryTester = new AbstractFactoryTester();
            abstractFactoryTester.test();

            BuilderTester buildTester = new BuilderTester();
            buildTester.test();

            PrototypeTester prototypeTester = new PrototypeTester();
            prototypeTester.test();
        }
    }
}