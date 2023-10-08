using System;

namespace assignment_3
{
    internal class Book
    {
        string title;
        string author;
        public Book(string title, string author = "unknown") 
        {
            this.title = title;
            this.author = author;
        }
        public void Display()
        {
            Console.WriteLine($"Title: {title}, Author: {author}");
        }
    }
}
