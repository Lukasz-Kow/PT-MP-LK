namespace Data.API;

public interface IComplaint : IEvent
{
    
    string Id { get; set; }
    public IStatus Status { get; set; }
    
    public ICustomer Customer { get; set; }
    
    DateTime Time { get; set; }
    
    string Reason { get; set; }
}