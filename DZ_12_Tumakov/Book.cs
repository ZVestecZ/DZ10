﻿namespace DZ_12_Tumakov
{
    internal class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }

        public Book(string title, string author, string publisher)
        {
            Title = title;
            Author = author;
            Publisher = publisher;
        }

        public override string ToString()
        {
            return $"Название: {Title}, Автор: {Author}, Издательство: {Publisher}";
        }
    }
}
