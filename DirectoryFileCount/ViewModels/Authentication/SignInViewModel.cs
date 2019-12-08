using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using DirectoryFileCount.DBModels;
using DirectoryFileCount.Managers;
using DirectoryFileCount.Models;
using DirectoryFileCount.Navigation;

namespace DirectoryFileCount.ViewModels
{
    internal class SignInViewModel : BasicViewModel
    {
        #region Fields
        private string _email;
        private string _password;

        #region Commands
        private ICommand _signInCommand;
        private ICommand _signUpCommand;
        private ICommand _closeCommand;
        #endregion
        #endregion

        #region Properties
        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                OnPropertyChanged();
            }
        }
        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged();
            }
        }

        #region Commands

        public ICommand SignInCommand
        {
            get
            {
                return _signInCommand ?? (_signInCommand =
                           new RelayCommand<object>(SignInImplementation, CanSignInExecute));
            }
        }

        public ICommand ToSignUpCommand
        {
            get
            {
                return _signUpCommand ?? (_signUpCommand = new RelayCommand<object>(SignUpImplementation));
            }
        }

        public ICommand CloseCommand
        {
            get
            {
                return _closeCommand ?? (_closeCommand = new RelayCommand<object>(CloseImplementation));
            }
        }

        #endregion
        #endregion
        private bool CanSignInExecute(object obj)
        {
            return !String.IsNullOrWhiteSpace(_email) && !String.IsNullOrWhiteSpace(_password);
        }

        private async void SignInImplementation(object obj)
        {
            LoaderManager.Instance.ShowLoader();
            var result = await Task.Run(() =>
            {
                Thread.Sleep(1000);
                User currentUser;
                try
                {
                    currentUser = StationManager.Client.GetUserByEmail(_email);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Sign In failed for user {_email}. Reason:{Environment.NewLine}{ex.Message}");
                    return false;
                }

                if (currentUser == null)
                {
                    MessageBox.Show(
                        $"Sign In failed for user {_email}. Reason:{Environment.NewLine} User does not exist.");
                    return false;
                }
                /* if (!currentUser.CheckPassword(_password))
                {
                   MessageBox.Show($"Sign In failed for user {_email}. Reason:{Environment.NewLine} Wrong Password.");
                   return false;
                } */
                StationManager.CurrentUser = currentUser;
                StationManager.CurrentLocalUser = new UserLocal(_email, _password);
                MessageBox.Show($"Sign In successful for user {_email}.");
                return true;
            });

            Email = "";
            Password = "";
            LoaderManager.Instance.HideLoader();
            if (result)
                NavigationManager.Instance.Navigate(ViewType.Main);
        }

        private void SignUpImplementation(object obj)
        {
            Email = "";
            Password = "";
            NavigationManager.Instance.Navigate(ViewType.SignUp);
        }

        private void CloseImplementation(object obj)
        {
            Email = "";
            Password = "";
            StationManager.CloseApp();
        }

    }
}
