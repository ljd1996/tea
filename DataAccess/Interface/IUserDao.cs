using System;
using System.Collections.Generic;
using tea.Models;

namespace tea.DataAccess.Interface
{
    public interface IUserDao
    {
        //插入数据
        bool CreateUser(User user);

        //取全部记录
        IEnumerable<User> GetUsers();

        //取某id记录
        User GetUserByID(int id);
        User GetUserByName(string name);
        //根据id更新整条记录
        bool UpdateUser(User user);

        //根据id更新名称
        bool UpdateNameByID(int id, string name);

        //根据id删掉记录
        bool DeleteUserByID(int id);
    }
}
