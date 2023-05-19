using Data.API;

namespace Data.Implementation;

internal class BuyDTO: IBuy
{
    public string Id { get; }
    public string StatusId { get; }
    public string CustomerId { get; }
    public DateTime Time { get; }
}