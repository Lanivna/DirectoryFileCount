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
            WindowLogIn secondWindow = new WindowLogIn();
            secondWindow.Show();
        }

        private void Create_Account(object sender, RoutedEventArgs e)
        {
            WindowCreateAccount thirdWindow = new WindowCreateAccount();
            thirdWindow.Show();
        }

        private void CloseCommandHandler(object sender, ExecutedRoutedEventArgs e)
        {
            this.Close();
        }

    }
}
