﻿using Data.API;

namespace Data.Implementation
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