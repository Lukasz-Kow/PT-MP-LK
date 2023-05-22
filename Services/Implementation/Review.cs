using Data.API;
using Data;
using System.Drawing;

namespace Services.Implementation
{   
    internal class Review : IReview
    {

        public Review(string id, IStatus status, ICustomer customer, string description, DateTime? time)
        {
            Id = id;
            Status = status;
            Customer = customer;
            Time = time ?? DateTime.Now;
            Description = description;
        }

        public string Id { get; set; }

        public IStatus Status { get; set; }

        public ICustomer Customer { get; set; }

        public string Description { get; set; }

        public DateTime Time { get; set; }
    }
}
