using System;
using Services.API;
using Presentations.Model.API;


namespace Presentations.Model.Implementation
{
    internal class ReturnModel: IEventModel
    {
        public ReturnModel(string id, string statusId, string customerId, DateTime time) 
        { 
            Id = id;
            StatusId = statusId;
            CustomerId = customerId;
            Time = time;

        }

        public string Id { get; set ; }
        public string StatusId { get; set; }
        public string CustomerId { get; set; }
        public DateTime Time { get; set; }


        public override string ToString()
        {
            return $"Return {Id} {StatusId} {CustomerId} {Time}";
        }
    }
}
