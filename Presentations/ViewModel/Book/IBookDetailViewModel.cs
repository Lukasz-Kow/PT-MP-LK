
using System.Windows.Input;

namespace Presentations.ViewModel
{
    public interface IBookDetailViewModel
    {
        ICommand UpdateProduct { get; set; }
        string Title { get; set; }
        string Author { get; set; }
        string Id { get; set; }
        int Pages { get; set; }
        string ISBN { get; set; }
        string Publisher { get; set; }
        string Language { get; set; }
    }
}
