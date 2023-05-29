
using Services.API;
using System;

namespace Presentations.Model
{
    internal class ComplaintModel: IEventModel
    {
        public ComplaintModel(string id, string statusId, string customerId, DateTime time, string reason)
        {
            Id = id;
            StatusId = statusId;
            CustomerId = customerId;
            Time = time;
            Reason = reason;

            Service = IServices.Create("");
        }

        public string Id { get; set; }
        public string StatusId { get; set; }
        public string CustomerId { get; set; }
        public DateTime Time { get; set; }
        public string Reason { get; set; }
        public IServices Service { get; }

        public void AddComplaint(string Id, string statusId, string customerId, DateTime Time, string Reason)
        {
            Service.AddComplaint(Id, statusId, customerId, Time, Reason);
        }

        public void DeleteComplaint(string Id)
        {
            Service.DeleteEvent(Id);
        }

        public override string ToString()
        {
            return $"{Id} {StatusId} {CustomerId} {Time}";
        }
    }
}
