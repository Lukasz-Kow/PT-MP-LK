namespace Data.API;

public interface IBuy : IEvent
{
    string StatusId { get; }
    
    string CustomerId { get; }
    
    DateTime Time { get; }
}