using System;
using System.Collections.Generic;
using UserDB;

namespace ViewCustomers.DAL
{
    public interface IUserRepository : IDisposable
    {
        IEnumerable<User> GetUser();
        User GetUserByID(int userId);
        void InsertUser(User user);
        void DeleteUser(int UserID);
        void UpdateUser(User user);
        void Save();
    }
}