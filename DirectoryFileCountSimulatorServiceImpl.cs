using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using DirectoryFileCount.DBModels;
using DirectoryFileCount.EntityFrameworkDBProvider;
using DirectoryFileCount.Server.DirectoryFileCountSimulatorServerInterface;

namespace DirectoryFileCount.Server.DirectoryFileCountSimulatorServerImplementation
{
    public class DirectoryFileCountSimulatorImpl : IDirectoryFileCountSimulator
    {
        public void AddUser(User user)
        {
            using (var context = new DirectoryFileCountDBContext())
            {
                context.Users.Add(user);
                context.SaveChanges();
            }
        }

        public IEnumerable<User> GetAllUsers()
        {
            using (var context = new DirectoryFileCountDBContext())
            {
                return context.Users.Include(u => u.Requests).ToList();
            }
        }

        public bool UserExists(string email)
        {
            using (var context = new DirectoryFileCountDBContext())
            {
                return context.Users.Any(u => u.Email == email);
            }
        }

        public User GetUserByEmail(string email)
        {
            using (var context = new DirectoryFileCountDBContext())
            {
                return context.Users.Include(u => u.Requests).FirstOrDefault(u => u.Email == email);
            }
        }

        public User GetUserByGuid(Guid guid)
        {
            using (var context = new DirectoryFileCountDBContext())
            {
                return context.Users.Include(u => u.Requests).FirstOrDefault(u => u.Guid == guid);
            }
        }

        /* public static void AddRequest(Request request)
        {
            using (var context = new DirectoryFileCountDBContext())
            {
                request.DeleteDatabaseValues();
                context.Requests.Add(request);
                context.SaveChanges();
            }
        } */

       /* public static void SaveRequest(Request request)
        {
            using (var context = new DirectoryFileCountDBContext())
            {
                context.Entry(request).State = EntityState.Modified;
                context.SaveChanges();
            }
        } */

       /* public static void DeleteRequest(Request selectedRequest)
        {
            using (var context = new DirectoryFileCountDBContext())
            {
                selectedRequest.DeleteDatabaseValues();
                context.Requests.Attach(selectedRequest);
                context.Requests.Remove(selectedRequest);
                context.SaveChanges();
            }
        }*/
    }
}
