using Data.API;


namespace Logic.Implementation
{
    internal class Review : IReview
    {
        public Review(string id,string customerId, string statusId, string description)
        {
            Id = id;
            StatusId = statusId;
            CustomerId = customerId;
            Description = description;
            Time = DateTime.Now;
        }
        public string Id { get; }

        public string StatusId { get; }

        public string CustomerId { get; }

        public DateTime Time { get; }

        public string Description { get; }
    }
}
