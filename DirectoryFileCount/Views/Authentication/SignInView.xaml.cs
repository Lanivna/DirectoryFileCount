using System.Windows;
using DirectoryFileCount.ViewModels;

namespace DirectoryFileCount
{
    public partial class SignInView : Window
    {
        internal SignInView()
        {
            InitializeComponent();
            DataContext = new SignInViewModel();
        }
    }
}