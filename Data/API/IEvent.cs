namespace Data.API;

public interface IEvent
{
    string StatusId { get; }
    
    string CustomerId { get; }
    
    DateTime Time { get; }
}