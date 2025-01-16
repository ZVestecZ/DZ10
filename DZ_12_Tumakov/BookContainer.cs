using System;
using static DZ_12_Tumakov.Program;

namespace DZ_12_Tumakov
{
    internal class BookContainer
    {
        private Book[] book;

        public BookContainer(Book[] books)
        {
            book = books;
        }
        public void SortBooks(BookComparison comparison)
        {
            Array.Sort(book, (b1, b2) => comparison(b1, b2));
        }

        public Book[] GetBooks()
        {
            return book;
        }
    }
}
