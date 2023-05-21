namespace Services.API;

public interface IBuy : IEvent
{

    string Id { get; set; }
    public string StatusId { get; set; }

    public string CustomerId { get; set; }

    DateTime Time { get; set; }

    Task AddAsync();


}