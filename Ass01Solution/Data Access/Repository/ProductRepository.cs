using BusinessObject;
using DataAccess;
using DataAccess.Repository;
using System;
using System.Collections.Generic;

public class ProductRepository : IProductRepository
    {
        public Product GetProductByID(int ProductId) => ProductDAO.Instance.GetProductByID(ProductId);
        public IEnumerable<Product> GetProducts() => ProductDAO.Instance.GetProductList();

        public void InsertProduct(Product Product) => ProductDAO.Instance.AddNew(Product);

        public void DeleteProduct(Product Product) => ProductDAO.Instance.Remove(Product);

        public void UpdateProduct(Product Product) => ProductDAO.Instance.Update(Product);
    }
}
