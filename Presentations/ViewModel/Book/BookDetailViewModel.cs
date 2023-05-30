using Presentations.Model;
using Presentations.ViewModel.MVVMLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentations.ViewModel.Book
{
    public class BookDetailViewModel : ViewModelBase
    {
        private BookModel _bookModel;

        public BookDetailViewModel(BookModel bookModel)
        {
            _bookModel = bookModel;
        }

        public string Title
        {
            get => _bookModel.Title;
            set
            {
                _bookModel.Title = value;
                RaisePropertyChanged();
            }
        }

        public string Author
        {
            get => _bookModel.Author;
            set
            {
                _bookModel.Author = value;
                RaisePropertyChanged();
            }
        }

        public string Id
        {
            get => _bookModel.Id;
            set
            {
                _bookModel.Id = value;
                RaisePropertyChanged();
            }
        }

        public int Pages
        {
            get => _bookModel.Pages;
            set
            {
                _bookModel.Pages = value;
                RaisePropertyChanged();
            }
        }

        public string ISBN
        {
            get => _bookModel.ISBN;
            set
            {
                _bookModel.ISBN = value;
                RaisePropertyChanged();
            }
        }

        public string Publisher
        {
            get => _bookModel.Publisher;
            set
            {
                _bookModel.Publisher = value;
                RaisePropertyChanged();
            }
        }

        public string Language
        {
            get => _bookModel.Language;
            set
            {
                _bookModel.Language = value;
                RaisePropertyChanged();
            }
        }
    }
}
