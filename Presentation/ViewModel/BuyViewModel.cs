using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Presentation.Model.ModelAPI;

namespace Presentation.Model.ViewModel
{
    public partial class BuyViewModel : ObservableObject
    {
        private IBuyModel _buy;
        public BuyViewModel() { }
        public BuyViewModel(IBuyModel buy)
        {
            _buy = buy;
        }

        public string CustomerId
        {
            get { return _buy.CustomerId; }
            set
            {
                _buy.CustomerId = value;
                OnPropertyChanged();
            }
        }

        public string StatusId
        {
            get { return _buy.StatusId; }
            set
            {
                _buy.StatusId = value;
                OnPropertyChanged();
            }
        }


    }
}
