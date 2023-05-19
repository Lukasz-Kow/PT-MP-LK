using Data.API;

namespace Data.Implementation;

internal class ComplaintDTO : IComplaint
{
    public string Id { get;  }
    public string StatusId { get; set; }
    public string CustomerId { get; set; }
    public DateTime Time { get; }
    public string Reason { get; }
}