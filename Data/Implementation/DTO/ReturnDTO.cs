﻿using Data.API;

namespace Data.Implementation;

internal class ReturnDTO: IReturn
{
    public string Id { get; set; }
    public string StatusId { get; set; }
    public string CustomerId { get; set; }
    public DateTime Time { get; set; }
}