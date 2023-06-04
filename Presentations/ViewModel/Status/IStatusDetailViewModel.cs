using System.Windows.Input;
using Presentations.Model.API;

namespace Presentations.ViewModel
{
    public interface IStatusDetailViewModel
    {
        ICommand UpdateStatus { get; set; }
        string Id { get; set; }
        string BookId { get; set; }
        bool Available { get; set; }
    }
}
