using System;
using System.Collections.Generic;
using DirectoryFileCount.DBModels;
using System.ServiceModel;

namespace DirectoryFileCount.Server.DirectoryFileCountSimulatorServerInterface
{
    [ServiceContract]
    public interface IDirectoryFileCountSimulator
    {
        [OperationContract]
        IEnumerable<User> GetAllUsers();

        [OperationContract]
        void AddUser(User user);

        [OperationContract]
        bool UserExists(string email);

        [OperationContract]
        User GetUserByEmail(string email);

        [OperationContract]
        User GetUserByGuid(Guid guid);

        [OperationContract]
        void AddRequest(Request request);
    }
}