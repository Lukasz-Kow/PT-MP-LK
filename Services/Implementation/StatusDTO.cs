using Services.API;

namespace Services.Implementation;

    internal class StatusDTO : IStatusDTO
    {

        public StatusDTO(string statusId, string bookId, bool availability)
        {
            Id = statusId;
            BookId = bookId;
            Availability = availability;
        }

        public string BookId { get; set; }

        public string Id { get; set; }

        public bool Availability { get; set; }

        
    }


