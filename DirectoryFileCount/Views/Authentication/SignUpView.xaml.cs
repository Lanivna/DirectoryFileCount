using System.Windows;
using DirectoryFileCount.ViewModels;

namespace DirectoryFileCount
{
    public partial class SignUpView : Window
    {
        internal SignUpView()
        {
            InitializeComponent();
            DataContext = new SignUpViewModel();
        }
    }
}
