namespace Data.API;

public interface IReview
{

    string Id { get; }
    
    string StatusId { get; }
    
    string CustomerId { get; }
    
    DateTime Time { get; }
    
    string Description { get; }
    
}