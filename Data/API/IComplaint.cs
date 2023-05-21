namespace Data.API;

public interface IComplaint
{
    
    string Id { get; }
    public IStatus Status { get; }
    
    public ICustomer Customer { get; }
    
    DateTime Time { get; }
    
    string Reason { get; }
}