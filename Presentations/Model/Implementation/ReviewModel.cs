using System;
using Presentations.Model.API;

namespace Presentations.Model.Implementation
{
    internal class ReviewModel: IEventModel
    {
        public string Id { get; set; }
        public string StatusId { get; set; }
        public string CustomerId { get; set; }
        public DateTime Time { get; set; }
        public string Description { get; set; }

        public ReviewModel(string id, string statusId, string customerId, DateTime time, string desc)
        {
            Id = id;
            StatusId = statusId;
            CustomerId = customerId;
            Time = time;
            Description = desc;
        }

        public override string ToString()
        {
            return $"Review {Id} {StatusId} {CustomerId} {Time}";
        }
    }
}
