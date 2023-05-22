using Data.API;
using System.Threading.Tasks;

namespace Presentation.Model.ModelAPI
{
    public interface IStatusModel
    {
        string BookId { get; set; }

        string Id { get; set; }

        bool Availability { get; set; }

        public void AddStatus(string StatusId, IBook book, bool availability);
        public void DeleteStatus(string Id);


    }
}
