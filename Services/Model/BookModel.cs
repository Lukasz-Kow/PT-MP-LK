using Services.API;

namespace Services.Model
{
    internal class BookModel : IBook
    {
        public BookModel(string title, string author, string id, int pages, string ISBN, string publisher, string language, IServices service)
        {
            Title = title;
            Author = author;
            Id = id;
            Pages = pages;
            this.ISBN = ISBN;
            Publisher = publisher;
            Language = language;
            Service = service;
        }
        public string Title { get; set; }

        public string Author { get; set; }

        public string Id { get; set; }

        public int Pages { get; set; }

        public string ISBN { get; set; }

        public string Publisher { get; set; }

        public string Language { get; set; }
    
        public IServices Service { get; }

        public async Task AddAsync()
        {
            await Service.AddBook(Title, Author, Id, Pages, ISBN, Publisher, Language);
        }
        public async Task DeleteAsync()
        {
            await Service.DeleteBook(Id);
        }
    }
}
