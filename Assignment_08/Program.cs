namespace DesignPatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            TemplateMethodTester templateMethodTester = new TemplateMethodTester();
            templateMethodTester.test();

            MediatorTester mediatorTester = new MediatorTester();
            mediatorTester.test();

            ChainOfResponsibilityTester chain = new ChainOfResponsibilityTester();
            chain.test();

            CommandTester commandTester = new CommandTester();
            commandTester.test();

            ObserverTester observerTester = new ObserverTester();
            observerTester.test();

            IteratorTester iteratorTester = new IteratorTester();
            iteratorTester.test();

            StateTester stateTester = new StateTester();
            stateTester.test();

            VisitorTester visitorTester = new VisitorTester();
            visitorTester.test();

            StrategyTester strategyTester = new StrategyTester();
            strategyTester.test();

            InterpreterTester interpreterTester = new InterpreterTester();
            interpreterTester.test();

            MomentoTester momentoTester = new MomentoTester();
            momentoTester.test();
        }
    }
}