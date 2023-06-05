
using System.ComponentModel;

namespace Presentations.ViewModel
{
    internal class ViewModelBase : INotifyPropertyChanged
    {
        public ViewModelBase SelectedViewModel;

        public ViewModelBase Parent { get; private set; }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}