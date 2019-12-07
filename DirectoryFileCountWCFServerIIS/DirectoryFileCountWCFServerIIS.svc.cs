using System;
using System.Collections.Generic;
using DirectoryFileCount.DBModels;
using DirectoryFileCount.Server.DirectoryFileCountSimulatorServerImplementation;
using DirectoryFileCount.Server.DirectoryFileCountSimulatorServerInterface;

namespace DirectoryFileCount.Server.DirectoryFileCountWCFServerIIS
{
    public class DirectoryFileCountWCFServerIIS : IDirectoryFileCountSimulator
    {
        private DirectoryFileCountSimulatorImpl service = new DirectoryFileCountSimulatorImpl();

        public void AddRequest(Request request)
        {
            service.AddRequest(request);
        }

        public void AddUser(User user)
        {
            service.AddUser(user);
        }

        public IEnumerable<User> GetAllUsers()
        {
            return service.GetAllUsers();
        }

        public bool UserExists(string email)
        {
            return service.UserExists(email);
        }

        public User GetUserByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public User GetUserByGuid(Guid guid)
        {
            throw new NotImplementedException();
        }
    }
}