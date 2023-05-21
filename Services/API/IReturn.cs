namespace Services.API
{
    public interface IReturn : IEvent
    {
        string Id { get; set; }
        public string StatusId { get; set; }

        public string CustomerId { get; set; }

        DateTime Time { get; set; }

    }
}
