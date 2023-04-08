namespace Data.API;

public interface IComplaint: IEvent
{
    
    string Id { get; }
    public string StatusId { get; }
    
    public string CustomerId { get; }
    
    public DateTime Time { get; }
    
    public string Reason { get; }
}