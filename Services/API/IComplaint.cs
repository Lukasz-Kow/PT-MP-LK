namespace Services.API;

public interface IComplaint : IEvent
{

    string Id { get; set; }
    public string StatusId { get; set; }

    public string CustomerId { get; set; }

    DateTime Time { get; set; }

    string Reason { get; set; }



}