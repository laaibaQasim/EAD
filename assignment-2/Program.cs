using System;
using System.Reflection;

namespace assignment_2
{
    class Program
    {
        static void StringConcatenation()
        {
            Console.WriteLine("Enter First Name");
            string fname = Console.ReadLine();
            
            Console.WriteLine("Enter Last Name");
            string lname = Console.ReadLine();

            string fullName = String.Concat(fname," ",lname);
            Console.Write("Full Name: ");
            Console.WriteLine(fullName);
        }
        static void SubstringFetching(string sentence)
        {
            if (sentence.Length >= 5)
            {
                 Console.WriteLine(sentence.Substring(sentence.Length - 5));
            }
            else
            {
                Console.WriteLine(sentence);
            }
        }
        static void StringInterpolation()
        {
            Console.WriteLine("Enter Current Temperature");
            double temperature = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Enter Name Of City");
            string city = Console.ReadLine();

            Console.WriteLine($"The temperature in {city} is {temperature} degrees Celsius.");
        }
        static void ArrayDeclaration()
        {
            int[] numbers = { 1, 2, 3, 4, 5 };
            foreach (var i in numbers)
            {
                Console.Write(i);
            }
            Console.WriteLine();
        }
        static void ArrayIteration_a<T>(T[] fruits)
        {
            for(int i = 0; i< fruits.Length; i++) 
            {
                Console.WriteLine(fruits[i]);
            }
        }
        static void ArrayIteration_b<T>(T[] colors)
        {
            foreach (var color in colors) 
            {
                Console.Write($"{color}, "); 
            }
            Console.WriteLine();
        }
        static void DisplaySum(int[] scores)
        {
            int index = 0;
            int sum = 0;
            do
            {
                sum += scores[index];
                index++;
            }
            while (index < scores.Length);
            Console.WriteLine($"sum: {sum}");
        }
        static void DisplayMax(int[] values) 
        {
            int index = 1;
            int max = values[0];
            while(index < values.Length)
            {
                if (values[index] > max)
                {
                    max = values[index];
                }
                index++;
            }
            Console.WriteLine($"maximum: {max}");
        }
        static void ReverseArray(int[] array)
        {
            int index = 0;
            foreach (int number in array)
            {
                if (index >= array.Length / 2)
                {
                    break;
                }
                int last_index = (array.Length - 1) - index;
                array[index] = array[last_index];
                array[last_index] = number;
                index++;
            }
            Console.Write("Reversed Array: ");
            ArrayIteration_b(array);
        }
        static void BoxingInt()
        {
            int x = 42;
            object obj = x;
            int y = (int)obj;
            Console.WriteLine($"y: {y}");
        }
        static void BoxingDouble()
        {
            double doubleValue = 3.14159;
            object obj = doubleValue;
            double unboxedValue = (double)obj;
            Console.WriteLine($"unboxedValue: {unboxedValue}");
        }
        static void Unboxing(int[] numbers)
        {
            foreach (int num in numbers)
            {
                object boxedValue = num;
                int unboxedValue = (int)boxedValue;
                int square = unboxedValue * unboxedValue;
                Console.WriteLine($"unboxed value: {unboxedValue} , boxed value: {square}");
            }
        }
        static void UnboxingList()
        {
            List<object> mixedList = new List<object>();
            mixedList.Add(13);        
            mixedList.Add("abc");      
            mixedList.Add(2.3); 

            int intValue = (int)mixedList[0];        
            double doubleValue = (double)mixedList[2]; 
            string stringValue = (string)mixedList[1];

            foreach (var item in mixedList)
            {
                Console.WriteLine($"value: {item}, type: {item.GetType().Name}");
            }
        }
        static void DynamicVariable_a()
        {
            dynamic myVariable;
            myVariable = 42;
            Console.WriteLine(myVariable);
            myVariable = "hello, dynamic!";
            Console.WriteLine(myVariable);
        }
        static void DynamicVariable_b()
        {
            dynamic myVariable2;
            myVariable2 = 42;
            Console.WriteLine(myVariable2.GetType());

            myVariable2 = 2.2;
            Console.WriteLine(myVariable2.GetType());

            myVariable2 = DateTime.Now;
            Console.WriteLine(myVariable2.GetType());

            myVariable2 = "hello, dynamic!";
            Console.WriteLine(myVariable2.GetType());
        }

        public static void Main(string[] args)
        {
            StringConcatenation();
            SubstringFetching("hy i am laiba qasim");
            StringInterpolation();
            ArrayDeclaration();

            string[] fruits = { "apple", "mango", "banana", "melon" };
            ArrayIteration_a(fruits);

            string[] colors = { "orange", "black", "brown", "red" };
            ArrayIteration_b(colors);

            int[] scores = { 10, 2, 66, 34, 8, 2, 6, 7, 98 };
            DisplaySum(scores);
            DisplayMax(scores);
            ReverseArray(scores);

            BoxingInt();
            BoxingDouble();

            int[] numbers = { 1, 2, 3, 4, 5 };
            Unboxing(numbers);
            UnboxingList();
            DynamicVariable_b();
        }

    }

}
