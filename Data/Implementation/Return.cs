using Data.API;

namespace Data.Implementation
{
    internal class Return : IReturn
    {
        private IStatus _status;

        public Return(string id, ICustomer customer, IStatus status) 
        { 
            Id = id;
            Status = status;
            Customer = customer;
            Time = DateTime.Now;
        }

        public string Id { get; }

        public IStatus Status{ get; set;}

        public ICustomer Customer { get; }

        public DateTime Time { get; }
    }
}
