namespace DesignPatterns
{
    //EXAMPLE 1
    // Subject: BrandSaleSubject
    public class BrandSaleSubject
    {
        private readonly List<IObserver> observers = new List<IObserver>();
        private string brandName;
        private decimal discountPercentage;

        public BrandSaleSubject(string brandName)
        {
            this.brandName = brandName;
        }

        public void Attach(IObserver observer)
        {
            observers.Add(observer);
        }

        public void Detach(IObserver observer)
        {
            observers.Remove(observer);
        }

        public void Notify()
        {
            foreach (var observer in observers)
            {
                observer.Update(brandName, discountPercentage);
            }
        }

        public void SetSale(string brandName, decimal discountPercentage)
        {
            this.brandName = brandName;
            this.discountPercentage = discountPercentage;
            Notify();
        }
    }

    // Observer: IObserver
    public interface IObserver
    {
        void Update(string brandName, decimal discountPercentage);
    }

    // ConcreteObserver: Customer
    public class Customer : IObserver
    {
        private string name;

        public Customer(string name)
        {
            this.name = name;
        }

        public void Update(string brandName, decimal discountPercentage)
        {
            Console.WriteLine($"{name}: Sale Alert! {brandName} products on sale with {discountPercentage}% discount.");
        }
    }

    //EXAMPLE 2
    // Subject: JobPortalSubject
    public class JobPortalSubject
    {
        private readonly List<Iobserver> observers = new List<Iobserver>();
        private List<JobPosting> jobPostings = new List<JobPosting>();

        public void Attach(Iobserver observer)
        {
            observers.Add(observer);
        }

        public void Detach(Iobserver observer)
        {
            observers.Remove(observer);
        }

        public void Notify()
        {
            foreach (var observer in observers)
            {
                observer.Update(jobPostings);
            }
        }

        public void AddJobPosting(JobPosting jobPosting)
        {
            jobPostings.Add(jobPosting);
            Notify();
        }
    }

    // Observer: IObserver
    public interface Iobserver
    {
        void Update(List<JobPosting> jobPostings);
    }

    // ConcreteObserver: JobSeeker
    public class JobSeeker : Iobserver
    {
        private string name;

        public JobSeeker(string name)
        {
            this.name = name;
        }

        public void Update(List<JobPosting> jobPostings)
        {
            Console.WriteLine($"{name}: New job postings available:");
            foreach (var jobPosting in jobPostings)
            {
                Console.WriteLine($"- {jobPosting.Title} at {jobPosting.Company}");
            }
        }
    }

    // Product: JobPosting
    public class JobPosting
    {
        public string Title { get; }
        public string Company { get; }

        public JobPosting(string title, string company)
        {
            Title = title;
            Company = company;
        }
    }
}