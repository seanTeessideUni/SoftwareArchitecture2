using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using Order_DB;
using System.Data.Entity;
using ViewOrderHistory.DAL;

namespace ViewOrderHistory.DAL
{
    public class ViewOrderHistoryRepository : IViewOrderHistoryRepository, IDisposable
    {
        private OrderContext context;

        public ViewOrderHistoryRepository(OrderContext context)
        {
            this.context = context;
        }

        public IEnumerable<Order> GetOrder()
        {
            return context.Orders.ToList();
        }

        public Order GetOrdersByID(int id)
        {
            return context.Orders.Find(id);
        }

        public void InsertOrder(Order order)
        {
            context.Orders.Add(order);
        }

        public void DeleteOrder(int OrderId)
        {
            Order order = context.Orders.Find(OrderId);
            context.Orders.Remove(order);
        }

        public void UpdateOrder(Order order)
        {
            context.Entry(order).State = EntityState.Modified;
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}