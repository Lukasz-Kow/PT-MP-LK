namespace Data.API;

public interface IReturn : IEvent
{
    
    string Id { get; }
    string StatusId { get; }
    
    string CustomerId { get; }
    
    DateTime Time { get; }
}