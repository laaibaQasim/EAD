
namespace DesignPattern
{
    class AdapterTester
    {
        private void example1()
        {
            ForeignElectricalOutlet foreignOutlet = new ForeignElectricalOutlet();
            PowerAdapter powerAdapter = new PowerAdapter(foreignOutlet);

            // Using the adapter to supply power
            powerAdapter.SupplyPower();
        }
        private void example2()
        {
            OldLibrary oldLibrary = new OldLibrary();
            LibraryAdapter libraryAdapter = new LibraryAdapter(oldLibrary);

            // Using the adapter to perform the new operation
            libraryAdapter.PerformNewOperation();
        }
        public void test()
        {
            example1();
            example2();
        }
    }

    class BridgeTester
    {
        private void example1()
        {
            // Create shapes with different drawing APIs
            Shape circle1 = new Circle(1, 2, 3, new DrawingAPI1());
            Shape circle2 = new Circle(4, 5, 6, new DrawingAPI2());

            // Draw the shapes
            circle1.Draw();
            circle2.Draw();
        }
        private void example2()
        {
            // Create different coffee types with different brewing methods
            CoffeeBrewer espressoMachine = new EspressoMachine();
            CoffeeType espresso = new Espresso(espressoMachine);
            espresso.Brew();

            Console.WriteLine();

            CoffeeBrewer dripCoffeeBrewer = new DripCoffeeBrewer();
            CoffeeType latte = new Latte(dripCoffeeBrewer);
            latte.Brew();
        }
        public void test()
        {
            example1();
            example2();
        }
    }

    class CompositeTester
    {
        private void example1()
        {
            // Creating individual employees
            IEmployee employee1 = new IndividualEmployee("Alice");
            IEmployee employee2 = new IndividualEmployee("Bob");
            IEmployee employee3 = new IndividualEmployee("Charlie");

            // Creating departments and adding employees
            Department engineering = new Department("Engineering");
            engineering.AddEmployee(employee1);
            engineering.AddEmployee(employee2);

            Department marketing = new Department("Marketing");
            marketing.AddEmployee(employee3);

            // Creating a top-level department and adding sub-departments
            Department company = new Department("XYZ Company");
            company.AddEmployee(engineering);
            company.AddEmployee(marketing);

            // Displaying the entire organizational structure
            company.DisplayDetails();
        }
        private void example2()
        {
            // Creating individual files
            IFileSystemComponent file1 = new File("document.txt");
            IFileSystemComponent file2 = new File("image.jpg");

            // Creating directories and adding files
            Directory documents = new Directory("Documents");
            documents.AddComponent(file1);

            Directory pictures = new Directory("Pictures");
            pictures.AddComponent(file2);

            // Creating a top-level directory and adding sub-directories
            Directory root = new Directory("Root");
            root.AddComponent(documents);
            root.AddComponent(pictures);

            // Displaying the entire file system structure
            root.DisplayDetails();
        }
        public void test()
        {
            example1();
            example2();
        }
    }

    class DecoratorTester
    {
        private void example1()
        {
            // Create a simple coffee
            ICoffee coffee = new SimpleCoffee();
            Console.WriteLine($"Description: {coffee.GetDescription()}, Cost: ${coffee.GetCost()}");

            // Add milk to the coffee
            coffee = new MilkDecorator(coffee);
            Console.WriteLine($"Description: {coffee.GetDescription()}, Cost: ${coffee.GetCost()}");

            // Add sugar to the coffee
            coffee = new SugarDecorator(coffee);
            Console.WriteLine($"Description: {coffee.GetDescription()}, Cost: ${coffee.GetCost()}");
        }
        private void example2()
        {
            // Create plain text
            ITextComponent plainText = new PlainText("Hello, World!");

            // Decorate with bold formatting
            ITextComponent boldText = new BoldDecorator(plainText);

            // Decorate with italic formatting
            ITextComponent boldItalicText = new ItalicDecorator(boldText);

            // Display formatted text
            Console.WriteLine("Plain Text: " + plainText.GetText());
            Console.WriteLine("Bold Text: " + boldText.GetText());
            Console.WriteLine("Bold Italic Text: " + boldItalicText.GetText());
        }

        public void test()
        {
            example1();
            example2();
        }
    }

    class FacadeTester
    {
        private void example1()
        {
            // Using the MultimediaFacade to simplify the process
            MultimediaFacade multimediaFacade = new MultimediaFacade();
            multimediaFacade.StartMovie("BackgroundMusic.mp3", "Movie.mp4");

            // Client does not need to interact with individual subsystem components
            multimediaFacade.StopMovie();
        }
        private void example2()
        {

            // Using the ComputerFacade to simplify computer operations
            ComputerFacade computerFacade = new ComputerFacade();
            computerFacade.StartComputer();

            // Client does not need to interact with individual subsystem components
            computerFacade.ShutDownComputer();
        }
        public void test()
        {
            example1();
            example2();
        }
    }

    class FlyweightTester
    {
        private void example1()
        {
            CharacterFlyweightFactory flyweightFactory = new CharacterFlyweightFactory();

            // Display characters with different font sizes
            ICharacterFlyweight charA = flyweightFactory.GetCharacter('A');
            charA.Display(12);

            ICharacterFlyweight charB = flyweightFactory.GetCharacter('B');
            charB.Display(16);

            ICharacterFlyweight charC = flyweightFactory.GetCharacter('C');
            charC.Display(12);

            // Characters 'A' and 'C' share the same font size 12 flyweight
        }
        private void example2()
        {
            // Use the flyweight factory to get or create button flyweights
            ButtonFlyweightFactory flyweightFactory = new ButtonFlyweightFactory();

            // Display buttons with shared flyweights
            IButtonFlyweight blueButton = flyweightFactory.GetButtonFlyweight("Blue");
            blueButton.Display("OK", 10, 20);

            IButtonFlyweight redButton = flyweightFactory.GetButtonFlyweight("Red");
            redButton.Display("Cancel", 30, 40);

            // Buttons with the same appearance will share the same flyweight
            IButtonFlyweight anotherBlueButton = flyweightFactory.GetButtonFlyweight("Blue");
            anotherBlueButton.Display("Submit", 50, 60);
        }

        public void test()
        {
            example1();
            example2();
        }
    }

    class ProxyTester
    {
        private void example1()
        {
            // Using the proxy to load and display the image
            IImage image = new ProxyImage("largeImage.jpg");

            // Image is loaded only when needed
            image.Display();

            // Image is already loaded, so it displays quickly
            image.Display();
        }
        private void example2()
        {
            // Using the protection proxy to control file access
            IFile file = new ProtectionProxy("sensitiveFile.txt", "secret");

            // Access allowed with correct password
            file.Read();

            // Access denied with incorrect password
            file = new ProtectionProxy("sensitiveFile.txt", "wrongpassword");
            file.Read();
        }
        public void test()
        {
            example1();
            example2();
        }
    }
}
