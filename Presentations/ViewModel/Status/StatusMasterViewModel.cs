using Presentations.Model;
using Presentations.ViewModel.MVVMLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentations.ViewModel.Status
{
    public class StatusMasterViewModel : ViewModelBase
    {
        private ObservableCollection<StatusModel> _statuses;
        private StatusModel _selectedStatus;
        private StatusModelOperations _statusModelOperations;
        private string _actionText;

        public StatusMasterViewModel()
        {
            _statuses = new ObservableCollection<StatusModel>();
            _statusModelOperations = new StatusModelOperations();
            AddStatusCommand = new RelayCommand(AddStatus);
            DeleteStatusCommand = new RelayCommand(DeleteStatus);
            FetchDataCommand = new RelayCommand(FetchData);
        }

        private string _statusId;
        private string _bookId;
        private bool _availability;

        public ObservableCollection<StatusModel> Statuses
        {
            get => _statuses;
            set
            {
                _statuses = value;
                RaisePropertyChanged();
            }
        }

        public StatusModel SelectedStatus
        {
            get => _selectedStatus;
            set
            {
                _selectedStatus = value;
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

        public RelayCommand AddStatusCommand { get; }
        public RelayCommand DeleteStatusCommand { get; }
        public RelayCommand FetchDataCommand { get; }
        public RelayCommand DisplayTextCommand { get; }

        private void AddStatus()
        {
            _statusModelOperations.AddStatus(_statusId, _bookId, _availability);
            FetchData(); // Refresh the status list after adding a new status
        }

        private void DeleteStatus()
        {
            if (SelectedStatus != null)
            {
                _statusModelOperations.DeleteStatus(SelectedStatus.Id);
                Statuses.Remove(SelectedStatus);
                SelectedStatus = null;
            }
        }

        private void FetchData()
        {
            var statuses = _statusModelOperations.GetAllStatuses();
            Statuses = new ObservableCollection<StatusModel>(statuses);
        }

        private void LoadDetailViewModel()
        {
            if (SelectedStatus != null)
            {
                var detailViewModel = new StatusDetailViewModel(SelectedStatus);
                // TODO: Pass the detailViewModel instance to the View for displaying additional info
            }
        }

        private void ShowPopupWindow()
        {
            // TODO: Implement logic to show the popup window with ActionText
        }
    }
}
