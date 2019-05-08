using System;
using System.Collections.Generic;
using tea.Models;

namespace tea.DataAccess.Interface
{
    public interface ICartDao
    {
        bool CreateCart(Cart cart);

        IEnumerable<Cart> GetCarts(int user_id);

        Cart GetCartByID(int id);

        bool DeleteCartByID(int id);
    }
}
