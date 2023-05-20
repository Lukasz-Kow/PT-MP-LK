using Services.API;

namespace Services.Model
{
    internal class ReturnModel : IReturn
    {
        public string Id { get; set; }

        public string StatusId { get; set; }

        public string CustomerId { get; set; }

        public DateTime Time { get; set; }

        public IServices service { get; }


        public async Task AddAsync()
        {
            await service.AddReturn(Id, StatusId, CustomerId, Time);
        }

        public async Task DeleteAsync()
        {
            await service.DeleteReturn(Id);
        }
    }
}
