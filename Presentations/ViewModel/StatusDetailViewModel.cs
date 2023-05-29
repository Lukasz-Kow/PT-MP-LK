using Presentations.Model;
using Presentations.ViewModel.MVVMLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentations.ViewModel
{
    public class StatusDetailViewModel : ViewModelBase
    {
        private StatusModel _status;

        public StatusDetailViewModel(StatusModel status)
        {
            _status = status;
        }

        public string Id
        {
            get => _status.Id;
            set
            {
                _status.Id = value;
                RaisePropertyChanged();
            }
        }

        public string BookId
        {
            get => _status.BookId;
            set
            {
                _status.BookId = value;
                RaisePropertyChanged();
            }
        }

        public bool Availability
        {
            get => _status.Availability;
            set
            {
                _status.Availability = value;
                RaisePropertyChanged();
            }
        }
    }
}
