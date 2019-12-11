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

        private void Button_GoBack(object sender, System.Windows.RoutedEventArgs e)
        {
            (this.Parent as Panel).Children.Remove(this);
        }

        private void Button_Click_NewUser(object sender, System.Windows.RoutedEventArgs e)
        {
            //TODO: go to profile page
        }
    }
}
