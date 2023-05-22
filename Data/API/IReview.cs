namespace Data.API;

public interface IReview : IEvent
{

    string Id { get; set; }
    
    IStatus Status { get; set; }
    
    ICustomer Customer { get; set; }
    
    DateTime Time { get; set; }
    
    string Description { get; set; }
    
}