namespace Services.API
{
    public interface IStatus
    {
        string BookId { get; }

        string StatusId { get; set; }

        bool Availability { get; set; }
    }
}
