using Services.API;

namespace Services.Model
{
    internal class ComplaintModel : IComplaint
    {
        public string Id { get; set; }

        public string StatusId { get; set; }

        public string CustomerId { get; set; }

        public DateTime Time { get; set; }

        public string Reason { get; set; }

        public IServices service { get; }

        public async Task AddAsync()
        {
            await service.AddComplaint(Id, StatusId, CustomerId, Time, Reason);
        }

        public async Task DeleteAsync()
        {
            await service.DeleteComplaint(Id);
        }
    }
}
