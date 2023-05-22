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


        public BookInfoViewModel(IBookModel book)
        {
            _book = book;

        }
        private string _bookId;
        public string BookId
        {
            get => _book.Id;
            set => SetProperty(ref _bookId, value);

        }

        private string _author;
        public string Author
        {
            get => _book.Author;
            set => SetProperty(ref _author, value);

        }

        private string _title;
        public string Title
        {
            get => _book.Title;
            set => SetProperty(ref _title, value);

        }


    }
}
