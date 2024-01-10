using BusinessObject;
using Microsoft.EntityFrameworkCore;
using System;
using System.Runtime.ConstrainedExecution;

namespace DataAccess
{
    public class OrderDAO
    {
        //Using Singleton Pattern
        private static OrderDAO? instance = null;
        private static readonly object instanceLock = new object();
        private OrderDAO() { }
        public static OrderDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                        instance = new OrderDAO();
                }
                return instance;
            }
        }

        public IEnumerable<Order> GetOrderList()
        {
            List<Order> Orders;
            try
            {
                var fStoreDB = new BusinessObject.FStoreContext();
                Orders = fStoreDB.Orders.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return Orders;
        }
        public Order GetOrderByID(int OrderID)
        {
            Order? Order = null;
            try
            {
                var fStoreDB = new FStoreContext();
                Order = fStoreDB.Orders.SingleOrDefault(Order => Order.OrderId == OrderID);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return Order;
        }
        public void AddNew(Order Order)
        {
            try
            {
                Order _Order = GetOrderByID(Order.OrderId);
                if (_Order == null)
                {
                    var fStoreDB = new FStoreContext();
                    fStoreDB.Orders.Add(Order);
                    fStoreDB.SaveChanges();
                }
                else
                {
                    throw new Exception("The Order is already exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }
        public void Update(Order Order)
        {
            try
            {
                Order c = GetOrderByID(Order.OrderId);
                if (c != null)
                {
                    var fStoreDB = new FStoreContext();
                    fStoreDB.Entry<Order>(Order).State = EntityState.Modified;
                    fStoreDB.SaveChanges();
                }
                else
                {
                    throw new Exception("The Order does not already exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Remove(Order Order)
        {
            try
            {
                Order _Order = GetOrderByID(Order.OrderId);
                if (_Order != null)
                {
                    var fStoreDB = new FStoreContext();
                    fStoreDB.Orders.Remove(Order);
                    fStoreDB.SaveChanges();
                }

                else
                {
                    throw new Exception("The Order does not already exist");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        } // end Remove
    }//end class
}
