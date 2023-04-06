namespace Data.API;

public interface IReturn : IEvent
{
    string StatusId { get; }
    
    string CustomerId { get; }
    
    DateTime Time { get; }
}