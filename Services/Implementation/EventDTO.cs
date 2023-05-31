using Services.API;

namespace Services.Implementation
{
    internal class EventDTO : IEventDTO
    {

        public EventDTO (string id, string statusId, string customerId, string type, DateTime time, string reasonOrDescription = "")
        {
            Id = id;
            StatusId = statusId;
            CustomerId = customerId;
            Type = type;
            ReasonOrDescription = reasonOrDescription ?? "";
            Time = time;
        }
        
        public string Id { get; set; }
        public string StatusId { get; set; }
        public string CustomerId { get; set; }
        public string Type { get; set; }
        public string? ReasonOrDescription { get; set; }
        public DateTime Time { get ; set; }
    }
}
