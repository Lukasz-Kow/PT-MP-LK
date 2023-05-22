using Data.API;

namespace Services.Implementation;

    internal class Status : IStatus
    {
        private readonly IBook book;

        public Status(string statusId, IBook book, bool availability)
        {
            Id = statusId;
            Book = book;
            Availability = availability;
        }

        public string BookId => book.Id;

        public string Id { get; set; }

        public bool Availability { get; set; }

        public IBook Book { get; set; }
    }


