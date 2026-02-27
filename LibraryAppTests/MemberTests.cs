using LibraryApp;
using Xunit;

namespace LibraryAppTests
{
    public class MemberTests
    {
        [Fact]
        public void BorrowBook_ShouldAddBookToBorrowedBooks()
        {
            var member = new Member("Lauren", "M001");
            var book = new Book("Test", "Author", "123");

            member.BorrowBook(book);

            Assert.Contains(book, member.BorrowedBooks);
        }

        [Fact]
        public void BorrowBook_ShouldMarkBookAsBorrowed()
        {
            var member = new Member("Lauren", "M001");
            var book = new Book("Test", "Author", "123");

            member.BorrowBook(book);

            Assert.True(book.IsBorrowed);
        }

        [Fact]
        public void ReturnBook_ShouldRemoveBookFromBorrowedBooks()
        {
            var member = new Member("Lauren", "M001");
            var book = new Book("Test", "Author", "123");

            member.BorrowBook(book);
            member.ReturnBook(book);

            Assert.DoesNotContain(book, member.BorrowedBooks);
        }
    }
}