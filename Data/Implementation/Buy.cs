using Data.API;

namespace Data.Implementation
{
    internal class Buy : IBuy
    {
        public Buy(string id, ICustomer customer, IStatus status)
        {
            Id = id;
            Status = status;
            Customer = customer;
            Time = DateTime.Now;
        }
        public string Id { get; }
        public IStatus Status { get; }
        public ICustomer Customer { get; }
        public DateTime Time { get; }
    }
}
