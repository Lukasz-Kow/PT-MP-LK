namespace Services.API;

public interface IComplaint : IEvent
{

    string Id { get; }
    string StatusId { get; }

    string CustomerId { get; }

    DateTime Time { get; }

    string Reason { get; }


}