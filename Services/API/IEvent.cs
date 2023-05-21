
namespace Services.API
{
    public interface IEvent
    {
        string Id { get; }
        string StatusId { get; }
        string CustomerId { get; }
        DateTime Time { get; }

        Task AddAsync();
        Task DeleteAsync();

    }
}
