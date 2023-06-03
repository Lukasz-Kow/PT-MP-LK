using System;


namespace Presentations.Model.API
{
    public interface IEventModel
    {
        public string Id { get; set; }
        public string StatusId { get; set; }
        public string CustomerId { get; set; }
        public DateTime Time { get; set; }
        public string Type { get; set; }
        public string? ReasonOrDescription { get; set;}

    }
}
