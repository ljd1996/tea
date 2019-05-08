using System.Collections.Generic;
using System.Linq;
using tea.DataAccess.Base;
using tea.DataAccess.Interface;
using tea.Models;

namespace tea.DataAccess.Implement
{
    public class UserDao: IUserDao
    {
        public UserDbContext Context;

        public UserDao(UserDbContext context)
        {
            Context = context;
        }

        public bool CreateUser(User user)
        {
            Context.User.Add(user);
            return Context.SaveChanges() > 0;
        }

        public IEnumerable<User> GetUsers()
        {
            return Context.User.ToList();
        }

        public User GetUserByID(int id)
        {
            return Context.User.SingleOrDefault(s => s.id == id);
        }

        public User GetUserByName(string name) {
            return Context.User.SingleOrDefault(s => s.name.Equals(name));
        }

        public bool UpdateUser(User user)
        {
            Context.User.Update(user);
            return Context.SaveChanges() > 0;
        }

        public bool UpdateNameByID(int id, string name)
        {
            var state = false;
            var user = Context.User.SingleOrDefault(s => s.id == id);

            if (user != null)
            {
                user.name = name;
                state = Context.SaveChanges() > 0;
            }

            return state;
        }

        public bool DeleteUserByID(int id)
        {
            var user = Context.User.SingleOrDefault(s => s.id == id);
            Context.User.Remove(user);
            return Context.SaveChanges() > 0;
        }
    }
}