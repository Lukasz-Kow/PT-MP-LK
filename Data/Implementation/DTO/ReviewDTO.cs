using Data.API;

namespace Data.Implementation;

internal class ReviewDTO: IReview
{
    public string Id { get; }
    public string StatusId { get; }
    public string CustomerId { get; }
    public DateTime Time { get; }
    public string Description { get; }
}