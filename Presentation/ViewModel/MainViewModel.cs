using System;
using System.Runtime.CompilerServices;
using CommunityToolkit.Mvvm.ComponentModel;
using Presentation.Model;
namespace Presentation.Model.ViewModel
{
    public partial class MainViewModel : ObservableObject
    {
        public MainViewModel()
        {
            BookViewModel = new BookViewModel(new StatusModel("", ""));
            BookInfoViewModel = new BookInfoViewModel(new BookModel("", "", "", 0, "", "", ""));
            //BuyViewModel = new BuyViewModel(new BuyModel("", "", ));
            //ReturnViewModel = new ReturnViewModel(new ReturnModel("", "", ));
            CustomerViewModel = new CustomerViewModel(new CustomerModel("", "", "", 0, "", ""));

        }

        public BookViewModel BookViewModel { get; set; }
        public BookInfoViewModel BookInfoViewModel { get; set; }
        public BuyViewModel BuyViewModel { get; set; }
        public ReturnViewModel ReturnViewModel { get; set;}
        public CustomerViewModel CustomerViewModel { get; set;}

        [ObservableProperty]
        private MainViewModel _activeBook;
        private int _selectedBook;

        public int SelectedBook
        {
            get => _selectedBook;
            set
            {
                _selectedBook = value;
                OnPropertyChanged();
                try
                {
                    _activeBook = new MainViewModel();
                    OnPropertyChanged(nameof(ActiveBook));
                }
                catch (ArgumentOutOfRangeException) { }
            }
        }

        [ObservableProperty]
        private MainViewModel _activeCustomer;
        private int _selectedCustomer;

        public int SelectedCustomer
        {
            get => _selectedCustomer;
            set
            {
                _selectedCustomer = value;
                OnPropertyChanged();
                try
                {
                    _activeCustomer = new MainViewModel();
                    OnPropertyChanged(nameof(ActiveCustomer));
                }
                catch (ArgumentOutOfRangeException) { }
            }
        }
    }
}
