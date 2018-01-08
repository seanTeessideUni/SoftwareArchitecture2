using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using UserDB;
using System.Data.Entity;

namespace ViewCustomers.DAL
{
    public class UserRepository : IUserRepository, IDisposable
    {
        private UserContext context;

        public UserRepository(UserContext context)
        {
            this.context = context;
        }

        public IEnumerable<User> GetUser()
        {
            return context.Users.ToList();
        }

        public User GetUserByID(int id)
        {
            return context.Users.Find(id);
        }

        public void InsertUser(User user)
        {
           
            context.Users.Add(user);
        }

        public void DeleteUser(int userID)
        {
            User user = context.Users.Find(userID);
            context.Users.Remove(user);
        }

        public void UpdateUser(User user)
        {
            context.Entry(user).State = EntityState.Modified;
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}