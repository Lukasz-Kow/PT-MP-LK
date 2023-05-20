using Data.API;
using Data;
namespace Services.Implementation
{
    internal class Buy : IBuy
    {

        public string Id { get; set; }

        public string StatusId { get; set; }

        public string CustomerId { get; set; }

        public DateTime Time { get; set; }
    }
}
