using Data.API;

namespace Data.Implementation;

internal class Status : IStatus
{
    private readonly IBook book;

    public Status(string stateId, IBook book)
    {
        StatusId = stateId;
        this.book = book;
        Availability = true;
    }

    public string BookId => book.Id;
    
    public string StatusId { get; set; }

    public bool Availability { get; set; }
}