using System;

namespace DirectoryFileCount.Models
{
    [Serializable]
    internal class UserLocal
    {
        #region Fields
        private string _email;
        private string _password;
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
        public string Password
        {
            get
            {
                return _password;
            }
        }
        #endregion

        #region Constructors
        public UserLocal(string email, string password)
        {
            _email = email;
            SetPassword(password);
        }

        public UserLocal()
        {
            _email = "";
            _password = "";
        }
        #endregion

        private void SetPassword(string password)
        {
            byte[] data = System.Text.Encoding.ASCII.GetBytes(password);
            data = new System.Security.Cryptography.SHA256Managed().ComputeHash(data);
            var hash = System.Text.Encoding.ASCII.GetString(data);
            _password = hash;
        }
    }
}
