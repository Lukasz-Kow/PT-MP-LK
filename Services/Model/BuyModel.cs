using Services.API;
namespace Services.Model
{
    internal class BuyModel : IBuy
    {
        public string Id { get; }
        public string StatusId { get; }

        public string CustomerId { get; }

        public DateTime Time { get; }

        public IServices Service { get; }
        public async Task AddAsync()
        {
            await Service.AddBuy(Id, StatusId, CustomerId, Time);
        }

        public async Task DeleteAsync()
        {
            await Service.DeleteBuy(Id);
        }
    }
}
