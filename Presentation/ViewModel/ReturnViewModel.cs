using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Presentation.Model.ModelAPI;

namespace Presentation.Model.ViewModel
{
    public partial class ReturnViewModel : ObservableObject
    {
        private IReturnModel _return;
        public ReturnViewModel(IReturnModel @return)
        {
            _return = @return;
        }

        public string CustomerId
        {
            get { return _return.CustomerId; }
            set
            {
                _return.CustomerId = value;
                OnPropertyChanged();
            }
        }

        public string StateId
        {
            get { return _return.StatusId; }
            set
            {
                _return.StatusId = value;
                OnPropertyChanged();
            }
        }

    }
}
