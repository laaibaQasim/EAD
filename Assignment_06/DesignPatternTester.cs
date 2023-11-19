

namespace DesignPatterns
{
    class SingletonTester
    {
        
        private void example1()
        {
            Console.WriteLine("\nExample1: Singleton Pattern");
            // Test the Logger class

            // Get an instance of the Logger
            Logger logger = Logger.Instance;

            // Log some messages
            Console.WriteLine("logging: This is a log message.");
            logger.LogMessage("This is a log message.");


            // Create another instance to demonstrate that it still refers to the same logger
            Logger anotherLogger = Logger.Instance;
            Console.WriteLine("logging: Message from another logger instance.");
            anotherLogger.LogMessage("Message from another logger instance.");

            // Check if the two instances are the same
            Console.WriteLine($"Is logger and anotherLogger the same instance? {ReferenceEquals(logger, anotherLogger)}");
        }
        private void example2()
        {
            Console.WriteLine("\nExample2: Singleton Pattern");
            // Test the studentManager class

            // Get an instance of the studentManager
            StudentManager studentManager = StudentManager.Instance;

            // Set and retrieve students info
            studentManager.SetStudent("1", "Laiba");
            studentManager.SetStudent("2", "Ayesha");

            string? firstStudent = studentManager.GetStudent("1");
            string? secondStudent = studentManager.GetStudent("2");

            Console.WriteLine($"firstStudent: {firstStudent}");
            Console.WriteLine($"secondStudent: {secondStudent}");

            // Create another instance to demonstrate that it still refers to the same student manager
            StudentManager anotherStudentManager = StudentManager.Instance;
            anotherStudentManager.SetStudent("3", "Fatima");

            // Check if the two instances are the same
            Console.WriteLine($"Is studentManager and anotherStudentManager the same instance? {ReferenceEquals(studentManager, anotherStudentManager)}");
        }
        public void test()
        {
            example1();
            example2();
        }
    }

    class FactoryTester
    {
        private void example1()
        {
            Console.WriteLine("\nExample1: Factory Pattern");
            IAnimalFactory animalFactory = new OddEvenFactory();
            IAnimal animal1 = animalFactory.createAnimal();
            animal1.makeSound();

            IAnimal animal2 = animalFactory.createAnimal();
            animal2.makeSound();
        }
        private void example2()
        {
            Console.WriteLine("\nExample2: Factory Pattern");
            IShapeFactory shapeFactory = new RandomizedFactory();
            IShape shape1 = shapeFactory.CreateShape();
            shape1.draw();

            IShape shape2 = shapeFactory.CreateShape();
            shape2.draw();
        }
        public void test()
        {
            example1();
            example2();
        }
    }

    class AbstractFactoryTester
    {
        private void example1()
        {
            Console.WriteLine("\nExample1: Abstract Factory Pattern");
            // Create a Windows GUI
            GUIFactory windowsFactory = new WindowsFactory();
            Button windowsButton = windowsFactory.CreateButton();
            Form windowsForm = windowsFactory.CreateForm();

            // Render and display Windows UI components
            windowsButton.Render();
            windowsForm.Display();

            Console.WriteLine();

            // Create a Linux GUI
            GUIFactory linuxFactory = new LinuxFactory();
            Button linuxButton = linuxFactory.CreateButton();
            Form linuxForm = linuxFactory.CreateForm();

            // Render and display Linux UI components
            linuxButton.Render();
            linuxForm.Display();
        }
        private void exampel2()
        {
            Console.WriteLine("\nExample2: Abstract Factory Pattern");
            // Create Apple devices
            ElectronicDeviceFactory appleFactory = new AppleFactory();
            Laptop appleLaptop = appleFactory.CreateLaptop();
            Smartphone iPhone = appleFactory.CreateSmartphone();

            // Display information about Apple devices
            appleLaptop.Display();
            iPhone.DisplayInfo();

            Console.WriteLine();

            // Create Samsung devices
            ElectronicDeviceFactory samsungFactory = new SamsungFactory();
            Laptop samsungLaptop = samsungFactory.CreateLaptop();
            Smartphone samsungPhone = samsungFactory.CreateSmartphone();

            // Display information about Samsung devices
            samsungLaptop.Display();
            samsungPhone.DisplayInfo();
        }
        public void test()
        {
            example1();
            exampel2();
        }
    }

    class BuilderTester
    {
        private void example1()
        {
            Console.WriteLine("\nExample1: Builder Pattern");
            // Create a Gaming Computer
            IComputerBuilder gamingBuilder = new GamingComputerBuilder();
            ComputerDirector gamingDirector = new ComputerDirector(gamingBuilder);

            Computer gamingComputer = gamingBuilder.GetComputer();
            gamingComputer.DisplayInfo();

            // Create an Office Computer
            IComputerBuilder officeBuilder = new OfficeComputerBuilder();
            ComputerDirector officeDirector = new ComputerDirector(officeBuilder);

            Computer officeComputer = officeBuilder.GetComputer();
            officeComputer.DisplayInfo();
        }
        private void example2()
        {
            Console.WriteLine("\nExample2: Builder Pattern");
            // Build a Single-Story House
            IHouseBuilder singleStoryBuilder = new SingleStoryHouseBuilder();
            HouseDirector singleStoryDirector = new HouseDirector(singleStoryBuilder);

            House singleStoryHouse = singleStoryBuilder.GetHouse();
            singleStoryHouse.DisplayInfo();

            // Build a Multi-Story House
            IHouseBuilder multiStoryBuilder = new MultiStoryHouseBuilder();
            HouseDirector multiStoryDirector = new HouseDirector(multiStoryBuilder);

            House multiStoryHouse = multiStoryBuilder.GetHouse();
            multiStoryHouse.DisplayInfo();
        }
        public void test()
        {
            example1();
            example2();
        }
    }

    class PrototypeTester
    {
        private void example1()
        {
            Console.WriteLine("\nExample1: Prototype Pattern");
            pdfDocument copy1 = new pdfDocument { content = "pdf1 Content" };

            // Create new documents by cloning the prototype
            pdfDocument copy2 = (pdfDocument)copy1.Clone();

            // Modify the content of the copies without affecting the prototype
            copy2.content = "pdf2 copied from pdf1";

            Console.WriteLine("Copy 1 Content: " + copy1.content);
            Console.WriteLine("Copy 2 Content: " + copy2.content);
        }
        private void example2()
        {
            Console.WriteLine("\nExample2: Prototype Pattern");
            Red copy1 = new Red { colorCode = 1 };

            // Create new documents by cloning the prototype
            Red copy2 = (Red)copy1.Clone();

            // Modify the content of the copies without affecting the prototype
            copy2.colorCode = 2;

            Console.WriteLine("Copy 1 Color: " + copy1.colorCode);
            Console.WriteLine("Copy 2 Color: " + copy2.colorCode);
        }
        public void test()
        {
            example1();
            example2();
        }
    }
}
