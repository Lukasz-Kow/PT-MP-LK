using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Presentation.Model.ModelAPI;
using System.Threading.Tasks;


namespace Presentation.Model.ViewModel
{
    public partial class BookInfoViewModel : ObservableObject
    {
        [ObservableProperty]
        private IBookModel _book;

        private bool _newBook = false;

        public BookInfoViewModel() { }

        public BookInfoViewModel(IBookModel book)
        {
            _book = book;

        }
        public string InfoId
        {
            get => _book.Id;
            set
            {
                _book.Id = value;
                OnPropertyChanged();
            }
        }

        public string Author
        {
            get => _book.Author;
            set
            {
                _book.Author = value;
                OnPropertyChanged();
            }
        }

        [ICommand]
        private async Task AddStatus()
        {
            await _book.AddAsync();
        }

        [ICommand]
        private async Task DeleteStatus()
        {
            await _book.DeleteAsync();
        }
    }
}
