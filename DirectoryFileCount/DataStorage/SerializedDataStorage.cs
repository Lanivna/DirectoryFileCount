using System.IO;
using DirectoryFileCount.Managers;
using DirectoryFileCount.Models;

namespace DirectoryFileCount.DataStorage
{
    internal class SerializedDataStorage : IDataStorage
    {
        private UserLocal _user;

        internal SerializedDataStorage()
        {
            try
            {
                _user = SerializationManager.Deserialize<UserLocal>(FileFolderHelper.StorageFilePath);
            }
            catch (FileNotFoundException)
            {
                _user = new UserLocal();
            }
        }

        public void ChangeUser(UserLocal user)
        {
            _user = user;
        }

        public UserLocal CurrentUser
        {
            get { return _user; }
        }

        public void SaveCurrentUser()
        {
            SerializationManager.Serialize(_user, FileFolderHelper.StorageFilePath);
        }

    }
}
