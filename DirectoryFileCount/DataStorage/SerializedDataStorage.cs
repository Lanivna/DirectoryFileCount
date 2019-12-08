using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                //_user = null;
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
