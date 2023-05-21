using System.Threading.Tasks;
using Presentation.Model.ModelAPI;
using Services.API;

namespace Presentation.Model
{
    public class BookModel : IBookModel
    {

        public BookModel(string title, string author, string id, int pages, string iSBN, string publisher, string language) 
        { 
            Title = title;
            Author = author;
            Id = id;
            Pages = pages;
            Publisher = publisher;
            Language = language;

            Service = IServices.Create();

        }

        public string Title { get; set; }
        public string Author  {get; set; }
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
