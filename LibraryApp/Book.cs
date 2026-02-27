using System;

namespace LibraryApp
{
    public class Book
    {
        //properties
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public bool IsBorrowed { get; private set; }

        //constructor
        public Book(string title, string author, string isbn)
        {
            Title = title;
            Author = author;
            ISBN = isbn;
            IsBorrowed = false;
        }

        //methods
        public void Borrow()
        {
            if (IsBorrowed)
            {
                Console.WriteLine($"{Title} is already borrowed.");     
            }
            else
            {
                IsBorrowed = true;
                Console.WriteLine($"{Title} has been borrowed.");
            }
        }

        public void Return()
        {
            if (!IsBorrowed)
            {
                Console.WriteLine($"{Title} is not currently borrowed.");
            }
            else
            {
                IsBorrowed = false;
                Console.WriteLine($"{Title} has been returned.");
            }
        }
    }
}