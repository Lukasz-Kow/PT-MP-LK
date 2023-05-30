using Services.API;
using System;
using Presentations.Model.API;


namespace Presentations.Model.Implementation
{
    internal class BuyModel: IEventModel
    {

        public BuyModel(string id, string statusId, string customerId, DateTime time)
        {
            Id = id;
            StatusId = statusId;
            CustomerId = customerId;
            Time = time;

        }

        public string Id { get; set; }
        public string StatusId { get; set; }
        public string CustomerId { get; set; }
        public DateTime Time { get; set; }
       

        public override string ToString()
        {
            return $"Buy {Id} {StatusId} {CustomerId} {Time}";
        }
    }
}
