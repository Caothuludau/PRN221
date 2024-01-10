using BusinessObject;
using DataAccess;
using DataAccess.Repository;
using System;
using System.Collections.Generic;

public class OrderRepository : IOrderRepository
    {
        public Order GetOrderByID(int OrderId) => OrderDAO.Instance.GetOrderByID(OrderId);
        public IEnumerable<Order> GetOrders() => OrderDAO.Instance.GetOrderList();

        public void InsertOrder(Order Order) => OrderDAO.Instance.AddNew(Order);

        public void DeleteOrder(Order Order) => OrderDAO.Instance.Remove(Order);

        public void UpdateOrder(Order Order) => OrderDAO.Instance.Update(Order);
    }
}
