using Services.API;
using System.Collections.Generic;
using System.Windows.Documents;

namespace Presentations.Model
{
    public class BookModel
    {

        public BookModel(string title, string author, string Id, int pages, string isbn, string publisher, string language) 
        {
            Title = title;
            Author = author;
            this.Id = Id;
            Pages = pages;
            ISBN = isbn;
            Publisher = publisher;
            Language = language;
        }

        public string Title { get; set; }
        public string Author  {get; set; }
        public string Id { get; set; }
        public int Pages { get; set; }
        public string ISBN { get; set; }
        public string Publisher { get; set; }
        public string Language { get; set; }

        public override string ToString()
        {
            return $"{Title} {Author} {Id}";
        }

    }
}
