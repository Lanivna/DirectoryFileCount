using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using WinForms = System.Windows.Forms;
using DirectoryFileCount.ViewModels;

namespace DirectoryFileCount
{
    public partial class UserRequestView : UserControl
    {
        public UserRequestView()
        {
            InitializeComponent();
            DataContext = new UserRequestViewModel();
        }

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
                    }
                }
            }

        }

    }
}
