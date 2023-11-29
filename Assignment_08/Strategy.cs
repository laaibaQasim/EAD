namespace DesignPatterns
{
    //EXAMPLE 1
    // Strategy: ISortStrategy
    public interface ISortStrategy
    {
        void Sort(int[] array);
    }

    // ConcreteStrategy: BubbleSortStrategy
    public class BubbleSortStrategy : ISortStrategy
    {
        public void Sort(int[] array)
        {
            Console.WriteLine("Sorting using Bubble Sort");
        }
    }

    // ConcreteStrategy: QuickSortStrategy
    public class QuickSortStrategy : ISortStrategy
    {
        public void Sort(int[] array)
        {
            Console.WriteLine("Sorting using Quick Sort");
        }
    }

    // Context: SortContext
    public class SortContext
    {
        private ISortStrategy sortStrategy;

        public void SetSortStrategy(ISortStrategy strategy)
        {
            sortStrategy = strategy;
        }

        public void SortArray(int[] array)
        {
            sortStrategy.Sort(array);
        }
    }

    //EXAMPLE 2
    // Strategy: IPaymentStrategy
    public interface IPaymentStrategy
    {
        void ProcessPayment(double amount);
    }

    // ConcreteStrategy: CreditCardPaymentStrategy
    public class CreditCardPaymentStrategy : IPaymentStrategy
    {
        public void ProcessPayment(double amount)
        {
            Console.WriteLine($"Processing Credit Card Payment of ${amount}");
        }
    }

    // ConcreteStrategy: PayPalPaymentStrategy
    public class PayPalPaymentStrategy : IPaymentStrategy
    {
        public void ProcessPayment(double amount)
        {
            Console.WriteLine($"Processing PayPal Payment of ${amount}");
        }
    }

    // Context: PaymentContext
    public class PaymentContext
    {
        private IPaymentStrategy paymentStrategy;

        public void SetPaymentStrategy(IPaymentStrategy strategy)
        {
            paymentStrategy = strategy;
        }

        public void MakePayment(double amount)
        {
            paymentStrategy.ProcessPayment(amount);
        }
    }
}