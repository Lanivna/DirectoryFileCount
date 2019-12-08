using System;
using System.ComponentModel.DataAnnotations;
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

    internal class SignUpViewModel : BaseViewModel
    {
        #region Fields
        private string _password;
        private string _firstName;
        private string _lastName;
        private string _email;

        #region Commands
        private ICommand _signUpCommand;
        private ICommand _toSignInCommand;
        private ICommand _closeCommand;
        #endregion
        #endregion

        #region Properties
        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged();
            }
        }
        public string FirstName
        {
            get { return _firstName; }
            set
            {
                _firstName = value;
                OnPropertyChanged();
            }
        }
        public string LastName
        {
            get { return _lastName; }
            set
            {
                _lastName = value;
                OnPropertyChanged();
            }
        }
        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                OnPropertyChanged();
            }
        }
        #region Commands

        public ICommand SignUpCommand
        {
            get
            {
                return _signUpCommand ?? (_signUpCommand =
                           new RelayCommand<object>(SignUpImplementation, CanSignUpExecute));
            }
        }

        public ICommand ToSignInCommand
        {
            get
            {
                return _toSignInCommand ?? (_toSignInCommand = new RelayCommand<object>(ToSignInImplementation));
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
        private bool CanSignUpExecute(object obj)
        {
            return !String.IsNullOrEmpty(_password) &&
                   !String.IsNullOrEmpty(_firstName) &&
                   !String.IsNullOrEmpty(_lastName) &&
                   !String.IsNullOrEmpty(_email);
        }

        private async void SignUpImplementation(object obj)
        {
            LoaderManager.Instance.ShowLoader();
            var result = await Task.Run(() =>
            {
                try
                {
                    Thread.Sleep(1000);
                    if (!new EmailAddressAttribute().IsValid(_email))
                    {
                        MessageBox.Show($"Sign Up failed for user {_email}. Reason:{Environment.NewLine} Email {_email} is not valid.");
                        return false;
                    }
                    if (StationManager.Client.UserExists(_email))
                    {
                        MessageBox.Show($"Sign Up failed for user {_email}. Reason:{Environment.NewLine} User with such email already exists.");
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Sign Up failed for user {_email}. Reason:{Environment.NewLine} {ex.Message}");
                    return false;
                }
                try
                {
                    var user = new User(_firstName, _lastName, _email, _password);
                    StationManager.Client.AddUser(user);
                    StationManager.CurrentUser = user;
                    StationManager.CurrentLocalUser = new UserLocal(_email, _password);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Sign Up failed for user {_email}. Reason:{Environment.NewLine} {ex.Message}");
                    return false;
                }
                MessageBox.Show($"User {_email} was successfully created.");
                return true;
            });
            LoaderManager.Instance.HideLoader();
            if (result)
                NavigationManager.Instance.Navigate(ViewType.Main);
        }

        private void ToSignInImplementation(object obj)
        {
            NavigationManager.Instance.Navigate(ViewType.SignIn);
        }

        private void CloseImplementation(object obj)
        {
            StationManager.CloseApp();
        }

    }
}
