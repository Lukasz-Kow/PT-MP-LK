namespace Data.API
{
    public interface IEvent
    {
        string Id { get; }
        IStatus Status { get; }

        ICustomer Customer { get; }

        DateTime Time { get; }
    }
}
