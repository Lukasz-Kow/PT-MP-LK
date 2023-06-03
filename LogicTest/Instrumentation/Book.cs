using Data.API;
namespace ServiceTest.Instrumentation;

public class Book : IBook
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

    public string Title { get; set; }

    public string Author { get; set; }

    public string Id { get; set; }
    
    public int Pages { get; set; }
    
    public string ISBN { get; set; }
    
    public string Publisher { get; set; }
    
    public string Language { get; set; }
    
}