using System;

namespace DesignPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            AdapterTester adapterTester = new AdapterTester();
            adapterTester.test();

            BridgeTester bridgeTester = new BridgeTester();
            bridgeTester.test();

            CompositeTester compositeTester = new CompositeTester();
            compositeTester.test();

            DecoratorTester decoratorTester = new DecoratorTester();
            decoratorTester.test();

            FacadeTester facadeTester = new FacadeTester();
            facadeTester.test();

            FlyweightTester flyweightTester = new FlyweightTester();
            flyweightTester.test();

            ProxyTester proxyTester = new ProxyTester();
            proxyTester.test();
        }
    }
}