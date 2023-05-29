using System;
using System.Windows.Input;

namespace Presentations.ViewModel.MVVMLight
{
    public class UpdateMainViewModel : ICommand
    {
        private readonly MainViewModel _viewModel;

        public UpdateMainViewModel(MainViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            if (parameter.ToString() == "Customers")
                _viewModel.SelectedViewModel = new CustomerMasterViewModel();
            else if (parameter.ToString() == "Books")
                _viewModel.SelectedViewModel = new BookMasterViewModel();
            else
                _viewModel.SelectedViewModel = new MainViewModel();
        }
    }
}
