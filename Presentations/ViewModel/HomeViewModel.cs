using Presentations.Model;
using Presentations.ViewModel.MVVMLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Presentations.ViewModel
{
    internal class HomeViewModel : ViewModelBase
    {
        public ICommand StartAppCommand { get; set; }

        public ICommand ExitAppCommand { get; set; }

        public HomeViewModel()
        {
            this.StartAppCommand = new SwitchViewCommand("UserMasterView");

            this.ExitAppCommand = new CloseApplicationCommand();
        }
    }
}
