using System;

namespace DZ_12_Tumakov
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Задание 1");
            TestRationalNumber();
            Console.WriteLine();
            Console.ReadKey();
            Console.WriteLine("Задание 2");
            TestComplexNumber();
            Console.WriteLine();
            Console.ReadKey();
            Console.WriteLine("Задание 3");
            TestBook();
            Console.WriteLine();
            Console.ReadKey();
        }

        public delegate int BookComparison(Book book1, Book book2);

        public static void TestRationalNumber()
        {
            RationalNumber r1 = new RationalNumber(1, 2);
            RationalNumber r2 = new RationalNumber(1, 4);

            Console.WriteLine($"r1: {r1}");
            Console.WriteLine($"r2: {r2}");

            Console.WriteLine($"r1 == r2: {r1 == r2}");
            Console.WriteLine($"r1 != r2: {r1 != r2}");
            Console.WriteLine($"r1 < r2: {r1 < r2}");
            Console.WriteLine($"r1 > r2: {r1 > r2}");
            Console.WriteLine($"r1 <= r2: {r1 <= r2}");
            Console.WriteLine($"r1 >= r2: {r1 >= r2}");

            Console.WriteLine($"r1 + r2: {r1 + r2}");
            Console.WriteLine($"r1 - r2: {r1 - r2}");
            Console.WriteLine($"r1 * r2: {r1 * r2}");
            Console.WriteLine($"r1 / r2: {r1 / r2}");
            Console.WriteLine($"r1 % r2: {r1 % r2}");

            Console.WriteLine($"++r1: {++r1}");
            Console.WriteLine($"--r2: {--r2}");

            float floatVal = (float)r1;
            int intVal = (int)r2;
            Console.WriteLine($"r1 to float: {floatVal}");
            Console.WriteLine($"r2 to int: {intVal}");
        }

        public static void TestComplexNumber()
        {
            ComplexNumber c1 = new ComplexNumber(1, 2);
            ComplexNumber c2 = new ComplexNumber(3, -1);

            Console.WriteLine($"c1: {c1}");
            Console.WriteLine($"c2: {c2}");

            Console.WriteLine($"c1 + c2: {c1 + c2}");
            Console.WriteLine($"c1 - c2: {c1 - c2}");
            Console.WriteLine($"c1 * c2: {c1 * c2}");
            Console.WriteLine($"c1 == c2: {c1 == c2}");
            Console.WriteLine($"c1 != c2: {c1 != c2}");
        }

        public static void TestBook()
        {
            Book[] books = new Book[] 
            {
            new Book("Книга1", "Автор1", "Издатель1"),
            new Book("Книга2", "Автор2", "Издатель3"),
            new Book("Книга4", "Автор4", "Издатель1"),
            new Book("Книга3", "Автор3", "Издатель2")
            };

            BookContainer container = new BookContainer(books);

            Console.WriteLine("Сортировка по названию:");
            container.SortBooks(BookComparers.CompareByTitle);
            foreach (Book book in container.GetBooks())
            {
                Console.WriteLine(book);
            }
            Console.WriteLine();
            Console.WriteLine("Сортировка по автору:");
            container.SortBooks(BookComparers.CompareByAuthor);
            Book[] array = container.GetBooks();
            for (int i = 0; i < array.Length; i++)
            {
                Book book = array[i];
                Console.WriteLine(book);
            };
            Console.WriteLine("Сортировка по издательству:");
            container.SortBooks(BookComparers.CompareByPublisher);
            foreach (Book book in container.GetBooks())
            {
                Console.WriteLine(book);
            }
        }
    }
}
