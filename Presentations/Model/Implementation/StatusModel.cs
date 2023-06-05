
using Presentations.Model.API;

namespace Presentations.Model.Implementation
{
    internal class StatusModel: IStatusModel
    {
        public StatusModel(string statusId, string bookId, bool availability)
        {
            Id = statusId;
            BookId = bookId;
            Availability = availability;

        }

        public string BookId { get; set; }

        public string Id { get; set; }
        public bool Availability { get; set; }
        

        public override string ToString()
        {
            return $"Status {Id} {BookId} {Availability}";
        }
    }
}
