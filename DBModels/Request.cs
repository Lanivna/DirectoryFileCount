using System;
using System.Runtime.Serialization;

namespace DirectoryFileCount.DBModels
{
   
    [DataContract(IsReference = true)]
    public class Request
    {
        [DataMember]
        private Guid _guid;
        [DataMember]
        private string _pathToFolder;
        [DataMember]
        private int _quantityOfFiles;
        [DataMember]
        private int _quantityOfSubFolders;
        [DataMember]
        private DateTime _dateOfRequest;
        [DataMember]
        private Guid _userGuid;
        [DataMember]
        private User _user;


        public Guid Guid
        {
            get => _guid;
            set => _guid = value;
        }

        public string PathToFolder
        {
            get => _pathToFolder;
            set => _pathToFolder = value;
        }

        public int QuantityOfFiles
        {
            get => _quantityOfFiles;
            set => _quantityOfFiles = value;
        }

        public int QuantityOfSubFolders
        {
            get => _quantityOfSubFolders;
            set => _quantityOfSubFolders = value;
        }

        public DateTime DateOfRequest
        {
            get => _dateOfRequest;
            set => _dateOfRequest = value;
        }

        public virtual User User
        {
            get => _user;
            set => _user = value;
        }

        public Guid UserGuid
        {
            get => _userGuid;
            set => _userGuid = value;
        }

        public Request(string pathToFolder) : this()
        {
            _guid = Guid.NewGuid();
            _pathToFolder = pathToFolder;
            _dateOfRequest = DateTime.Today;
        }

        public Request()
        {

        }
    }
}