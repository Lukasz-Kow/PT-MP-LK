using Data.API;

namespace ServiceTest.Instrumentation
{
    internal class Buy : IBuy
    {
        public Buy(string id, ICustomer customer, IStatus status, DateTime? date)
        {
            Id = id;
            Status = status;
            Customer = customer;
            Time = date ?? DateTime.Now;
        }
        public string Id { get; set; }
        public IStatus Status { get; set; }
        public ICustomer Customer { get; set; }
        public DateTime Time { get; set; }
    }
}
