using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Presentations.ViewModel
{
    class ReturnBook : ViewModelBase
    {
        private string _id;
        public string ID
        {
            get { return _id; }
            set
            {
                _id = value;
                OnPropertyChanged(nameof(ID));
            }
        }

        private string _customerId;
        public string CustomerId
        {
            get { return _customerId; }
            set
            {
                _customerId = value;
                OnPropertyChanged(nameof(CustomerId));
            }
        }

        private DateTime _time;
        public DateTime Time
        {
            get { return _time; }
            set
            {
                _time = value;
                OnPropertyChanged(nameof(Time));
            }
        }

        private string _statusId;
        public string StatusId
        {
            get { return _statusId; }
            set
            {
                _statusId = value;
                OnPropertyChanged(nameof(StatusId));
            }
        }
        public ICommand ReturnCommand { get; }
        public ReturnBook() { }
    }
}
