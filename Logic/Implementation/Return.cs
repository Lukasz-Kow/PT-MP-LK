using Data.API;

namespace Logic.Implementation
{
    internal class Return : IReturn
    {
        public Return(string id, string customerId, string statusId) 
        { 
            Id = id;
            StatusId = statusId;
            CustomerId = customerId;
            Time = DateTime.Now;
        }

        public string Id { get; }
        public string StatusId { get; }
        public string CustomerId { get; }

        public DateTime Time { get; }
    }
}
