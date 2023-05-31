namespace Services.API
{
    public interface IEventDTO
    {
        string Id { get; set; }
        string StatusId { get; set; }

        string CustomerId { get; set; }

        DateTime Time { get; set; }

        string Type { get; set; }

        string? ReasonOrDescription { get; set; }
    }
}
