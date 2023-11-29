namespace DesignPatterns
{
    // EXAMPLE 1
    // Handler: SupportTeam
    public abstract class SupportTeam
    {
        protected SupportTeam successor;

        public void SetSuccessor(SupportTeam successor)
        {
            this.successor = successor;
        }

        public abstract void HandleTicket(Ticket ticket);
    }

    // ConcreteHandler: ITSupportTeam
    public class ITSupportTeam : SupportTeam
    {
        public override void HandleTicket(Ticket ticket)
        {
            if (ticket.Type == TicketType.IT)
            {
                Console.WriteLine($"IT Support Team handles ticket: {ticket.Description}");
            }
            else if (successor != null)
            {
                successor.HandleTicket(ticket);
            }
        }
    }

    // ConcreteHandler: BillingSupportTeam
    public class BillingSupportTeam : SupportTeam
    {
        public override void HandleTicket(Ticket ticket)
        {
            if (ticket.Type == TicketType.BILLING)
            {
                Console.WriteLine($"Billing Support Team handles ticket: {ticket.Description}");
            }
            else if (successor != null)
            {
                successor.HandleTicket(ticket);
            }
        }
    }

    // ConcreteHandler: GeneralSupportTeam
    public class GeneralSupportTeam : SupportTeam
    {
        public override void HandleTicket(Ticket ticket)
        {
            Console.WriteLine($"General Support Team handles ticket: {ticket.Description}");
        }
    }

    // Ticket: Request class
    public class Ticket
    {
        public string Description { get; }
        public TicketType Type { get; }

        public Ticket(string description, TicketType type)
        {
            Description = description;
            Type = type;
        }
    }

    // TicketType: Enumeration
    public enum TicketType
    {
        IT,
        BILLING,
        GENERAL
    }


    //EXAMPLE 2
    // Handler: CashDispenser
    public abstract class CashDispenser
    {
        protected CashDispenser successor;

        public void SetSuccessor(CashDispenser successor)
        {
            this.successor = successor;
        }

        public abstract void DispenseCash(int amount);
    }

    // ConcreteHandler: TwoThousandHandler
    public class TwoThousandHandler : CashDispenser
    {
        public override void DispenseCash(int amount)
        {
            if (amount >= 2000)
            {
                int numNotes = amount / 2000;
                Console.WriteLine($"Dispensing {numNotes} notes of 2000 rupees");
                int remainingAmount = amount % 2000;

                if (remainingAmount > 0 && successor != null)
                {
                    successor.DispenseCash(remainingAmount);
                }
            }
            else if (successor != null)
            {
                successor.DispenseCash(amount);
            }
        }
    }

    // ConcreteHandler: FiveHundredHandler
    public class FiveHundredHandler : CashDispenser
    {
        public override void DispenseCash(int amount)
        {
            if (amount >= 500)
            {
                int numNotes = amount / 500;
                Console.WriteLine($"Dispensing {numNotes} notes of 500 rupees");
                int remainingAmount = amount % 500;

                if (remainingAmount > 0 && successor != null)
                {
                    successor.DispenseCash(remainingAmount);
                }
            }
            else if (successor != null)
            {
                successor.DispenseCash(amount);
            }
        }
    }

    // ConcreteHandler: TwoHundredHandler
    public class TwoHundredHandler : CashDispenser
    {
        public override void DispenseCash(int amount)
        {
            if (amount >= 200)
            {
                int numNotes = amount / 200;
                Console.WriteLine($"Dispensing {numNotes} notes of 200 rupees");
                int remainingAmount = amount % 200;

                if (remainingAmount > 0 && successor != null)
                {
                    successor.DispenseCash(remainingAmount);
                }
            }
            else if (successor != null)
            {
                successor.DispenseCash(amount);
            }
        }
    }

    // ConcreteHandler: OneHundredHandler
    public class OneHundredHandler : CashDispenser
    {
        public override void DispenseCash(int amount)
        {
            if (amount >= 100)
            {
                int numNotes = amount / 100;
                Console.WriteLine($"Dispensing {numNotes} notes of 100 rupees");
                int remainingAmount = amount % 100;

                if (remainingAmount > 0 && successor != null)
                {
                    successor.DispenseCash(remainingAmount);
                }
            }
            else if (successor != null)
            {
                successor.DispenseCash(amount);
            }
        }
    }
}