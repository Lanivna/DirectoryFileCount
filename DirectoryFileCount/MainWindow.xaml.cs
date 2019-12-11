using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using DirectoryFileCount.DataStorage;
using DirectoryFileCount.DirectoryFileCountWCFServer;
using DirectoryFileCount.Managers;
using DirectoryFileCount.Navigation;
using DirectoryFileCount.ViewModels;

namespace DirectoryFileCount
{
    public partial class MainWindow : UserControl, IContentOwner, INavigatable
    {
        public ContentControl ContentControl
         {
             get { return _contentControl; }
         }

         public MainWindow()
         {
             InitializeComponent();
             DataContext = new MainWindowViewModel();
             InitializeApplication();
         }

         private void InitializeApplication()
         {
             DirectoryFileCountSimulatorClient serverClient = new DirectoryFileCountSimulatorClient("BasicHttpBinding_IDirectoryFileCountSimulator");

             StationManager.Initialize(serverClient, new SerializedDataStorage());
             NavigationManager.Instance.Initialize(new InitializationNavigationModel(this));
         }

     /*    protected override void OnClosing(CancelEventArgs e)
         {
             base.OnClosing(e);
             StationManager.CloseApp();
         }*/
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            SignInView loginWindow = new SignInView();
            stkLogIn.Children.Add(loginWindow);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            SignUpView signupWindow = new SignUpView();
            stkLogIn.Children.Add(signupWindow);
        }


        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

    }
}
