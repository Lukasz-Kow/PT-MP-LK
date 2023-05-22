using System;
using System.Threading.Tasks;
using Data.API;
using Presentation.Model.ModelAPI;
using Services.API;


namespace Presentation.Model
{
    internal class ReturnModel : IReturnModel
    {
        public ReturnModel(string statusId, string customerId, DateTime time) 
        { 
            Id = Guid.NewGuid().ToString();
            StatusId = statusId;
            CustomerId = customerId;
            Time = time;

            Service = IServices.Create();
        }

        public string Id { get; set ; }
        public string StatusId { get; set; }
        public string CustomerId { get; set; }
        public DateTime Time { get; set; }

        public IServices Service { get; }

        public void AddReturn(string Id, IStatus status, ICustomer customer, DateTime Time)
        {
            Service.AddReturn(Id, status, customer, Time);
        }
    }
}
