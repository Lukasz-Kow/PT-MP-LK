namespace Data.API;

public interface IReview
{

    string Id { get; }
    
    IStatus Status { get; }
    
    ICustomer Customer { get; }
    
    DateTime Time { get; }
    
    string Description { get; }
    
}