using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using Presentations.Model.API;

namespace Presentations.ViewModel
{
    public interface IEventMasterViewModel
    {
        static IEventMasterViewModel Create(IEventModelOperations model, bool? showPopups = true)
        {
            return new EventMasterViewModel(model, showPopups);
        }
        ICommand SwitchToUserMasterPage { get; set; }
        ICommand SwitchToProductMasterPage { get; set; }
        ICommand SwitchToStateMasterPage { get; set; }
        ICommand AddEvent { get; set; }
        ICommand RemoveEvent { get; set; }
        ObservableCollection<IEventDetailViewModel> Events { get; set; }
        string Id { get; set; }
        string StatusId { get; set; }
        string CustomerId { get; set; }
        string Type { get; set; }
        string ReasonOrDescription { get; set; }
        bool IsEventSelected { get; set; }
        Visibility IsEventDetailVisible { get; set; }
        IEventDetailViewModel SelectedDetailViewModel { get; set; }

    }
}
