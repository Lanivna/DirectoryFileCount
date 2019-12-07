using System;
using System.IO;
using System.Windows;
using WinForms = System.Windows.Forms;
using DirectoryFileCount.ViewModels;

namespace DirectoryFileCount
{
    public partial class UserRequestView
    {
        public UserRequestView()
        {
            InitializeComponent();
            DataContext = new UserRequestViewModel();
        }

        //TO DO - change logic to ViewModel
        private void btnSelectFolderClick(object sender, RoutedEventArgs e)
        {
            WinForms.FolderBrowserDialog folderDialog = new WinForms.FolderBrowserDialog();
            folderDialog.ShowNewFolderButton = false;
            folderDialog.SelectedPath = System.AppDomain.CurrentDomain.BaseDirectory;
            WinForms.DialogResult result = folderDialog.ShowDialog();

            if (result == WinForms.DialogResult.OK)
            {
                //Select folder
                //Select path
                String sPath = folderDialog.SelectedPath;
                tbxFolder.Text = sPath;

                //Folder
                DirectoryInfo folder = new DirectoryInfo(sPath);
                if (folder.Exists)
                {
                    //Files
                    foreach (FileInfo fileInfo in folder.GetFiles())
                    {
                        String sDate = fileInfo.CreationTime.ToString("yyyy-MM-dd");
                        //Debug.WriteLine("#Debug: File: " + fileInfo.Name + "Date: " + sDate);
                        //TO DO: count the size and amount of files + subfolders and show them in textblock of RequestWindow
                    }
                }
            }


        }

        private void btnShowHistory(object sender, RoutedEventArgs e)
        {

        }
    }
}
