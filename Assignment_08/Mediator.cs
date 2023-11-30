namespace DesignPatterns
{
    //EXAMPLE 1
    // Mediator: IATCMediator
    public interface IATCMediator
    {
        void RegisterFlight(IFlight flight);
        void RequestLanding(IFlight flight, string terminal);
    }

    // Colleague: IFlight
    public interface IFlight
    {
        string FlightNumber { get; }
        string CurrentTerminal { get; set; }
        void RequestLanding(string terminal);
        void ReceiveLandingPermission(string terminal);
        void ReceiveLandingDenied(string terminal);
    }

    // Concrete Mediator: ATCMediator
    public class ATCMediator : IATCMediator
    {
        private List<IFlight> flights = new List<IFlight>();

        public void RegisterFlight(IFlight flight)
        {
            flights.Add(flight);
        }

        public void RequestLanding(IFlight requestingFlight, string terminal)
        {
            Console.WriteLine($"{requestingFlight.FlightNumber} requests landing at Terminal {terminal}");

            foreach (var flight in flights)
            {
                if (flight != requestingFlight && flight.CurrentTerminal == terminal)
                {
                    // Notify other flights not to land at the requested terminal
                    flight.ReceiveLandingDenied(terminal);
                }
            }

            // Notify the requesting flight whether it can land at the requested terminal
            if (!flights.Exists(flight => flight != requestingFlight && flight.CurrentTerminal == terminal))
            {
                requestingFlight.ReceiveLandingPermission(terminal);
            }
        }
    }

    // Concrete Colleague: Flight
    public class Flight : IFlight
    {
        public string FlightNumber { get; }
        public string CurrentTerminal { get; set; }

        private IATCMediator mediator;

        public Flight(string flightNumber, IATCMediator mediator)
        {
            FlightNumber = flightNumber;
            this.mediator = mediator;
            mediator.RegisterFlight(this);
        }

        public void RequestLanding(string terminal)
        {
            mediator.RequestLanding(this, terminal);
        }

        public void ReceiveLandingPermission(string terminal)
        {
            CurrentTerminal = terminal;
            Console.WriteLine($"{FlightNumber} receives landing permission at Terminal {terminal}. Landing...");
        }

        public void ReceiveLandingDenied(string terminal)
        {
            Console.WriteLine($"{FlightNumber} receives landing denial at Terminal {terminal}. Searching for an alternative terminal.");
        }
    }

    //EXAMPLE 2

    // Mediator: ChatMediator
    public interface IChatMediator
    {
        public void AddUser(IUser user);
        void SendMessage(string message, IUser sender);
    }

    // Colleague: IUser
    public interface IUser
    {
        string Name { get; }
        void SendMessage(string message);
        void ReceiveMessage(string message);
    }

    // Concrete Mediator: ChatRoom
    public class ChatMediator : IChatMediator
    {
        private List<IUser> users = new List<IUser>();

        public void AddUser(IUser user)
        {
            users.Add(user);
        }

        public void SendMessage(string message, IUser sender)
        {
            foreach (var user in users)
            {
                if (user != sender)
                {
                    user.ReceiveMessage($"{sender.Name}: {message}");
                }
            }
        }
    }

    // Concrete Colleague: User
    public class User : IUser
    {
        private IChatMediator mediator;

        public string Name { get; }

        public User(string name, IChatMediator mediator)
        {
            Name = name;
            this.mediator = mediator;
            mediator.AddUser(this);
        }

        public void SendMessage(string message)
        {
            Console.WriteLine($"{Name} sends message: {message}");
            mediator.SendMessage(message, this);
        }

        public void ReceiveMessage(string message)
        {
            Console.WriteLine($"{Name} receives message: {message}");
        }
    }
}