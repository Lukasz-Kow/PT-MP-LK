using Presentations.Model;
using Presentations.ViewModel;
using Presentations.ViewModel.MVVMLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentations.ViewModel
{
    internal class MainWindowViewModel : ViewModelBase
    {
        private ViewModelBase _selectedViewModel { get; set; }


        public MainWindowViewModel()
        {
            this._selectedViewModel = new HomeViewModel();
        }

        public new ViewModelBase SelectedViewModel
        {
            get => _selectedViewModel;
            set
            {
                _selectedViewModel = value;

                RaisePropertyChanged(nameof(SelectedViewModel));
            }
        }
    }
}
