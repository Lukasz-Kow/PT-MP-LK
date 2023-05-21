using Data.API;

namespace Data.Implementation;

internal class ReviewDTO: IReview
{
    public string Id { get; set; }
    public IStatus Status { get; set; }
    public ICustomer Customer { get; set; }
    public DateTime Time { get; set; }
    public string Description { get; set; }
}