
namespace assignment_3
{
    class Program
    {
        // task 1-a
        static void Greet(string greeting = "Hello", string name="world")
        {
            Console.WriteLine($"{greeting}, {name}!");
        }
        // task 1-b
        static double CalculateArea(double length = 1.0, double width = 1.0)
        {
            return length * width;
        }
        // task 1-c
        static int AddNumbers(int a, int b)
        {
            return a + b;
        }
        static int AddNumbers(int a, int b, int c = 0)
        {
            return a + b + c;
        }
        // task 2-b
        static void Swap<T>(ref T a, ref T b)
        {
            (a, b) = (b, a);
        }
        // task 2-c
        static T ArraySum<T>(T[] array) where T: struct, IComparable<T>, IConvertible
        {
            dynamic sum = 0;
            foreach(T element in array)
            {
                sum += element;
            }
            return sum;
        }
        // task 2-d
        static void StudentDriver()
        {
            StudentDb database = new StudentDb();

            //Adding students record
            database.AddStudent(101, "Alice");
            database.AddStudent(102, "Bob");
            database.AddStudent(103, "Charlie");
            database.AddStudent(104, "David");

            Console.WriteLine("Student Database Menu:");
            while (true)
            {
                Console.WriteLine("\n1. View the student database");
                Console.WriteLine("2. Search for a student by ID");
                Console.WriteLine("3. Update a student's name");
                Console.WriteLine("4. Exit the program");
                Console.Write("Enter your choice (1-4): ");
                int choice;
                try
                {
                    choice = Convert.ToInt32(Console.ReadLine());
                }
                catch(Exception e)
                {
                    Console.Write("Wrong Input.");
                    continue;
                }
                Console.WriteLine();
                if (choice == 1) 
                {
                    database.DisplayDb();
                }
                else if (choice == 2) 
                {
                    Console.Write("Enter Id: ");
                    int id = Convert.ToInt32(Console.ReadLine());
                    database.DisplayStudent(id);
                }
                else if (choice == 3) 
                {
                    Console.Write("Enter Id: ");
                    int id = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Enter Name: ");
                    string name = Console.ReadLine();
                    database.UpdateStudent(id,name);
                }
                else if (choice == 4) 
                {
                    break;
                }
            }

        }
       
        static void Main(string[] args)
        {
            // task 1-a
            Greet();
            Greet("Hy");
            Greet(name:"laiba");
            Console.WriteLine();

            // task 1-b
            int l = 2, w = 3;
            Console.WriteLine($"length: {l}, width: {w}, area: {CalculateArea(2, 3)}");
            Console.WriteLine();

            // task 1-c
            int n1 = 2, n2 = 3, n3 = 5;
            Console.WriteLine($"n1: {n1}, n2: {n2}, sum: {AddNumbers(2, 3)}");
            Console.WriteLine($"n1: {n1}, n2: {n2}, n3: {n3}, sum: {AddNumbers(2, 3, 5)}");
            Console.WriteLine();

            // task 1-d
            Book book1 = new Book("The Kite Runner");
            book1.Display();

            Book book2 = new Book("The Kite Runner", "Khaled Hosseini");
            book2.Display();
            Console.WriteLine();

            //task 2-a
            MyList<int> list = new MyList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            
            list.Remove(2);
            Console.WriteLine("list");
            list.display();
            Console.WriteLine();

            // task 2-b
            int a = 1, b=2;
            Console.WriteLine($"Before swapping: a={a}, b={b}");
            Swap(ref a, ref b);
            Console.WriteLine($"After swapping: a={a}, b={b}");

            String s1 = "string1", s2 = "string2";
            Console.WriteLine($"Before swapping: s1={s1}, s2={s2}");
            Swap(ref s1,ref s2);
            Console.WriteLine($"After swapping: s1={s1}, s2={s2}");
            Console.WriteLine();

            // task 2-c
            int[] array = { 1, 2, 3, 4 };
            string[] str_array = { "1", "f", "f" };
            Console.WriteLine($"array sum: {ArraySum(array)}");

            //It will give error due to generic constraint
            //Console.WriteLine($"array sum: {ArraySum(str_array)}");
            Console.WriteLine();

            // task 2-d
            StudentDriver();

        }
    }
}