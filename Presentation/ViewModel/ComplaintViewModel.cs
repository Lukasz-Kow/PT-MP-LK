using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Presentation.Model.ModelAPI;

namespace Presentation.Model.ViewModel
{
    public partial class ComplaintViewModel : ObservableObject
    {
        private IComplaintModel _complaint;
        public ComplaintViewModel() { }
        public ComplaintViewModel(IComplaintModel complaint)
        {
            _complaint = complaint;
        }

        public string CustomerId
        {
            get { return _complaint.CustomerId; }
            set
            {
                _complaint.CustomerId = value;
                OnPropertyChanged();
            }
        }
        public string BookId
        {
            get { return _complaint.CustomerId; }
            set
            {
                _complaint.CustomerId = value;
                OnPropertyChanged();
            }
        }
        public string Reason
        {
            get { return _complaint.Reason;}
            set
            {
                _complaint.Reason = value;
                OnPropertyChanged();
            }
        }
    }
}
