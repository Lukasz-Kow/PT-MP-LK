using Services.API;
using Services.Implementation;

namespace Services.Model
{
    internal class StatusModel : IStatus
    {
        private readonly IBook book;

        public StatusModel(IBook book, string bookId, string id, bool availability)
        {
            this.book = book;
            BookId = bookId;
            Id = id;
            Availability = availability;
        }

        public string BookId { get; set; }

        public string Id { get; set; }
        public bool Availability { get; set; }

        public IBook Book { get; set; }

        public IServices Service { get; }

        public async Task AddAsync()
        {
            await Service.AddStatus(BookId, Id);
        }

        public async Task DeleteAsync()
        {
            await Service.DeleteStatus(Id);
        }
    }
}
