using Data.API;

namespace Data.Implementation
{
    internal class Complaint : IComplaint
    {
        public Complaint(string id, ICustomer customer, IStatus status, string reason) 
        {
            Id = id;
            Customer = customer;
            Status = status;
            Reason = reason;
            Time = DateTime.Now;
        }

        public string Id { get; }
        public IStatus Status { get; }
        public ICustomer Customer { get; }

        public string Reason { get; }

        public DateTime Time { get; }

    }
}
