namespace DesignPattern
{
    //EXAMPLE-1
    // Component interface: Employee
    public interface IEmployee
    {
        void DisplayDetails();
    }

    // Leaf: IndividualEmployee
    public class IndividualEmployee : IEmployee
    {
        private string name;

        public IndividualEmployee(string name)
        {
            this.name = name;
        }

        public void DisplayDetails()
        {
            Console.WriteLine($"Individual Employee: {name}");
        }
    }

    // Composite: Department
    public class Department : IEmployee
    {
        private string name;
        private List<IEmployee> employees = new List<IEmployee>();

        public Department(string name)
        {
            this.name = name;
        }

        public void AddEmployee(IEmployee employee)
        {
            employees.Add(employee);
        }

        public void DisplayDetails()
        {
            Console.WriteLine($"Department: {name}");

            foreach (var employee in employees)
            {
                employee.DisplayDetails();
            }
        }
    }


    //EXAMPLE-2

    // Component interface: FileSystemComponent
    public interface IFileSystemComponent
    {
        void DisplayDetails();
    }

    // Leaf: File
    public class File : IFileSystemComponent
    {
        private string name;

        public File(string name)
        {
            this.name = name;
        }

        public void DisplayDetails()
        {
            Console.WriteLine($"File: {name}");
        }
    }

    // Composite: Directory
    public class Directory : IFileSystemComponent
    {
        private string name;
        private List<IFileSystemComponent> components = new List<IFileSystemComponent>();

        public Directory(string name)
        {
            this.name = name;
        }

        public void AddComponent(IFileSystemComponent component)
        {
            components.Add(component);
        }

        public void DisplayDetails()
        {
            Console.WriteLine($"Directory: {name}");

            foreach (var component in components)
            {
                component.DisplayDetails();
            }
        }
    }

}
