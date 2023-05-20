using Data.API;
using Data;
namespace Services.Implementation
{
    internal class Complaint : IComplaint
    {

        public string Id { get; set; }

        public string StatusId { get; set; }

        public string CustomerId { get; set; }

        public DateTime Time { get; set; }

        public string Reason { get; set; }
    }
}
