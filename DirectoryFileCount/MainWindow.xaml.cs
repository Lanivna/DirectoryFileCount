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
    public partial class MainWindow : Window, IContentOwner, INavigatable
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

         protected override void OnClosing(CancelEventArgs e)
         {
             base.OnClosing(e);
             StationManager.CloseApp();
         }

        /*     private void Log_In(object sender, RoutedEventArgs e)
             {
                 SignInView secondWindow = new SignInView();
                 //secondWindow.Show();
             }

             private void Create_Account(object sender, RoutedEventArgs e)
             {
                 SignUpView thirdWindow = new SignUpView();
                // thirdWindow.Show();
             }

             private void CloseCommandHandler(object sender, ExecutedRoutedEventArgs e)
             {
                 this.Close();
             } */
    }
}
