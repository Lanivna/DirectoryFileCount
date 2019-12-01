using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Win32;
using System.IO;
using System.Diagnostics;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Reflection;

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
    }
}
