using System;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Input;
using Presentations.ViewModel.Event;
using Presentations.ViewModel.Status;
using Presentations.ViewModel;
using Presentations.ViewModel.Customer;
using Presentations.ViewModel.Book;

namespace Presentations.ViewModel;

internal class UpdateMainViewModel : ICommand
{
    public event EventHandler CanExecuteChanged;

    private string _switchToViewModel;

    public UpdateMainViewModel(string viewModel)
    {
        this._switchToViewModel = viewModel;
    }

    public bool CanExecute(object parameter)
    {
        return true;
    }

    public void Execute(object parameter)
    {
        UserControl userControl = parameter as UserControl;

        Window parentWindow = Window.GetWindow(userControl);

        if (parentWindow != null)
        {
            if (parentWindow.DataContext is MainWindowViewModel mainViewModel)
            {
                switch (this._switchToViewModel)
                {
                    case "UserMasterView":
                        mainViewModel.SelectedViewModel = new CustomerMasterViewModel(); break;
                    case "EventMasterView":
                        mainViewModel.SelectedViewModel = new EventMasterViewModel(); break;
                    case "StateMasterView":
                        mainViewModel.SelectedViewModel = new StatusMasterViewModel(); break;
                    case "ProductMasterView":
                        mainViewModel.SelectedViewModel = new BookMasterViewModel(); break;
                }
            }
        }
    }
}
