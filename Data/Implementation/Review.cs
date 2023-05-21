using Data.API;


namespace Data.Implementation
{
    internal class Review : IReview
    {
        public Review(string id,ICustomer customer, IStatus status, string description)
        {
            Id = id;
            Status = status;
            Customer = customer;
            Description = description;
            Time = DateTime.Now;
        }
        public string Id { get; }
        
        public IStatus Status { get; }
        
        public ICustomer Customer { get; }

        public DateTime Time { get; }

        public string Description { get; }
    }
}
