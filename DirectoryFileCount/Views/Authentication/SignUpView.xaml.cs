using System.Windows.Controls;
using DirectoryFileCount.Navigation;
using DirectoryFileCount.ViewModels;

namespace DirectoryFileCount
{
    public partial class SignUpView : UserControl, INavigatable
    {
        internal SignUpView()
        {
            InitializeComponent();
            DataContext = new SignUpViewModel();
        }
    }
}
