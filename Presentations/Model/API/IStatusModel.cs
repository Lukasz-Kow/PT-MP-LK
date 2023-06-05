

namespace Presentations.Model.API
{
    public interface IStatusModel
    {
        public string BookId { get; set; }

        public string Id { get; set; }
        public bool Availability { get; set; }
    }
}
