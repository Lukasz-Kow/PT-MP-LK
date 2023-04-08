namespace Data.API;

public interface IReview: IEvent
{
    
    string Id { get; }
    
    string StatusId { get; }
    
    string CustomerId { get; }
    
    DateTime Time { get; }
    
    string Description { get; }
    
}