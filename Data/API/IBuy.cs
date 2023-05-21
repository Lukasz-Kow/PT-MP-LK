namespace Data.API;

public interface IBuy : IEvent
{
    
    string Id { get; }
    public IStatus Status { get; }
    
    public ICustomer Customer { get; }
    
    DateTime Time { get; }
}