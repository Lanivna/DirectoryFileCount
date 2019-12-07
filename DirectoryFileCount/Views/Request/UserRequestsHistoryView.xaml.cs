using DirectoryFileCount.ViewModels;

namespace DirectoryFileCount
{
    /// <summary>
    /// Interaction logic for UserRequestsHistoryWindow.xaml
    /// </summary>
    public partial class UserRequestsHistoryView
    {
        public UserRequestsHistoryView()
        {
            InitializeComponent();
            DataContext = new UserRequestHistoryViewModel();
        }

    }
}
