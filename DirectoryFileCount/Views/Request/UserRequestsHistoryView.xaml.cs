using DirectoryFileCount.ViewModels;

namespace DirectoryFileCount
{
    public partial class UserRequestsHistoryView 
    {
        public UserRequestsHistoryView()
        {
            InitializeComponent();
            DataContext = new UserRequestHistoryViewModel();
        }

    }
}
