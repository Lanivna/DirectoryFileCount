using System;
using System.Windows.Forms;
using DirectoryFileCount.DataStorage;
using DirectoryFileCount.DBModels;
using DirectoryFileCount.Models;

namespace DirectoryFileCount
{
    internal static class StationManager
    {
        public static event Action StopThreads;

    //  private static DirectoryFileCountServiceClient _client;

        private static IDataStorage _dataStorage;

        internal static IDataStorage DataStorage
        {
            get { return _dataStorage; }
        }

        internal static User CurrentUser { get; set; }

        internal static UserLocal CurrentLocalUser { get; set; }

      /*  public static DirectoryFileCountServiceClient Client
        {
            get
            {
                return _client;
            }
            set
            {
                _client = value;
            }
        } */


       /* internal static void Initialize(DirectoryFileCountServiceClient client, IDataStorage dataStorage)
        {
            _client = client;
            _dataStorage = dataStorage;
            CurrentLocalUser = _dataStorage.CurrentUser;
        } */

        internal static void CloseApp()
        {
            StationManager.DataStorage.ChangeUser(CurrentLocalUser);
            StationManager.DataStorage.SaveCurrentUser();
            MessageBox.Show("ShutDown");
            StopThreads?.Invoke();
            Environment.Exit(1);
        }
    }
}
