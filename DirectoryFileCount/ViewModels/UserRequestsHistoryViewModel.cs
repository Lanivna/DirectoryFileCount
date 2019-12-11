using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using DirectoryFileCount.DBModels;

namespace DirectoryFileCount.ViewModels
{
    class UserRequestHistoryViewModel : BasicViewModel, INotifyPropertyChanged
    {
        private ObservableCollection<Request> _requests;

        public ObservableCollection<Request> Requests
        {
            get => _requests;
            private set
            {
                _requests = value;
                OnPropertyChanged();
            }
        }

        internal UserRequestHistoryViewModel()
        {
            Requests = new ObservableCollection<Request>(StationManager.CurrentUser.Requests);
        }

    }
}
