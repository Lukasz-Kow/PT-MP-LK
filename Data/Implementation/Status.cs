using Data.API;

namespace Data.Implementation;

internal class Status : IStatus
{
    private readonly IBook book;

    public Status(string statusId, IBook book)
    {
        Id = statusId;
        Book = book;
        Availability = true;
    }

    public string BookId => book.Id;
    
    public string Id { get; set; }

    public bool Availability { get; set; }
    
    public IBook Book { get; set; }
}