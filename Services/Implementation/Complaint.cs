using Data.API;
using Data;
namespace Services.Implementation
{
    internal class Complaint : IComplaint
    {

        public Complaint(string id, IStatus status, ICustomer customer, string reason, DateTime? time) 
        {
            Id = id;
            Status = status;
            Customer = customer;
            Reason = reason;
            Time = time ?? DateTime.Now;
        }

        public string Id { get; set; }

        public IStatus Status { get; set; }

        public ICustomer Customer { get; set; }

        public DateTime Time { get; set; }

        public string Reason { get; set; }
    }
}
