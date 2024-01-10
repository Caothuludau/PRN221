using BusinessObject;
using Microsoft.EntityFrameworkCore;
using System;
using System.Runtime.ConstrainedExecution;

namespace DataAccess
{
    public class OrderDetailDAO
    {
        //Using Singleton Pattern
        private static OrderDetailDAO? instance = null;
        private static readonly object instanceLock = new object();
        private OrderDetailDAO() { }
        public static OrderDetailDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                        instance = new OrderDetailDAO();
                }
                return instance;
            }
        }

        public IEnumerable<OrderDetail> GetOrderDetailList()
        {
            List<OrderDetail> OrderDetails;
            try
            {
                var fStoreDB = new BusinessObject.FStoreContext();
                OrderDetails = fStoreDB.OrderDetails.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return OrderDetails;
        }
        public OrderDetail GetOrderDetailByID(int OrderID)
        {
            OrderDetail? OrderDetail = null;
            try
            {
                var fStoreDB = new FStoreContext();
                OrderDetail = fStoreDB.OrderDetails.SingleOrDefault(OrderDetail => OrderDetail.OrderId == OrderID);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return OrderDetail;
        }
        public void AddNew(OrderDetail OrderDetail)
        {
            try
            {
                OrderDetail _OrderDetail = GetOrderDetailByID(OrderDetail.OrderId);
                if (_OrderDetail == null)
                {
                    var fStoreDB = new FStoreContext();
                    fStoreDB.OrderDetails.Add(OrderDetail);
                    fStoreDB.SaveChanges();
                }
                else
                {
                    throw new Exception("The OrderDetail is already exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }
        public void Update(OrderDetail OrderDetail)
        {
            try
            {
                OrderDetail c = GetOrderDetailByID(OrderDetail.OrderId);
                if (c != null)
                {
                    var fStoreDB = new FStoreContext();
                    fStoreDB.Entry<OrderDetail>(OrderDetail).State = EntityState.Modified;
                    fStoreDB.SaveChanges();
                }
                else
                {
                    throw new Exception("The OrderDetail does not already exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Remove(OrderDetail OrderDetail)
        {
            try
            {
                OrderDetail _OrderDetail = GetOrderDetailByID(OrderDetail.OrderId);
                if (_OrderDetail != null)
                {
                    var fStoreDB = new FStoreContext();
                    fStoreDB.OrderDetails.Remove(OrderDetail);
                    fStoreDB.SaveChanges();
                }

                else
                {
                    throw new Exception("The OrderDetail does not already exist");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        } // end Remove
    }//end class
}
