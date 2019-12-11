using System.Windows;
using System.Windows.Input;
using DirectoryFileCount.Managers;
using DirectoryFileCount.Models;
using DirectoryFileCount.Navigation;

namespace DirectoryFileCount.ViewModels
{
    internal class MainWindowViewModel : BasicViewModel, ILoaderOwner
    {
        private Visibility _menuVisibility = Visibility.Collapsed;
     // private ICommand _showMenuCommand;
     // private ICommand _viewHistoryCommand;
     // private ICommand _logOutCommand;
     // private ICommand _closeCommand;

        private ICommand _signInCommand;
        private ICommand _signUpCommand;

        private Visibility _loaderVisibility = Visibility.Hidden;
        private bool _isControlEnabled = true;

        public Visibility LoaderVisibility
        {
            get { return _loaderVisibility; }
            set
            {
                _loaderVisibility = value;
                OnPropertyChanged();
            }
        }
        public bool IsControlEnabled
        {
            get { return _isControlEnabled; }
            set
            {
                _isControlEnabled = value;
                OnPropertyChanged();
            }
        }

        public string CurrentUser
        {
            get
            {
                return $"Current User: {StationManager.CurrentUser}";
            }
        }

        public Visibility MenuVisibility
        {
            get { return _menuVisibility; }
            private set
            {
                _menuVisibility = value;
                OnPropertyChanged();
            }
        }

        public MainWindowViewModel()
        {
            LoaderManager.Instance.Initialize(this);
        }

        public ICommand SignInCommand
        {
            get { return _signInCommand ?? (_signInCommand = new RelayCommand<object>(SignInImplementation)); }
        }

        public ICommand SignUpCommand
        {
            get { return _signUpCommand ?? (_signUpCommand = new RelayCommand<object>(SignUpImplementation)); }
        }

        private void SignInImplementation(object obj)
        {
            NavigationManager.Instance.Navigate(ViewType.SignIn);
        }

        private void SignUpImplementation(object obj)
        {
            NavigationManager.Instance.Navigate(ViewType.SignUp);
        }

        private void ShowMenuImplementation(object obj)
        {
            MenuVisibility = _menuVisibility == Visibility.Visible ? Visibility.Collapsed : Visibility.Visible;
        }

        private void ViewHistoryImplementation(object obj)
        {
            NavigationManager.Instance.Navigate(ViewType.History);
        }

        private void LogOutImplementation(object obj)
        {
            StationManager.CurrentUser = null;
            StationManager.CurrentLocalUser = new UserLocal();
            NavigationManager.Instance.Navigate(ViewType.SignIn);
        }

        private void CloseImplementation(object obj)
        {
            StationManager.CloseApp();
        }
    }
}
