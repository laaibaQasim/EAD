namespace DesignPatterns
{
    //EXAMPLE 1
    // Element: IStudent
    public interface IStudent
    {
        void Accept(IHealthCheckupVisitor visitor);
    }

    // ConcreteElement: Kid
    public class Kid : IStudent
    {
        public string Name { get; }
        public bool IsHealthy { get; set; }

        public Kid(string name)
        {
            Name = name;
            IsHealthy = true; // Assume all kids are initially healthy
        }

        public void Accept(IHealthCheckupVisitor visitor)
        {
            visitor.VisitKid(this);
        }
    }

    // Visitor: IHealthCheckupVisitor
    public interface IHealthCheckupVisitor
    {
        void VisitKid(Kid kid);
    }

    // ConcreteVisitor: ChildSpecialistDoctor
    public class ChildSpecialistDoctor : IHealthCheckupVisitor
    {
        public void VisitKid(Kid kid)
        {
            Console.WriteLine($"Child Specialist Doctor checking the health of {kid.Name}.");

            // Health checkup logic
            Random random = new Random();
            kid.IsHealthy = random.Next(0, 2) == 0; // 50% chance of being healthy

            Console.WriteLine($"{kid.Name}'s health status: {(kid.IsHealthy ? "Healthy" : "Not Healthy")}");
            Console.WriteLine();
        }
    }

    //EXAMPLE 2
    // Element Interface
    interface IAnimal
    {
        void Accept(IVisitor visitor);
    }

    // Concrete Elements
    class Lion : IAnimal
    {
        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    class Dolphin : IAnimal
    {
        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    // Visitor Interface
    interface IVisitor
    {
        void Visit(Lion lion);
        void Visit(Dolphin dolphin);
    }

    // Concrete Visitors
    class Veterinarian : IVisitor
    {
        public void Visit(Lion lion)
        {
            Console.WriteLine("Examines the lion's health.");
        }

        public void Visit(Dolphin dolphin)
        {
            Console.WriteLine("Checks the dolphin's breathing.");
        }
    }

    class Caretaker : IVisitor
    {
        public void Visit(Lion lion)
        {
            Console.WriteLine("Feeds the lion some meat.");
        }

        public void Visit(Dolphin dolphin)
        {
            Console.WriteLine("Feeds the dolphin some fish.");
        }
    }
}