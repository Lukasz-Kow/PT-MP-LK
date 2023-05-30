using System;
using System.Windows;
using System.Windows.Input;

namespace Presentation.ViewModel;

internal class CloseAppCommand : ICommand
{
    public event EventHandler CanExecuteChanged;

    public CloseAppCommand()
    {

    }

    public bool CanExecute(object parameter)
    {
        return true;
    }

    public void Execute(object parameter)
    {
        Application.Current.Shutdown();
    }
}
