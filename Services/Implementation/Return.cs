﻿using Data.API;
using Data;
using System.Drawing;

namespace Services.Implementation
{   
    internal class Return : IReturn
    {

        public Return(string id, IStatus status, ICustomer customer, DateTime? time)
        {
            Id = id;
            Status = status;
            Customer = customer;
            Time = time ?? DateTime.Now;
        }

        public string Id { get; set; }

        public IStatus Status { get; set; }

        public ICustomer Customer { get; set; }

        public DateTime Time { get; set; }
    }
}
