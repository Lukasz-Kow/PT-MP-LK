
using Services.API;
using System;
using Presentations.Model.API;

namespace Presentations.Model.Implementation
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

        }

        public string Id { get; set; }
        public string StatusId { get; set; }
        public string CustomerId { get; set; }
        public DateTime Time { get; set; }
        public string Reason { get; set; }
        

        public override string ToString()
        {
            return $"Complaint {Id} {StatusId} {CustomerId} {Time}";
        }
    }
}
