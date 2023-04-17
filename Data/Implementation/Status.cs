using Data.API;

namespace Data.Implementation;

internal class Status : IStatus
{
    private readonly IBook book;

    public Status(string statusId, IBook book)
    {
        StatusId = statusId;
        this.book = book;
        Availability = true;
    }

    public string BookId => book.Id;
    
    public string StatusId { get; set; }

    public bool Availability { get; set; }
}