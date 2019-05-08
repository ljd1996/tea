using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace tea.DataAccess.Base
{
    public class OrderDbContext : DbContext
    {
        public OrderDbContext (DbContextOptions<OrderDbContext> options): base(options)
        {
        }

        public DbSet<tea.Models.Orderlist> Orderlist { get; set; }
    }
}