using System;
using System.Collections.Generic;
using tea.Models;

namespace tea.DataAccess.Interface
{
    public interface IProductDao
    {
        bool CreateProduct(Product product);

        IEnumerable<Product> GetProducts();

        Product GetProductByID(int id);

        bool UpdateProduct(Product product);

        bool UpdateProductStatus(int id, int status);

        bool DeleteProductByID(int id);
    }
}
