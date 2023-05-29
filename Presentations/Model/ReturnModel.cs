using System;
using Services.API;


namespace Presentations.Model
{
    internal class ReturnModel: IEventModel
    {
        public ReturnModel(string id, string statusId, string customerId, DateTime time) 
        { 
            Id = id;
            StatusId = statusId;
            CustomerId = customerId;
            Time = time;

            Service = IServices.Create("");
        }

        public string Id { get; set ; }
        public string StatusId { get; set; }
        public string CustomerId { get; set; }
        public DateTime Time { get; set; }

        public IServices Service { get; }

        public void AddReturn(string Id, string statusId, string customerId, DateTime Time)
        {
            Service.AddReturn(Id, statusId, customerId, Time);
        }

        public void DeleteReturn(string Id)
        {
            Service.DeleteEvent(Id);
        }

        public override string ToString()
        {
            return $"{Id} {StatusId} {CustomerId} {Time}";
        }
    }
}
