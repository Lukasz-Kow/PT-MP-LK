using System.Threading.Tasks;

namespace Presentation.Model.ModelAPI
{
    public interface IStatusModel
    {
        string BookId { get; set; }

        string Id { get; set; }

        bool Availability { get; set; }

        Task AddAsync();
        Task DeleteAsync();
    }
}
