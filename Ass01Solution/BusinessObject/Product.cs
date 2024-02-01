using System;
using System.Collections.Generic;

namespace BusinessObject
{
    public partial class Product
    {
        public Product()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }
        public Product(string prdName, string weight, decimal unitPrice, int unitsInStock, int categoryId)
        {
            CategoryId = categoryId;
            ProductName = prdName;
            Weight = weight;
            UnitPrice = unitPrice;
            UnitsInStock = unitsInStock;

            OrderDetails = new HashSet<OrderDetail>();
        }

        public Product(int prodId, string prdName, string weight, decimal unitPrice, int unitsInStock, int categoryId)
        {
            ProductId = prodId;
            CategoryId = categoryId;
            ProductName = prdName;
            Weight = weight;
            UnitPrice = unitPrice;
            UnitsInStock = unitsInStock;

            OrderDetails = new HashSet<OrderDetail>();
        }

        public int CategoryId { get; set; }
        public string ProductName { get; set; } = null!;
        public string Weight { get; set; } = null!;
        public decimal UnitPrice { get; set; }
        public int UnitsInStock { get; set; }
        public int ProductId { get; set; }

        public virtual Category Category { get; set; } = null!;
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
