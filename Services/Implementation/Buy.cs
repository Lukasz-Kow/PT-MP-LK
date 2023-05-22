using Data.API;
using Data;
namespace Services.Implementation
{
    internal class Buy : IBuy
    {

        public Buy(string Id, IStatus status, ICustomer customer, DateTime? time) 
        {
            this.Id = Id;
            this.Status = status;
            this.Customer = customer;
            this.Time = time ?? DateTime.Now;
        
        }

        public string Id { get; set; }

        public IStatus Status { get; set; }

        public ICustomer Customer { get; set; }

        public DateTime Time { get; set; }
    }
}
