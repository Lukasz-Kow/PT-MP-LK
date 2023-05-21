namespace Data.API;

public interface IReturn
{
    
    string Id { get; }
    public IStatus Status { get; }
    
    public ICustomer Customer { get; }
    
    DateTime Time { get; }
}