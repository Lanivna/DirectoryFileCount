using System;

namespace DirectoryFileCount.Models
{
    [Serializable]
    internal class UserLocal
    {
        #region Fields
        private string _email;
        //private string _password;
        #endregion

        #region Properties
        public string Email
        {
            get
            {
                return _email;
            }
            private set
            {
                _email = value;
            }
        }
        //private string Password
        //{
        //    get
        //    {
        //        return _password;
        //    }
        //}
        #endregion

        #region Constructors
        public UserLocal(string email) //, string password
        {
            _email = email;
            //_password = password;
            //SetPassword(password);
        }

        public UserLocal()
        {
            _email = "";
            //_password = "";
            //SetPassword(password);
        }
        #endregion

        //private void SetPassword(string password)
        //{
        //    //TODO Add encryption
        //    _password = password;
        //}
    }
}
