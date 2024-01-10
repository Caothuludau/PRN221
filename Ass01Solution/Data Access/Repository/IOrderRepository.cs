using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IOrderRepository
    {

        IEnumerable<Order> GetOrders();

        Order GetOrderByID(int OrderId);

        void InsertOrder(Order Order);

        void DeleteOrder(Order Order);

        void UpdateOrder(Order Order);

    }
}
