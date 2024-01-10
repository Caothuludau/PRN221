using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IOrderDetailRepository
    {

        IEnumerable<OrderDetail> GetOrderDetails();

        OrderDetail GetOrderDetailByID(int OrderDetailId);

        void InsertOrderDetail(OrderDetail OrderDetail);

        void DeleteOrderDetail(OrderDetail OrderDetail);

        void UpdateOrderDetail(OrderDetail OrderDetail);

    }
}
