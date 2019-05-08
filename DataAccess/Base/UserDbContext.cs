using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace tea.DataAccess.Base
{
    public class UserDbContext : DbContext
    {
        public UserDbContext (DbContextOptions<UserDbContext> options): base(options)
        {
        }

        public DbSet<tea.Models.User> User { get; set; }
    }
}