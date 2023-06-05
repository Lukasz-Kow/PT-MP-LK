using System;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Input;

namespace Presentations.ViewModel.Commands;

internal class SwitchViewCommand : ICommand
{
    public event EventHandler CanExecuteChanged;

    private string _switchToViewModel;

    public SwitchViewCommand(string viewModel)
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
                    case "CustomerMasterView":
                        mainViewModel.SelectedViewModel = new CustomerMasterViewModel(); break;
                    case "EventMasterView":
                        mainViewModel.SelectedViewModel = new EventMasterViewModel(); break;
                    case "StatusMasterView":
                        mainViewModel.SelectedViewModel = new StatusMasterViewModel(); break;
                    case "BookMasterView":
                        mainViewModel.SelectedViewModel = new BookMasterViewModel(); break;
                }
            }
        }
    }
}