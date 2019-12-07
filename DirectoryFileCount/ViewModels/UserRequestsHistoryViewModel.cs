using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using DirectoryFileCount.DBModels;

namespace DirectoryFileCount.ViewModels
{
    class UserRequestHistoryViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Request> _requests;
        //private Thread _workingThread;
        //private CancellationToken _token;
        //private CancellationTokenSource _tokenSource;

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

        public event PropertyChangedEventHandler PropertyChanged;

       // [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
