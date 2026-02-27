using System.Collections.Generic;

namespace LibraryApp
{
    public class Member
    {
        public string Name { get; set; }
        public string MemberId { get; set; }

        public List<Book> BorrowedBooks { get; private set; }

        public Member(string name, string memberId)
        {
            Name = name;
            MemberId = memberId;
            BorrowedBooks = new List<Book>();
        }

        public void BorrowBook(Book book)
        {
            if (!book.IsBorrowed)
            {
                book.Borrow();
                BorrowedBooks.Add(book);
            }
        }

        public void ReturnBook(Book book)
        {
            if (BorrowedBooks.Contains(book))
            {
                book.Return();
                BorrowedBooks.Remove(book);
            }
        }

    }
}