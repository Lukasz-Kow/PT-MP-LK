using Presentations.Model;
using Presentations.ViewModel.MVVMLight;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Presentations.ViewModel.Book
{
    public class BookMasterViewModel : ViewModelBase
    {
        private ObservableCollection<BookModel> _books;
        private BookModel _selectedBook;
        private BookModelOperations _bookModelOperations;
        private string _actionText;

        public BookMasterViewModel()
        {
            _books = new ObservableCollection<BookModel>();
            _bookModelOperations = new BookModelOperations();
            AddBookCommand = new RelayCommand(AddBook);
            DeleteBookCommand = new RelayCommand(DeleteBook);
            FetchDataCommand = new RelayCommand(FetchData);
        }

        private string m_title;
        private string m_author;
        private string m_id;
        private int m_pages;
        private string m_isbn;
        private string m_publisher;
        private string m_language;

        public ObservableCollection<BookModel> Books
        {
            get => _books;
            set
            {
                _books = value;
                RaisePropertyChanged();
            }
        }

        public BookModel SelectedBook
        {
            get => _selectedBook;
            set
            {
                _selectedBook = value;
                RaisePropertyChanged();
                LoadDetailViewModel();
            }
        }

        public string ActionText
        {
            get => _actionText;
            set
            {
                _actionText = value;
                DisplayTextCommand.RaiseCanExecuteChanged();
                RaisePropertyChanged();
            }
        }

        public RelayCommand AddBookCommand { get; }
        public RelayCommand DeleteBookCommand { get; }
        public RelayCommand FetchDataCommand { get; }
        public RelayCommand DisplayTextCommand { get; }

        private void AddBook()
        {
            var bookModel = new BookModel(m_title, m_author, m_id, m_pages, m_isbn, m_publisher, m_language);
            Books.Add(bookModel);
            _bookModelOperations.AddBook(m_title, m_author, m_id, m_pages, m_isbn, m_publisher, m_language);

        }

        private void DeleteBook()
        {
            if (SelectedBook != null)
            {
                Books.Remove(SelectedBook);
                _bookModelOperations.DeleteBook(SelectedBook.Id);
                SelectedBook = null;
            }
        }

        private void FetchData()
        {
            var books = _bookModelOperations.GetAllBooks();
            Books = new ObservableCollection<BookModel>(books);
        }

        private void LoadDetailViewModel()
        {
            if (SelectedBook != null)
            {
                var detailViewModel = new BookDetailViewModel(SelectedBook);
                // TODO: Pass the detailViewModel instance to the View for displaying additional info
            }
        }


        private void ShowPopupWindow()
        {
            // TODO: Implement logic to show the popup window with ActionText
        }
    }
}
