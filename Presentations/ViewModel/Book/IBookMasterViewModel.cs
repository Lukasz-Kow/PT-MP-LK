using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Windows;
using Presentations.Model.API;


namespace Presentations.ViewModel
{
    public interface IBookMasterViewModel
    {
        static IBookMasterViewModel Create(IBookModelOperations model, bool? showPopups = true)
        {
            return new BookMasterViewModel(model, showPopups);
        }

        public ICommand SwitchToCustomerMasterPage { get; set; }
        public ICommand SwitchToStatusMasterPage { get; set; }
        public ICommand SwitchToEventMasterPage { get; set; }
        public ICommand AddBook { get; set; }
        public ICommand DeleteBook { get; set; }
        ObservableCollection<IBookDetailViewModel> Books { get; set; }
        string Title { get; set; }
        string Author { get; set; }
        string Id { get; set; }
        int Pages { get; set; }
        string ISBN { get; set; }
        string Publisher { get; set; }
        string Language { get; set; }
        bool IsBookSelected { get; set; }
        Visibility IsBookDetailVisible { get; set; }
        IBookDetailViewModel SelectedDetailViewModel { get; set; }
    }
}
