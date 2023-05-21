using System.Threading.Tasks;
using Presentation.Model.ModelAPI;
using Services.API;


namespace Presentation.Model
{
    internal class ComplaintModel : IComplaintModel
    {
        public ComplaintModel(string statusId, string customerId, DateTime time, string reason)
        {
            Id = Guid.NewGuid().ToString();
            StatusId = statusId;
            CustomerId = customerId;
            Time = time;
            Reason = reason;

            Service = IServices.Create();
        }

        public string Id { get; set; }
        public string StatusId { get; set; }
        public string CustomerId { get; set; }
        public DateTime Time { get; set; }
        public string Reason { get; set; }
        public IServices Service { get; }

        public async Task AddAsync()
        {
            await Service.AddComplaint(Id, StatusId, CustomerId, Time, Reason);
        }
    }
}
