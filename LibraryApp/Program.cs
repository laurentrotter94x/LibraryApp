using System;
using System.Linq;

namespace LibraryApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Create library and sample books
            var library = new Library();
            var book1 = new Book("1984", "George Orwell", "ISBN001");
            var book2 = new Book("Papillon", "Henri Charrière", "ISBN002");
            var book3 = new Book("Pride and Prejudice", "Jane Austen", "ISBN003");
            var book4 = new Book("Angels & Demons", "Dan Brown", "ISBN004");
            var book5 = new Book("The Hobbit", "J.R.R. Tolkien", "ISBN005");

            library.AddBook(book1);
            library.AddBook(book2);
            library.AddBook(book3);
            library.AddBook(book4);
            library.AddBook(book5);

            // Create multiple members
            var member1 = new Member("Lauren", "M001");
            var member2 = new Member("Molly", "M002");
            var member3 = new Member("Lilly", "M003");

            library.AddMember(member1);
            library.AddMember(member2);
            library.AddMember(member3);

            // Select active member
            Console.WriteLine("Select a member by entering their number:");
            for (int i = 0; i < library.Members.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {library.Members[i].Name}");
            }

            Member? activeMember = null;
            while (activeMember == null)
            {
                Console.Write("Enter number: ");
                string? input = Console.ReadLine();
                if (int.TryParse(input, out int num) && num >= 1 && num <= library.Members.Count)
                {
                    activeMember = library.Members[num - 1];
                }
                else
                {
                    Console.WriteLine("Invalid selection. Try again.");
                }
            }

            Console.WriteLine($"\nWelcome, {activeMember.Name}!\n");

            // Main interaction loop
            bool running = true;
            while (running)
            {
                Console.WriteLine("\n--- Library Menu ---");
                Console.WriteLine("1. View available books");
                Console.WriteLine("2. Borrow a book");
                Console.WriteLine("3. Return a book");
                Console.WriteLine("4. View my borrowed books");
                Console.WriteLine("5. Exit");
                Console.Write("Select an option (1-5): ");
                string? choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        var available = library.GetAvailableBooks();
                        if (!available.Any())
                        {
                            Console.WriteLine("No books are currently available.");
                        }
                        else
                        {
                            Console.WriteLine("Available books:");
                            foreach (var b in available)
                                Console.WriteLine($"{b.Title} by {b.Author}");
                        }
                        break;

                    case "2":
                        Console.Write("Enter the title of the book to borrow: ");
                        string? borrowTitle = Console.ReadLine();
                        var bookToBorrow = library.Books.FirstOrDefault(b => b.Title.Equals(borrowTitle, StringComparison.OrdinalIgnoreCase));
                        if (bookToBorrow != null)
                        {
                            activeMember.BorrowBook(bookToBorrow);
                        }
                        else
                        {
                            Console.WriteLine("Book not found.");
                        }
                        break;

                    case "3":
                        Console.Write("Enter the title of the book to return: ");
                        string? returnTitle = Console.ReadLine();
                        var bookToReturn = activeMember.BorrowedBooks.FirstOrDefault(b => b.Title.Equals(returnTitle, StringComparison.OrdinalIgnoreCase));
                        if (bookToReturn != null)
                        {
                            activeMember.ReturnBook(bookToReturn);
                        }
                        else
                        {
                            Console.WriteLine("You haven't borrowed this book.");
                        }
                        break;

                    case "4":
                        if (!activeMember.BorrowedBooks.Any())
                        {
                            Console.WriteLine("You have no borrowed books.");
                        }
                        else
                        {
                            Console.WriteLine("Your borrowed books:");
                            foreach (var b in activeMember.BorrowedBooks)
                                Console.WriteLine($"{b.Title} by {b.Author}");
                        }
                        break;

                    case "5":
                        running = false;
                        Console.WriteLine("Goodbye!");
                        break;

                    default:
                        Console.WriteLine("Invalid choice, try again.");
                        break;
                }
            }
        }
    }
}