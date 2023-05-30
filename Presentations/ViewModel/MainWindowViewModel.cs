using Presentations.Model.Implementation;
using Presentations.ViewModel;


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

                OnPropertyChanged(nameof(SelectedViewModel));
            }
        }
    }
}
