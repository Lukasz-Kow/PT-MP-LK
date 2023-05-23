using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Presentations.ViewModel
{
    public class AddBook : ViewModelBase
    {
        private string _title;
        public string Title 
        { 
            get  { return _title; } 
            set
            {
                _title = value;
                OnPropertyChanged(nameof(Title));
            }
        }

        private string _author;
        public string Author
        {
            get { return _author; }
            set
            {
                _author = value;
                OnPropertyChanged(nameof(Author));
            }
        }

        private int _pages;
        public int Pages
        {
            get { return _pages; }
            set
            {
                _pages = value;
                OnPropertyChanged(nameof(Pages));
            }
        }

        private string _id;
        public string Id
        {
            get { return _id; }
            set
            {
                _id = value;
                OnPropertyChanged(nameof(Id));
            }
        }

        private string _isbn;
        public string ISBN
        {
            get { return _isbn; }
            set
            {
                _isbn = value;
                OnPropertyChanged(nameof(ISBN));
            }
        }

        private string _publisher;
        public string Publisher
        {
            get { return _publisher; }
            set
            {
                _publisher = value;
                OnPropertyChanged(nameof(Publisher));
            }
        }

        private string _language;
        public string Language
        {
            get { return _language; }
            set
            {
                _language = value;
                OnPropertyChanged(nameof(Language));
            }
        }

        public ICommand AddCommand { get; }

        public ICommand DeleteCommand { get; }

        public AddBook() 
        {
            AddCommand = new BuyBookCommand();
        }
    }
}
