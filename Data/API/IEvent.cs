namespace Data.API
{
    public interface IEvent
    {
        string Id { get; set; }
        IStatus Status { get; set; }

        ICustomer Customer { get; set; }

        DateTime Time { get; set; }
    }
}
