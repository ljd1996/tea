using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace tea.DataAccess.Base
{
    public class CartDbContext : DbContext
    {
        public CartDbContext (DbContextOptions<CartDbContext> options): base(options)
        {
        }

        public DbSet<tea.Models.Cart> Cart { get; set; }
    }
}