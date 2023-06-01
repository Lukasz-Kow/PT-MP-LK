using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Presentations.Model;
using Presentations.Model.API;
using Presentations.ViewModel.Commands;

namespace Presentations.ViewModel;

internal class BookMasterViewModel: ViewModelBase
{
    public ICommand SwitchToCustomerMasterPage { get; set; }

    public ICommand SwitchToStatusMasterPage { get; set; }

    public ICommand SwitchToEventMasterPage { get; set; }

    public ICommand AddBook { get; set; }

    public ICommand DeleteBook { get; set; }

    private readonly IBookModelOperations _modelOperation;

    private readonly IErrorPopup _informer;

    private ObservableCollection<BookDetailViewModel> _books;

    public ObservableCollection<BookDetailViewModel> Books
    {
        get => _books;
        set
        {
            _books = value;
            OnPropertyChanged(nameof(Books));
        }
    }

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

    private string _Id;

    public string Id
    {
        get => _Id;
        set
        {
            _Id = value;
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

    private string _ISBN;

    public string ISBN
    {
        get => _ISBN;
        set
        {
            _ISBN = value;
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

    private bool _isBookSelected;

    public bool IsBookSelected
    {
        get => _isBookSelected;
        set
        {
            this.IsBookDetailVisible = value ? Visibility.Visible : Visibility.Hidden;

            _isBookSelected = value;
            OnPropertyChanged(nameof(IsBookSelected));
        }
    }

    private Visibility _isBookDetailVisible;

    public Visibility IsBookDetailVisible
    {
        get => _isBookDetailVisible;
        set
        {
            _isBookDetailVisible = value;
            OnPropertyChanged(nameof(IsBookDetailVisible));
        }
    }

    private BookDetailViewModel _selectedDetailViewModel;

    public BookDetailViewModel SelectedDetailViewModel
    {
        get => _selectedDetailViewModel;
        set
        {
            _selectedDetailViewModel = value;
            this.IsBookSelected = true;

            OnPropertyChanged(nameof(SelectedDetailViewModel));
        }
    }

    public BookMasterViewModel(IBookModelOperations? model = null, IErrorPopup? informer = null)
    {
        this.SwitchToCustomerMasterPage = new SwitchViewCommand("CustomerMasterView");
        this.SwitchToStatusMasterPage = new SwitchViewCommand("StatusMasterView");
        this.SwitchToEventMasterPage = new SwitchViewCommand("EventMasterView");

        this.AddBook = new OnClickCommand(e => this.StoreBook(), c => this.CanStoreBook());
        this.DeleteBook = new OnClickCommand(e => this.DeleteProduct());

        this.Books = new ObservableCollection<BookDetailViewModel>();

        this._modelOperation = model ?? IBookModelOperations.CreateModelOperation();
        this._informer = informer ?? new ErrorPopupHandler();

        this.IsBookSelected = false;

        Task.Run(this.LoadBooks);
    }

    private bool CanStoreBook()
    {
        return !(
            string.IsNullOrWhiteSpace(this.Title) ||
            string.IsNullOrWhiteSpace(this.Id) ||
            string.IsNullOrWhiteSpace(this.Author.ToString()) ||
            string.IsNullOrWhiteSpace(this.ISBN.ToString()) ||
            string.IsNullOrWhiteSpace(this.Publisher) ||
            string.IsNullOrWhiteSpace(this.Language)
        );
    }

    private void StoreBook()
    {
        
        this._modelOperation.AddBook(Title, Author, Id, Pages, ISBN, Publisher, Language);

        this.LoadBooks();

        this._informer.InformSuccess("Book added successfully!");

    }

    private void DeleteProduct()
    {
        
        try
        {
            this._modelOperation.DeleteBook(this.SelectedDetailViewModel.Id);

            this.LoadBooks();

            this._informer.InformSuccess("Product deleted successfully!");
        }
        catch (Exception e)
        {
            this._informer.InformError("Error while deleting product! Remember to remove all associated statuses!");
        }
       
    }

    private async void LoadBooks()
    {
        List<IBookModel> Books = (List<IBookModel>) this._modelOperation.GetAllBooks();

        
        this._books.Clear();

        foreach (IBookModel b in Books)
        {
            this._books.Add(new BookDetailViewModel(b));
        }
       
        OnPropertyChanged(nameof(Books));
    }
}