using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using DirectoryFileCount.Managers;
using DirectoryFileCount.Navigation;

namespace DirectoryFileCount.ViewModels
{
    class UserRequestViewModel : BasicViewModel, INotifyPropertyChanged
    {
        private string _pathToFolder;
        private int _quantityOfFiles;
        private int _quantityOfSubFolders;
        private double _totalFilesSize;

        private ICommand _requestInformationCommand;
        private ICommand _viewHistoryCommand;

        public string PathToFolder
        {
            get { return _pathToFolder; }
            set
            {
                _pathToFolder = value;
                OnPropertyChanged();
            }
        }

        public int QuantityOfFiles
        {
            get { return _quantityOfFiles; }
            set
            {
                _quantityOfFiles = value;
                OnPropertyChanged();
            }
        }

        public int QuantityOfSubFolders
        {
            get { return _quantityOfSubFolders; }
            set
            {
                _quantityOfSubFolders = value;
                OnPropertyChanged();
            }
        }

        public double TotalFilesSize
        {
            get { return _totalFilesSize; }
            set
            {
                _totalFilesSize = value;
                OnPropertyChanged();
            }
        }

        public ICommand RequestInformationCommand
        {
            get
            {
                return _requestInformationCommand ?? (_requestInformationCommand =
                           new RelayCommand<object>(RequestInformationImplementation));
            }
        }

        public ICommand ViewHistoryCommand
        {
            get { return _viewHistoryCommand ?? (_viewHistoryCommand = new RelayCommand<object>(ViewHistoryImplementation)); }
        }

        private void ViewHistoryImplementation(object obj)
        {
            NavigationManager.Instance.Navigate(ViewType.History);
        }
        private async void RequestInformationImplementation(object obj)
        {
            LoaderManager.Instance.ShowLoader();
            var result = await Task.Run(() =>
            {
                try
                {
                    QuantityOfFiles = CountFiles();
                    QuantityOfSubFolders = CountSubFolders();
                    TotalFilesSize = CountTotalFilesSize();
                    var request = new DBModels.Request(PathToFolder, QuantityOfFiles, QuantityOfSubFolders, TotalFilesSize, DateTime.Now)
                    {
                        UserGuid = StationManager.CurrentUser.Guid
                    };
                    StationManager.CurrentUser.Requests.Add(request);
                    StationManager.Client.AddRequest(request);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Request failed. Reason:{Environment.NewLine} {ex.Message}");
                    return false;
                }
                return true;
            });
            LoaderManager.Instance.HideLoader();
        }

        private int CountFiles()
        {
            int fileCount = Directory.EnumerateFiles(PathToFolder, "*.*", SearchOption.AllDirectories).Count();
            int numberOfFiles = fileCount;
            return numberOfFiles;
        }

        private int CountSubFolders()
        {
            int subCount = Directory.EnumerateDirectories(PathToFolder, "*", SearchOption.AllDirectories).Count();
            int numberOfSubFolders = subCount; 
            return numberOfSubFolders;
        }

        private double CountTotalFilesSize()
        {
            long length = Directory.GetFiles(PathToFolder, "*", SearchOption.AllDirectories).Sum(t => (new FileInfo(t).Length));
            long totalSize = length;
            return totalSize;
        }
     
    }
}
