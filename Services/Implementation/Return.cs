using Data.API;
using Data;
namespace Services.Implementation
{   
    internal class Return : IReturn
    {

        public string Id { get; set; }

        public IStatus Status { get; set; }

        public ICustomer Customer { get; set; }

        public DateTime Time { get; set; }
    }
}
