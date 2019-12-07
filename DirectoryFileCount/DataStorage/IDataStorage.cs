using DirectoryFileCount.Models;

namespace DirectoryFileCount.DataStorage
{
    internal interface IDataStorage
    {
        void ChangeUser(UserLocal user);
        void SaveCurrentUser();
        UserLocal CurrentUser { get; }
    }
}
