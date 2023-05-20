namespace Services.API
{
    public interface IStatus
    {
        string BookId { get; }

        string Id { get; set; }

        bool Availability { get; set; }

        Task AddAsync();
        Task DeleteAsync();
    }
}
