namespace Data.API;

public interface IReturn : IEvent
{
    
    string Id { get; }
    public IStatus Status { get; }
    
    public ICustomer Customer { get; }
    
    DateTime Time { get; }
}