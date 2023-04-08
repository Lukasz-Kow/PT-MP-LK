namespace Data.API;

public interface IBuy : IEvent
{
    
    string Id { get; }
    string StatusId { get; }
    
    string CustomerId { get; }
    
    DateTime Time { get; }
}