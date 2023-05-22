using Data.API;


namespace Data.Implementation
{
    internal class Review : IReview
    {
        public Review(string id,ICustomer customer, IStatus status, string description, DateTime? date)
        {
            Id = id;
            Status = status;
            Customer = customer;
            Description = description;
            Time = date ?? DateTime.Now;
        }
        public string Id { get; set; }
        
        public IStatus Status { get; set; }
        
        public ICustomer Customer { get; set; }

        public DateTime Time { get; set; }

        public string Description { get; set; }
    }
}
