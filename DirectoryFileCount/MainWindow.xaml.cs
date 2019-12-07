using System.Windows;
using System.Windows.Input;

namespace DirectoryFileCount
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Log_In(object sender, RoutedEventArgs e)
        {
            SignInView secondWindow = new SignInView();
            secondWindow.Show();
        }

        private void Create_Account(object sender, RoutedEventArgs e)
        {
            SignUpView thirdWindow = new SignUpView();
            thirdWindow.Show();
        }

        private void CloseCommandHandler(object sender, ExecutedRoutedEventArgs e)
        {
            this.Close();
        }

    }
}
