using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using DirectoryFileCount.DBModels;
using DirectoryFileCount.Navigation;

namespace DirectoryFileCount.Managers
{
    internal class NavigationManager
    {
        private static readonly object Locker = new object();
        private static NavigationManager _instance;

        internal static NavigationManager Instance
        {
            get
            {
                if (_instance != null)
                    return _instance;
                lock (Locker)
                {
                    return _instance ?? (_instance = new NavigationManager());
                }
            }
        }

        private INavigationModel _navigationModel;

        private NavigationManager()
        {

        }

        internal void Initialize(INavigationModel navigationModel)
        {
            _navigationModel = navigationModel;
        }

        internal async void Navigate(ViewType viewType)
        {
            if (viewType == ViewType.SignIn && !string.IsNullOrEmpty(StationManager.CurrentLocalUser.Email))
            {
                LoaderManager.Instance.ShowLoader();
                var result = await Task.Run(() =>
                {
                    Thread.Sleep(1000);
                    User currentUser;
                    try
                    {
                        currentUser = StationManager.Client.GetUserByEmail(StationManager.CurrentLocalUser.Email);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Sign In failed for user {StationManager.CurrentLocalUser.Email}. Reason:{Environment.NewLine}{ex.Message}");
                        return false;
                    }

                    if (currentUser == null)
                    {
                        MessageBox.Show(
                            $"Sign In failed for user {StationManager.CurrentLocalUser.Email}. Reason:{Environment.NewLine}User does not exist.");
                        return false;
                    }
                    //if (!currentUser.CheckPassword(_password))
                    //{
                    //    MessageBox.Show($"Sign In failed for user {_email}. Reason:{Environment.NewLine}Wrong Password.");
                    //    return false;
                    //}
              //      StationManager.CurrentUser = currentUser;
                    MessageBox.Show($"Sign In successful for user {StationManager.CurrentLocalUser.Email}.");
                    return true;
                });
                LoaderManager.Instance.HideLoader();
                if (result)
                    _navigationModel.Navigate(ViewType.Main);

            }
            else
            {
                _navigationModel.Navigate(viewType);
            }
        }

    }
}
