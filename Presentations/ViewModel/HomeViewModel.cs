
using System.Windows.Input;
using Presentations.ViewModel;
using Presentations.ViewModel.Commands;

namespace Presentations.ViewModel
{
    internal class HomeViewModel : ViewModelBase
    {
        public ICommand StartAppCommand { get; set; }

        public ICommand ExitAppCommand { get; set; }

        public HomeViewModel()
        {
            this.StartAppCommand = new SwitchViewCommand("UserMasterView");

            this.ExitAppCommand = new CloseAppCommand();
        }
    }
}
