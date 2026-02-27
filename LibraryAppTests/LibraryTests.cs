using LibraryApp;
using Xunit;
using System.Linq;

namespace LibraryAppTests
{
    public class LibraryTests
    {
        [Fact]
        public void AddBook_ShouldAddBookToLibrary()
        {
            var library = new Library();
            var book = new Book("Test", "Author", "123");

            library.AddBook(book);

            Assert.Contains(book, library.Books);
        }

        [Fact]
        public void GetAvailableBooks_ShouldOnlyReturnAvailableBooks()
        {
            var library = new Library();
            var book1 = new Book("Available", "Author", "111");
            var book2 = new Book("Borrowed", "Author", "222");

            library.AddBook(book1);
            library.AddBook(book2);

            book2.Borrow();

            var availableBooks = library.GetAvailableBooks();

            Assert.Single(availableBooks);
            Assert.Contains(book1, availableBooks);
        }

        [Fact]
        public void FindBookByISBN_ShouldReturnCorrectBook()
        {
            var library = new Library();
            var book = new Book("1984", "George Orwell", "999");

            library.AddBook(book);

            var foundBook = library.FindBookByISBN("999");

            Assert.Equal(book, foundBook);
        }
    }
}