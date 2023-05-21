using Data.API;

namespace Data.Implementation
{
    internal class Return : IReturn
    {
        public Return(string id, string customerId, string statusId) 
        { 
            Id = id;
            Status = statusId;
            CustomerId = customerId;
            Time = DateTime.Now;
        }

        public string Id { get; }
        public string Status { get; }
        public string CustomerId { get; }

        public DateTime Time { get; }
    }
}
