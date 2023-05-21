namespace Data.API;

public interface IReview : IEvent
{

    string Id { get; }
    
    IStatus Status { get; }
    
    ICustomer Customer { get; }
    
    DateTime Time { get; }
    
    string Description { get; }
    
}