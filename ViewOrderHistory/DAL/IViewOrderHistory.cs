using System;
using System.Collections.Generic;
using Order_DB;

namespace ViewOrderHistory.DAL
{
    public interface IViewOrderHistoryRepository : IDisposable
    {
        IEnumerable<Order> GetOrder();
        Order GetOrdersByID(int OrderId);
        void InsertOrder(Order order);
        void DeleteOrder(int OrderId);
        void UpdateOrder(Order order);
        void Save();
    }
}