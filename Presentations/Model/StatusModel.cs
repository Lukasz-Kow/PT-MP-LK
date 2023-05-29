
using Services.API;

namespace Presentations.Model
{
    public class StatusModel
    {
        public StatusModel(string statusId, string bookId, bool availability)
        {
            Id = statusId;
            BookId = bookId;
            Availability = availability;

            Service = IServices.Create("");
        }

        public string BookId { get; set; }

        public string Id { get; set; }
        public bool Availability { get; set; }
        public IServices Service { get; }

        public void AddStatus(string StatusId, string bookId, bool availability)
        {
            Service.AddStatus(StatusId, bookId, availability);
        }


        public void DeleteStatus(string Id)
        {
            Service.DeleteStatus(Id);
        }

        public override string ToString()
        {
            return $"{Id} {BookId} {Availability}";
        }
    }
}
