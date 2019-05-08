using System;
using System.Collections.Generic;
using tea.Models;

namespace tea.DataAccess.Interface
{
    public interface IUserDao
    {
        bool CreateUser(User user);

        IEnumerable<User> GetUsers();

        User GetUserByID(int id);
        
        User GetUserByName(string name);
        bool UpdateUser(User user);

        bool UpdateNameByID(int id, string name);

        bool DeleteUserByID(int id);
    }
}
