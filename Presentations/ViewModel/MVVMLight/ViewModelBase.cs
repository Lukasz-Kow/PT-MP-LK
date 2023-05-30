﻿using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Presentations.ViewModel.MVVMLight
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged

        public ViewModelBase SelectedViewModel;

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion INotifyPropertyChanged

        #region API

        protected virtual void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion API
    }
}