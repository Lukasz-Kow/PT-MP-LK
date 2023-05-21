﻿using Data.API;

namespace Data.Implementation;

internal class ComplaintDTO : IComplaint
{
    public string Id { get; set;  }
    public IStatus Status { get; }
    public ICustomer Customer { get; }
    public DateTime Time { get; set; }
    public string Reason { get; set; }
}