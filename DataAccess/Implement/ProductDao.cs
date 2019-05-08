using System.Collections.Generic;
using System.Linq;
using tea.DataAccess.Base;
using tea.DataAccess.Interface;
using tea.Models;

namespace tea.DataAccess.Interface
{
    public class ProductDao : IProductDao
    {
        public ProductDbContext Context;

        public ProductDao(ProductDbContext context)
        {
            Context = context;
        }

        public bool CreateProduct(Product product)
        {
            Context.Product.Add(product);
            return Context.SaveChanges() > 0;
        }

        public IEnumerable<Product> GetProducts()
        {
            return Context.Product.ToList();
        }

        public Product GetProductByID(int id)
        {
            return Context.Product.SingleOrDefault(s => s.id == id);
        }

        public bool UpdateProduct(Product product)
        {
            Context.Product.Update(product);
            return Context.SaveChanges() > 0;
        }

        public bool UpdateProductStatus(int id, int status)
        {
            var state = false;
            var product = Context.Product.SingleOrDefault(s => s.id == id);

            if (product != null)
            {
                product.status = status;
                state = Context.SaveChanges() > 0;
            }

            return state;
        }

        public bool DeleteProductByID(int id)
        {
            var cart = Context.Product.SingleOrDefault(s => s.id == id);
            Context.Product.Remove(cart);
            return Context.SaveChanges() > 0;
        }
    }
}
