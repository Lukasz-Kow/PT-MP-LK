
using System.Threading.Tasks;

namespace Presentation.Model.ModelAPI
{
    public interface IComplaintModel
    {
        string Id { get; set; }
        public string StatusId { get; set; }

        public string CustomerId { get; set; }

        DateTime Time { get; set; }

        string Reason { get; set; }

        Task AddAsync();


    }
}
