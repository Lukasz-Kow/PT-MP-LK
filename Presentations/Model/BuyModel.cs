using Services.API;
using System;


namespace Presentations.Model
{
    public class BuyModel: IEventModel
    {

        public BuyModel(string id, string statusId, string customerId, DateTime time)
        {
            Id = id;
            StatusId = statusId;
            CustomerId = customerId;
            Time = time;

            Service = IServices.Create("");
        }

        public string Id { get; set; }
        public string StatusId { get; set; }
        public string CustomerId { get; set; }
        public DateTime Time { get; set; }
        public IServices Service { get; }

        public void AddBuy(string Id, string statusId, string customerId, DateTime Time)
        {
            Service.AddBuy(Id, statusId, customerId, Time);
        }

        public void DeleteBuy(string Id)
        {
            Service.DeleteEvent(Id);
        }

        public override string ToString()
        {
            return $"{Id} {StatusId} {CustomerId} {Time}";
        }
    }
}
