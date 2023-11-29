namespace DesignPatterns
{
    public abstract class Tester
    {
        public abstract void example1();
        public abstract void example2();

        public void test()
        {
            Console.WriteLine("\nEXAMPLE 1");
            example1();
            Console.WriteLine("\nEXAMPLE 2");
            example2();
        }
    }
    class TemplateMethodTester: Tester
    {
        public override void example1()
        {
            Console.WriteLine("Building a Wooden House:");
            HouseTemplate woodenHouse = new WoodenHouse();
            woodenHouse.BuildHouse();

            Console.WriteLine();

            Console.WriteLine("Building a Concrete House:");
            HouseTemplate concreteHouse = new ConcreteHouse();
            concreteHouse.BuildHouse();
        }
        public override void example2()
        {
            Console.WriteLine("Building a Basic Website:");
            WebsiteTemplate basicWebsite = new BasicWebsiteTemplate();
            basicWebsite.BuildWebsite();

            Console.WriteLine();

            Console.WriteLine("Building a Fancy Website:");
            WebsiteTemplate fancyWebsite = new FancyWebsiteTemplate();
            fancyWebsite.BuildWebsite();
        }
    }
    class MediatorTester: Tester
    {
        public override void example1()
        {
            IATCMediator atcMediator = new ATCMediator();
            IFlight flight101 = new Flight("Flight 101", atcMediator);
            IFlight flight202 = new Flight("Flight 202", atcMediator);
            IFlight flight707 = new Flight("Flight 707", atcMediator);
            IFlight flight808 = new Flight("Flight 808", atcMediator);

            flight101.RequestLanding("Terminal A");
            flight202.RequestLanding("Terminal B");
            flight707.RequestLanding("Terminal A");
            flight808.RequestLanding("Terminal C");
        }
        public override void example2()
        {
            IChatMediator chatMediator = new ChatMediator();

            IUser user1 = new User("User1", chatMediator);
            IUser user2 = new User("User2", chatMediator);
            IUser user3 = new User("User3", chatMediator);

            user1.SendMessage("Hello, everyone!");

            Console.WriteLine();

            user2.SendMessage("Hi, User1!");
            user3.SendMessage("Hey, User2!");
        }
    }
    class ChainOfResponsibilityTester : Tester
    {
        public override void example1()
        {
            SupportTeam itSupportTeam = new ITSupportTeam();
            SupportTeam billingSupportTeam = new BillingSupportTeam();
            SupportTeam generalSupportTeam = new GeneralSupportTeam();

            itSupportTeam.SetSuccessor(billingSupportTeam);
            billingSupportTeam.SetSuccessor(generalSupportTeam);

            Ticket itTicket = new Ticket("IT issue", TicketType.IT);
            Ticket billingTicket = new Ticket("Billing issue", TicketType.BILLING);
            Ticket generalTicket = new Ticket("General issue", TicketType.GENERAL);

            itSupportTeam.HandleTicket(itTicket);
            itSupportTeam.HandleTicket(billingTicket);
            itSupportTeam.HandleTicket(generalTicket);
        }
        public override void example2()
        {
            CashDispenser twoThousandHandler = new TwoThousandHandler();
            CashDispenser fiveHundredHandler = new FiveHundredHandler();
            CashDispenser twoHundredHandler = new TwoHundredHandler();
            CashDispenser oneHundredHandler = new OneHundredHandler();

            twoThousandHandler.SetSuccessor(fiveHundredHandler);
            fiveHundredHandler.SetSuccessor(twoHundredHandler);
            twoHundredHandler.SetSuccessor(oneHundredHandler);

            Console.WriteLine("ATM Request: Withdraw 2700 rupees");
            twoThousandHandler.DispenseCash(2700);
        }
    }
    class CommandTester : Tester
    {
        public override void example1()
        {
            TextEditor textEditor = new TextEditor();
            ICommand addTextCommand = new AddTextCommand(textEditor, "Hello, ");
            ICommand addMoreTextCommand = new AddTextCommand(textEditor, "world!");

            UndoManager undoManager = new UndoManager();
            undoManager.SetCommand(addTextCommand);

            undoManager.ExecuteCommand(); // Adds "Hello, "
            undoManager.SetCommand(addMoreTextCommand);
            undoManager.ExecuteCommand(); // Adds "world!"

            undoManager.UndoCommand(); // Removes "world!"
        }
        public override void example2()
        {
            Cook chef = new Cook();
            Waiter waiter = new Waiter();

            OrderCommand order1 = new CookOrderCommand(chef, "Spaghetti Bolognese");
            OrderCommand order2 = new CookOrderCommand(chef, "Chicken Alfredo");
            OrderCommand order3 = new CookOrderCommand(chef, "Vegetarian Pizza");

            waiter.TakeOrder(order1);
            waiter.TakeOrder(order2);
            waiter.TakeOrder(order3);

            waiter.PlaceOrders();
        }
    }
    class ObserverTester : Tester
    {
        public override void example1()
        {
            BrandSaleSubject brandSaleSubject = new BrandSaleSubject("XYZ Brand");

            Customer customer1 = new Customer("Alice");
            Customer customer2 = new Customer("Bob");

            brandSaleSubject.Attach(customer1);
            brandSaleSubject.Attach(customer2);

            brandSaleSubject.SetSale("XYZ Brand", 20);
        }
        public override void example2()
        {
            JobPortalSubject jobPortal = new JobPortalSubject();

            JobSeeker seeker1 = new JobSeeker("John");
            JobSeeker seeker2 = new JobSeeker("Emily");

            jobPortal.Attach(seeker1);
            jobPortal.Attach(seeker2);

            jobPortal.AddJobPosting(new JobPosting("Software Engineer", "ABC Tech"));
            jobPortal.AddJobPosting(new JobPosting("Data Analyst", "XYZ Solutions"));

        }
    }
    class IteratorTester : Tester
    {
        public override void example1()
        {
            var myPlaylist = new Playlist();

            myPlaylist.AddSong(new Song("Title 1", "Artist 1"));
            myPlaylist.AddSong(new Song("Title 2", "Artist 2"));
            myPlaylist.AddSong(new Song("Title 3", "Artist 3"));

            IIterator<Song> iterator = myPlaylist.CreateIterator();
            while (iterator.HasNext())
            {
                Console.WriteLine(iterator.Next());
            }
        }

        public override void example2()
        {
            var shelf = new Bookshelf();
            shelf.Add(new Book("C#.NET", "Author 1"));
            shelf.Add(new Book("ASP.NET Core", "Author 2"));
            shelf.Add(new Book("Entity Framework", "Author 3"));

            var iterator = shelf.CreateIterator();
            while (iterator.HasNext())
            {
                var book = iterator.Next();
                Console.WriteLine($"Title: {book.Title}, Author: {book.Author}");
            }
        }
    }
    class StateTester : Tester
    {
        public override void example1()
        {
            ATMMachine atmMachine = new ATMMachine();

            atmMachine.InsertCard();
            atmMachine.EnterPIN();
            atmMachine.WithdrawCash();
            atmMachine.EjectCard();
        }
        public override void example2()
        {
            TrafficLight trafficLight = new TrafficLight();

            for (int i = 0; i < 3; i++)
            {
                trafficLight.ChangeState();
            }
        }
    }
    class VisitorTester : Tester
    {
        public override void example1()
        {
            List<IStudent> students = new List<IStudent>
        {
            new Kid("Alice"),
            new Kid("Bob"),
            new Kid("Jack"),
        };

            IHealthCheckupVisitor childSpecialistDoctor = new ChildSpecialistDoctor();

            foreach (var student in students)
            {
                student.Accept(childSpecialistDoctor);
            }
        }
        public override void example2()
        {
            IAnimal lion = new Lion();
            IAnimal dolphin = new Dolphin();

            IVisitor vet = new Veterinarian();
            IVisitor caretaker = new Caretaker();

            Console.WriteLine("Veterinarian visits:");
            lion.Accept(vet);
            dolphin.Accept(vet);

            Console.WriteLine("\nCaretaker visits:");
            lion.Accept(caretaker);
            dolphin.Accept(caretaker);
        }
    }
    class StrategyTester : Tester
    {
        public override void example1()
        {
            int[] arrayToSort = { 5, 2, 9, 1, 5, 6 };

            SortContext sortContext = new SortContext();

            sortContext.SetSortStrategy(new BubbleSortStrategy());
            sortContext.SortArray(arrayToSort);

            sortContext.SetSortStrategy(new QuickSortStrategy());
        }
        public override void example2()
        {
            PaymentContext paymentContext = new PaymentContext();

            // Use Credit Card Payment
            paymentContext.SetPaymentStrategy(new CreditCardPaymentStrategy());
            paymentContext.MakePayment(100.00);

            // Use PayPal Payment
            paymentContext.SetPaymentStrategy(new PayPalPaymentStrategy());
            paymentContext.MakePayment(50.00);
        }
    }
    class InterpreterTester : Tester
    {
        public override void example1()
        {
            // Represent the expression: 2 + 3 * 4
            IExpression expression = new AdditionExpression(
                new NumberExpression(2),
                new MultiplicationExpression(
                    new NumberExpression(3),
                    new NumberExpression(4)
                )
            );

            int result = expression.Interpret();
            Console.WriteLine($"Result: {result}"); 
        }

        public override void example2()
        {
            // Represent the query: SELECT name, age FROM users
            IQueryExpression query = new SelectQueryExpression(
                new List<IQueryExpression> { new TableExpression("name"), new TableExpression("age") },
                new TableExpression("users")
            );

            string sqlQuery = query.Interpret();
            Console.WriteLine($"SQL Query: {sqlQuery}");
        }
    }
    class MomentoTester : Tester
    {
        public override void example1()
        {
            Texteditor textEditor = new Texteditor("Initial Text");
            TextEditorHistory history = new TextEditorHistory();

            history.Push(textEditor.Save());

            textEditor.SetText("Modified Text");
            history.Push(textEditor.Save());

            textEditor.Restore(history.Pop());
            Console.WriteLine($"Text after undo: {textEditor.GetText()}");

            textEditor.Restore(history.Pop());
            Console.WriteLine($"Text after redo: {textEditor.GetText()}");
        }
        public override void example2()
        {
            Document document = new Document("Initial Content");
            DocumentHistory history = new DocumentHistory();

            history.Push(document.Save());

            document.Edit("Modified Content");
            history.Push(document.Save());

            document.Print();

            document.Restore(history.Pop());
            Console.WriteLine($"After undo: ");
            document.Print();
        }
    }
}
