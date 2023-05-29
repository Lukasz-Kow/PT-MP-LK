using Presentations.ViewModel.MVVMLight;
using Presentations.ViewModel;
using System.Windows.Input;

namespace Presentations.ViewModel;

public class MainWindowViewModel : ViewModelBase
{
    private ViewModelBase _selectedVm;
    private ICommand _SwitchViewCommand;

    public MainWindowViewModel(BookMasterViewModel selectedVm = default(BookMasterViewModel))
    {
        SelectedVm = selectedVm ?? new BookMasterViewModel();
        _SwitchViewCommand = new RelayCommand(view => { SwitchView(view.ToString()); });
    }

    public ViewModelBase SelectedVm
    {
        get => _selectedVm;
        set
        {
            _selectedVm = value;
            OnPropertyChanged(nameof(SelectedVm));
        }
    }

    public ICommand SwitchViewCommand => _SwitchViewCommand;

    public void SwitchView(string view)
    {
        switch (view)
        {
            case "UserListView":
                SelectedVm = new CustomerMasterViewModel();
                break;
            case "ProductListView":
                SelectedVm = new StatusMasterViewModel();
                break;
            case "EventListView":
                SelectedVm = new EventMasterViewModel();
                break;
        }
    }
}