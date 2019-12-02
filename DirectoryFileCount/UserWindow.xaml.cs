using System;
using System.Windows;
using System.IO;

using WinForms = System.Windows.Forms;

namespace DirectoryFileCount
{
    /// <summary>
    /// Interaction logic for UserWindow.xaml
    /// </summary>
    public partial class UserWindow : Window
    {
        public UserWindow()
        {
            InitializeComponent();
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
                        //TO DO: count the size and amount of files + subfolders and show them in textblock of UserWindow
                    }
                }
            }


        }

        private void btnShowHistory(object sender, RoutedEventArgs e)
        {

        }
    }
}
