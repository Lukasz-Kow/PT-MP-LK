namespace Services.API
{
    internal class IRent
    {
        string Id { get; }
        string StatusId { get; }

        string CustomerId { get; }

        DateTime Time { get; }
    }
}
