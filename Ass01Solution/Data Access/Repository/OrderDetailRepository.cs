using BusinessObject;
using DataAccess;
using DataAccess.Repository;
using System;
using System.Collections.Generic;

public class OrderDetailRepository : IOrderDetailRepository
    {
        public OrderDetail GetOrderDetailByID(int OrderDetailId) => OrderDetailDAO.Instance.GetOrderDetailByID(OrderDetailId);
        public IEnumerable<OrderDetail> GetOrderDetails() => OrderDetailDAO.Instance.GetOrderDetailList();

        public void InsertOrderDetail(OrderDetail OrderDetail) => OrderDetailDAO.Instance.AddNew(OrderDetail);

        public void DeleteOrderDetail(OrderDetail OrderDetail) => OrderDetailDAO.Instance.Remove(OrderDetail);

        public void UpdateOrderDetail(OrderDetail OrderDetail) => OrderDetailDAO.Instance.Update(OrderDetail);
    }
}
