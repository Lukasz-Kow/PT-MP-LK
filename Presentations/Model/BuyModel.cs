using Data.API;
using Presentation.Model.ModelAPI;
using Services.API;
using System;
using System.Threading.Tasks;

namespace Presentation.Model
{
    public class BuyModel : IBuyModel
    {

        public BuyModel(string statusId, string customerId, DateTime time)
        {
            Id = Guid.NewGuid().ToString();
            StatusId = statusId;
            CustomerId = customerId;
            Time = time;

            Service = IServices.Create();
        }

        public string Id { get; set; }
        public string StatusId { get; set; }
        public string CustomerId { get; set; }
        public DateTime Time { get; set; }
        public IServices Service { get; }

        public void AddBuy(string Id, IStatus status, ICustomer customer, DateTime Time)
        {
            Service.AddBuy(Id, status, customer, Time);
        }

        public void DeleteBuy(string Id)
        {
            Service.DeleteBuy(Id);
        }
    }
}
