using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment_3
{
    internal class MyList<T>
    {
        public List<T> List { get; set; }
        public MyList()
        {
            List = new List<T>();
        }
        public void Add(T element)
        {
            List.Add(element);
        }
        public void Remove(T element)
        {
            if(!List.Remove(element))
            {
                Console.WriteLine("element not found!");
            }
        }
        public void display()
        {
            foreach (var item in List) 
            {
                Console.WriteLine(item);
            }
        }
    }
}
