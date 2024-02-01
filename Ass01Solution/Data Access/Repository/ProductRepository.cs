using BusinessObject;
using DataAccess;
using DataAccess.Repository;
using System;
using System.Collections.Generic;

public class ProductRepository : IProductRepository
    {
        public Product? GetProductById(int ProductId) => ProductDAO.Instance.GetProductById(ProductId);
        public IEnumerable<Product> GetProducts() => ProductDAO.Instance.GetProductList();

        public void InsertProduct(Product Product) => ProductDAO.Instance.AddProduct(Product);

        public void DeleteProduct(Product Product) => ProductDAO.Instance.RemoveProduct(Product);

        public void UpdateProduct(Product Product) => ProductDAO.Instance.UpdateProduct(Product);
    }
