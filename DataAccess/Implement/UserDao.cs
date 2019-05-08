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

        //插入数据
        public bool CreateUser(User user)
        {
            Context.User.Add(user);
            return Context.SaveChanges() > 0;
        }

        //取全部记录
        public IEnumerable<User> GetUsers()
        {
            return Context.User.ToList();
        }

        //取某id记录
        public User GetUserByID(int id)
        {
            return Context.User.SingleOrDefault(s => s.id == id);
        }

        public User GetUserByName(string name) {
            return Context.User.SingleOrDefault(s => s.name.Equals(name));
        }

        //根据id更新整条记录
        public bool UpdateUser(User user)
        {
            Context.User.Update(user);
            return Context.SaveChanges() > 0;
        }

        //根据id更新名称
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

        //根据id删掉记录
        public bool DeleteUserByID(int id)
        {
            var user = Context.User.SingleOrDefault(s => s.id == id);
            Context.User.Remove(user);
            return Context.SaveChanges() > 0;
        }
    }
}