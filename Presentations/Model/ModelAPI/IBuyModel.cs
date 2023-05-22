
using System.Threading.Tasks;
using System;
using Data.API;

namespace Presentation.Model.ModelAPI
{
    public interface IBuyModel
    {
        string Id { get; set; }
        public string StatusId { get; set; }

        public string CustomerId { get; set; }

        DateTime Time { get; set; }

        public void AddBuy(string Id, IStatus status, ICustomer customer, DateTime Time);

        public void DeleteBuy(string Id);

    }
}
