using System.Collections.Generic;
using System.Linq;
using tea.DataAccess.Base;
using tea.DataAccess.Interface;
using tea.Models;

namespace tea.DataAccess.Interface
{
    public class OrderDao : IOrderDao
    {
        public OrderDbContext Context;

        public OrderDao(OrderDbContext context)
        {
            Context = context;
        }

        public bool CreateOrder(Orderlist order)
        {
            Context.Orderlist.Add(order);
            return Context.SaveChanges() > 0;
        }

        public IEnumerable<Orderlist> GetOrders(int user_id)
        {
            return Context.Orderlist.Where(s => s.buy_id == user_id).ToList();
        }

        public Orderlist GetOrderByID(int id)
        {
            return Context.Orderlist.SingleOrDefault(s => s.id == id);
        }

        public bool UpdateOrderStatus(int id, int status)
        {
            var state = false;
            var order = Context.Orderlist.SingleOrDefault(s => s.id == id);

            if (order != null)
            {
                order.status = status;
                state = Context.SaveChanges() > 0;
            }

            return state;
        }

        public bool DeleteOrderByID(int id)
        {
            var order = Context.Orderlist.SingleOrDefault(s => s.id == id);
            Context.Orderlist.Remove(order);
            return Context.SaveChanges() > 0;
        }
    }
}
