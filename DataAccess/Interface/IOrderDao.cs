using System;
using System.Collections.Generic;
using tea.Models;

namespace tea.DataAccess.Interface
{
    public interface IOrderDao
    {
        bool CreateOrder(Orderlist order);

        IEnumerable<Orderlist> GetOrders(int user_id);

        Orderlist GetOrderByID(int id);

        bool UpdateOrderStatus(int id, int status);

        bool DeleteOrderByID(int id);
    }
}
