using Presentations.Model;
using Presentations.ViewModel.MVVMLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentations.ViewModel.Event
{
    public class EventDetailViewModel : ViewModelBase
    {
        private IEventModel _event;

        public EventDetailViewModel(IEventModel eventModel)
        {
            _event = eventModel;
        }

        public string Id
        {
            get => _event.Id;
            set
            {
                _event.Id = value;
                RaisePropertyChanged();
            }
        }

        public string StatusId
        {
            get => _event.StatusId;
            set
            {
                _event.StatusId = value;
                RaisePropertyChanged();
            }
        }

        public string CustomerId
        {
            get => _event.CustomerId;
            set
            {
                _event.CustomerId = value;
                RaisePropertyChanged();
            }
        }

        public DateTime Time
        {
            get => _event.Time;
            set
            {
                _event.Time = value;
                RaisePropertyChanged();
            }
        }

        // Additional fields for Complaint event
        public string Reason
        {
            get
            {
                if (_event is ComplaintModel complaintEvent)
                    return complaintEvent.Reason;
                return null;
            }
            set
            {
                if (_event is ComplaintModel complaintEvent)
                {
                    complaintEvent.Reason = value;
                    RaisePropertyChanged();
                }
            }
        }

        public string Description
        {
            get
            {
                if (_event is ReviewModel complaintEvent)
                    return complaintEvent.Description;
                return null;
            }
            set
            {
                if (_event is ReviewModel complaintEvent)
                {
                    complaintEvent.Description = value;
                    RaisePropertyChanged();
                }
            }
        }
    }
}
