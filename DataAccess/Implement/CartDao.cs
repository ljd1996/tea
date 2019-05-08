using System.Collections.Generic;
using System.Linq;
using tea.DataAccess.Base;
using tea.DataAccess.Interface;
using tea.Models;

namespace tea.DataAccess.Interface
{
    public class CartDao : ICartDao
    {
        public CartDbContext Context;

        public CartDao(CartDbContext context)
        {
            Context = context;
        }

        public bool CreateCart(Cart cart)
        {
            Context.Cart.Add(cart);
            return Context.SaveChanges() > 0;
        }

        public IEnumerable<Cart> GetCarts(int user_id)
        {
            return Context.Cart.Where(s => s.buy_id == user_id).ToList();
        }

        public Cart GetCartByID(int id)
        {
            return Context.Cart.SingleOrDefault(s => s.id == id);
        }

        public bool DeleteCartByID(int id)
        {
            var cart = Context.Cart.SingleOrDefault(s => s.id == id);
            Context.Cart.Remove(cart);
            return Context.SaveChanges() > 0;
        }
    }
}
