using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace tea.DataAccess.Base
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext (DbContextOptions<ProductDbContext> options): base(options)
        {
        }

        public DbSet<tea.Models.Product> Product { get; set; }
    }
}