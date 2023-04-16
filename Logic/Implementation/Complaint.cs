using Data.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Implementation
{
    internal class Complaint : IComplaint
    {
        public Complaint(string id, string customerId, string statusId, string reason) 
        {
            Id = id;
            CustomerId = customerId;
            StatusId = statusId;
            Reason = reason;
            Time = DateTime.Now;
        }

        public string Id { get; }

        public string CustomerId { get; }

        public string StatusId { get; }

        public string Reason { get; }

        public DateTime Time { get; }

    }
}
