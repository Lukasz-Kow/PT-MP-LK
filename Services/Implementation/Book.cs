using Data.API;

namespace Services.Implementation
{
    internal class Book : IBook
    {
        public Book(string id, string title, string author, int pages, string ISBN, string publisher, string language)
        {
            Title = title;
            Author = author;
            Id = id;
            Pages = pages;
            this.ISBN = ISBN;
            Publisher = publisher;
            Language = language;
        }

        public string Title { get; }

        public string Author { get; }

        public string Id { get; }

        public int Pages { get; }

        public string ISBN { get; }

        public string Publisher { get; }

        public string Language { get; }
    }
}
