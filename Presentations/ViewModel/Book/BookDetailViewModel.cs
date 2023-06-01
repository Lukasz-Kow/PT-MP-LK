using Presentations.Model.API;
using Presentations.ViewModel.Commands;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Presentations.ViewModel
{
    internal class BookDetailViewModel : ViewModelBase
    {
        private IBookModel _bookModel;

        public BookDetailViewModel(IBookModel bookModel, IBookModelOperations? model = null, IErrorPopup? errorHandler = null)
        {
            this.Id = bookModel.Id;
            this.Title = bookModel.Title;
            this.Author = bookModel.Author;
            this.Pages = bookModel.Pages;
            this.ISBN = bookModel.ISBN;
            this.Publisher = bookModel.Publisher;
            this.Language = bookModel.Language;

            this.UpdateProduct = new OnClickCommand(e => this.Update(), c => this.CanUpdate());

            this._modelOperation = model ?? IBookModelOperations.CreateModelOperation();
            this._errorHandler = errorHandler ?? new ErrorPopupHandler();

        }

        public ICommand UpdateProduct { get; set; }

        private readonly IBookModelOperations _modelOperation;

        private readonly IErrorPopup _errorHandler;

        private string _title;

        public string Title
        {
            get => _title;
            set
            {
                _title = value;
                OnPropertyChanged(nameof(Title));
            }
        }

        private string _author;

        public string Author
        {
            get => _author;
            set
            {
                _author = value;
                OnPropertyChanged(nameof(Author));
            }
        }

        private string _id;

        public string Id
        {
            get => _id;
            set
            {
                _id = value;
                OnPropertyChanged(nameof(Id));
            }
        }

        private int _pages;

        public int Pages
        {
            get => _pages;
            set
            {
                _pages = value;
                OnPropertyChanged(nameof(Pages));
            }
        }

        private string _isbn;

        public string ISBN
        {
            get => _isbn;
            set
            {
                _isbn = value;
                OnPropertyChanged(nameof(ISBN));
            }
        }

        private string _publisher;

        public string Publisher
        {
            get => _publisher;
            set
            {
                _publisher = value;
                OnPropertyChanged(nameof(Publisher));
            }
        }

        private string _language;

        public string Language
        {
            get => _language;
            set
            {
                _language = value;
                OnPropertyChanged(nameof(Language));
            }
        }

        private void Update()
        {
            this._modelOperation.UpdateBook(this.Id, this.Title, this.Author, this.Pages, this.ISBN, this.Publisher, this.Language);

            this._errorHandler.InformSuccess("Product successfully updated!");   
        }

        private bool CanUpdate()
        {
            return !(
                string.IsNullOrWhiteSpace(this.Title) ||
                string.IsNullOrWhiteSpace(this.Author) ||
                string.IsNullOrWhiteSpace(this.Id) ||
                string.IsNullOrWhiteSpace(this.ISBN) ||
                string.IsNullOrWhiteSpace(this.Publisher) ||
                string.IsNullOrWhiteSpace(this.Language) || 
                this.Pages <= 0
            );
        }
    }
}
