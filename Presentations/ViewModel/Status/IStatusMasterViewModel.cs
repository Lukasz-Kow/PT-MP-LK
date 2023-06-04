using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Windows;
using Presentations.Model.API;

namespace Presentations.ViewModel
{
    public interface IStatusMasterViewModel
    {
        static IStatusMasterViewModel Create(IStatusModelOperations model, bool? showPopups = true)
        {
            return new StatusMasterViewModel(model, showPopups);
        }

        ICommand SwitchToCustomerMasterPage { get; set; }
        ICommand SwitchToProductMasterPage { get; set; }
        ICommand SwitchToEventMasterPage { get; set; }
        ICommand CreateStatus { get; set; }
        ICommand RemoveStatus { get; set; }
        ObservableCollection<IStatusDetailViewModel> Statuses { get; set; }
        string Id { get; set; }
        string BookId { get; set; }
        bool Available { get; set; }
        bool IsStatuseselected { get; set; }
        Visibility IsStatusDetailVisible { get; set; }
        IStatusDetailViewModel SelectedDetailViewModel { get; set; }
    }
}
