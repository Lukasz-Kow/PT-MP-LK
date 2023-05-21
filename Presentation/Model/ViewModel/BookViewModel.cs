using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Presentation.Model.ModelAPI;

namespace Presentation.Model.ViewModel
{
    public partial class BookViewModel : ObservableObject
    {
        private IStatusModel _status;

        public BookViewModel() { }
        public BookViewModel(IStatusModel status)
        {
            _status = status;
        }

        public string Id
        {
            get { return _status.Id; }
            set
            {
                _status.Id = value;
                OnPropertyChanged();
            }
        }

        public string BookId
        {
            get { return _status.BookId; }
            set
            {
                _status.BookId = value;
                OnPropertyChanged();
            }
        }

        [ICommand]
        private async Task AddStatus()
        {
            await _status.AddAsync();
        }

        [ICommand]
        private async Task DeleteStatus()
        {
            await _status.DeleteAsync();
        }

    }
}
