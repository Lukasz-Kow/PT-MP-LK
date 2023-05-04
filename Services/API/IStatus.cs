namespace Services.API
{
    internal class IStatus
    {
        string BookId { get; }

        string StatusId { get; set; }

        bool Availability { get; set; }
    }
}
