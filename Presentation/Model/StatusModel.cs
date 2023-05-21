using System.Threading.Tasks;
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

        public async Task AddAsync()
        {
            await Service.AddStatus(Id, BookId);
        }

        public async Task DeleteAsync()
        {
            await Service.DeleteStatus(Id);
        }
    }
}
