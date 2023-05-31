namespace Data.API;

public interface IReturn : IEvent
{
    
    string Id { get; set; }
    public IStatus Status { get; set; }
    
    public ICustomer Customer { get; set; }
    
    public DateTime Time { get; set; }
}