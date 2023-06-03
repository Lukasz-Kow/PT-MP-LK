using Data.API;

namespace ServiceTest.Instrumentation
{
    internal class Complaint : IComplaint
    {
        public Complaint(string id, ICustomer customer, IStatus status, string reason, DateTime? date) 
        {
            Id = id;
            Customer = customer;
            Status = status;
            Reason = reason;
            Time = date ?? DateTime.Now;
        }

        public string Id { get; set; }
        public IStatus Status { get; set; }
        public ICustomer Customer { get; set; }

        public string Reason { get; set; }

        public DateTime Time { get; set; }

    }
}
