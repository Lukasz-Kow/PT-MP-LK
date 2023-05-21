using Data.API;
using Data;
namespace Services.Implementation
{
    internal class Complaint : IComplaint
    {

        public string Id { get; set; }

        public IStatus Status { get; set; }

        public ICustomer Customer { get; set; }

        public DateTime Time { get; set; }

        public string Reason { get; set; }
    }
}
