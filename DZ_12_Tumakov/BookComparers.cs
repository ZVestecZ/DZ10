using System;

namespace DZ_12_Tumakov
{
    internal class BookComparers
    {
        public static int CompareByTitle(Book book1, Book book2)
    {
        return string.Compare(book1.Title, book2.Title, StringComparison.OrdinalIgnoreCase);
    }
    public static int CompareByAuthor(Book book1, Book book2)
    {
        return string.Compare(book1.Author, book2.Author, StringComparison.OrdinalIgnoreCase);
    }
    public static int CompareByPublisher(Book book1, Book book2)
    {
        return string.Compare(book1.Publisher, book2.Publisher, StringComparison.OrdinalIgnoreCase);
    }
    }
}
