using System.Threading.Tasks;
using Data.API;
using Presentation.Model.ModelAPI;
using Services.API;

namespace Presentation.Model
{
    internal class StatusModel : IStatusModel
    {
        public StatusModel(string statusId, string bookId)
        {
            Id = statusId;
            BookId = bookId;
            Availability = true;

            Service = IServices.Create();
        }

        public string BookId { get; set; }

        public string Id { get; set; }
        public bool Availability { get; set; }
        public IServices Service { get; }

        public void AddStatus(string StatusId, IBook book, bool availability)
        {
            Service.AddStatus(StatusId, book, availability);
        }


        public void DeleteStatus(string Id)
        {
            Service.DeleteStatus(Id);
        }
    }
}
