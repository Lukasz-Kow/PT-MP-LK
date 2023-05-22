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

        private string _statusId;
        public string StatusId
        {
            get { return _status.Id; }
            set => SetProperty(ref _statusId, value);

        }

        private string _bookId;
        public string BookId
        {
            get { return _status.BookId; }
            set => SetProperty(ref _bookId, value);

        }


    }
}
