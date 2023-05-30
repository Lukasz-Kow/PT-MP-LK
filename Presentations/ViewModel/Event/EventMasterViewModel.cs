using Presentations.Model;
using Presentations.ViewModel.MVVMLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentations.ViewModel.Event
{
    public class EventMasterViewModel : ViewModelBase
    {
        private ObservableCollection<IEventModel> _events;
        private IEventModel _selectedEvent;
        private EventModelOperations _eventModelOperations;
        private string _actionText;

        public EventMasterViewModel()
        {
            _events = new ObservableCollection<IEventModel>();
            _eventModelOperations = new EventModelOperations();
            AddEventCommand = new RelayCommand(AddEvent);
            DeleteEventCommand = new RelayCommand(DeleteEvent);
            FetchDataCommand = new RelayCommand(FetchData);
        }

        private string _eventId;
        private string _statusId;
        private string _customerId;
        private DateTime _eventDate;
        private string _type;
        private string _descriptionOrReason;

        public ObservableCollection<IEventModel> Events
        {
            get => _events;
            set
            {
                _events = value;
                RaisePropertyChanged();
            }
        }

        public IEventModel SelectedEvent
        {
            get => _selectedEvent;
            set
            {
                _selectedEvent = value;
                RaisePropertyChanged();
                LoadDetailViewModel();
            }
        }

        public string ActionText
        {
            get => _actionText;
            set
            {
                _actionText = value;
                DisplayTextCommand.RaiseCanExecuteChanged();
                RaisePropertyChanged();
            }
        }

        public RelayCommand AddEventCommand { get; }
        public RelayCommand DeleteEventCommand { get; }
        public RelayCommand FetchDataCommand { get; }
        public RelayCommand DisplayTextCommand { get; }

        private void AddEvent()
        {
            if (_type == "Buy")
            {
                var eventModel = new BuyModel(_eventId, _statusId, _customerId, _eventDate);
                Events.Add(eventModel);
                _eventModelOperations.AddEvent(_eventId, _statusId, _customerId, _eventDate, _type, "");
            }
            else if (_type == "Return")
            {
                var eventModel = new ReturnModel(_eventId, _statusId, _customerId, _eventDate);
                Events.Add(eventModel);
                _eventModelOperations.AddEvent(_eventId, _statusId, _customerId, _eventDate, _type, "");
            }
            else if (_type == "Review")
            {
                var eventModel = new ReviewModel(_eventId, _statusId, _customerId, _eventDate, _descriptionOrReason);
                Events.Add(eventModel);
                _eventModelOperations.AddEvent(_eventId, _statusId, _customerId, _eventDate, _type, _descriptionOrReason);
            }
            else if (_type == "Complaint")
            {
                var eventModel = new ComplaintModel(_eventId, _statusId, _customerId, _eventDate, _descriptionOrReason);
                Events.Add(eventModel);
                _eventModelOperations.AddEvent(_eventId, _statusId, _customerId, _eventDate, _type, _descriptionOrReason);
            }

        }

        private void DeleteEvent()
        {
            if (SelectedEvent != null)
            {
                Events.Remove(SelectedEvent);
                _eventModelOperations.DeleteEvent(SelectedEvent.Id);
                SelectedEvent = null;
            }
        }

        private void FetchData()
        {
            var events = _eventModelOperations.GetAllEvents();
            Events = new ObservableCollection<IEventModel>(events);
        }

        private void LoadDetailViewModel()
        {
            if (SelectedEvent != null)
            {
                var detailViewModel = new EventDetailViewModel(SelectedEvent);
                // TODO: Pass the detailViewModel instance to the View for displaying additional info
            }
        }

        private void ShowPopupWindow()
        {
            // TODO: Implement logic to show the popup window with ActionText
        }
    }
}
