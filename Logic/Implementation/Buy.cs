using Data.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Implementation
{
    internal class Buy : IBuy
    {
        public Buy(string customerId, string statusId)
        {
            StatusId = statusId;
            CustomerId = customerId;
        }
        public string Id { get; }
        public string StatusId { get; }
        public string CustomerId { get; }

        public DateTime Time { get; }
    }
}
