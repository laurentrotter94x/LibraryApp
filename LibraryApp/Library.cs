using System.Collections.Generic;
using System.Linq;

namespace LibraryApp
{
    public class Library
    {
        public List<Book> Books { get; private set; }
        public List<Member> Members { get; private set; }

        public Library()
        {
            Books = new List<Book>();
            Members = new List<Member>();
        }

        public void AddBook (Book book)
        {
            Books.Add(book);
        }

        public void AddMember(Member member)
        {
            Members.Add(member);
        }

        public List<Book> GetAvailableBooks()
        {
            return Books.Where(b => !b.IsBorrowed).ToList();
        }

        public Book? FindBookByISBN(string isbn)
        {
            return Books.FirstOrDefault(b => b.ISBN == isbn);
        }
    }
}