using System;
using System.Threading.Tasks;
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

        public async Task AddAsync()
        {
            await Service.AddReturn(Id, StatusId, CustomerId, Time);    
        }
    }
}
