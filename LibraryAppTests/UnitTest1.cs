using LibraryApp;
using Xunit;

namespace LibraryAppTests
{
    public class BookTests
    {
        [Fact]
        public void NewBook_ShouldNotBeBorrowed()
        {
            var book = new Book("Test", "Author", "123");

            Assert.False(book.IsBorrowed);
        }

        [Fact]
        public void Borrow_ShouldSetIsBorrowedToTrue()
        {
            var book = new Book("Test", "Author", "123");

            book.Borrow();

            Assert.True(book.IsBorrowed);
        }

        [Fact]
        public void Return_ShouldSetIsBorrowedToFalse()
        {
            var book = new Book("Test", "Author", "123");

            book.Borrow();
            book.Return();

            Assert.False(book.IsBorrowed);
        }
    }
}