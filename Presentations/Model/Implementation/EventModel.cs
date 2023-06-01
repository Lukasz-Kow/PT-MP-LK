using Presentations.Model.API;
using System;

namespace Presentations.Model.Implementation
{
    internal class EventModel : IEventModel
    {

        public EventModel (string id, string statusId, string customerId, DateTime time, string type, string? reasonOrDescription)
        {
            Id = id;
            StatusId = statusId;
            CustomerId = customerId;
            Time = time;
            Type = type;
            ReasonOrDescription = reasonOrDescription ?? null;
        }

        public string Id { get; set; }
        public string StatusId { get; set; }
        public string CustomerId { get; set; }
        public DateTime Time { get; set; }
        public string Type { get; set; }
        public string? ReasonOrDescription { get; set; }

        public override string ToString()
        {
            return $"{Type} event {Id} {StatusId} {CustomerId} {Time} {ReasonOrDescription}";
        }
    }
}
