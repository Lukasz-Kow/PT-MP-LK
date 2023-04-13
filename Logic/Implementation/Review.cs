using Data.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Implementation
{
    internal class Review : IReview
    {
        public Review(string customerId, string statusId)
        {
            StatusId = statusId;
            CustomerId = customerId;
        }
        public string Id { get; }

        public string StatusId { get; }

        public string CustomerId { get; }

        public DateTime Time { get; }

        public string Description { get; }
    }
}
