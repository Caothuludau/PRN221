using BusinessObject;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Runtime.ConstrainedExecution;

namespace DataAccess
{
    public sealed class ProductDAO
    {
        private static ProductDAO? instance = null;
        private static readonly object instanceLock = new object();
        private ProductDAO() { }

        public static ProductDAO Instance
        {
            get
            {
                lock(instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new ProductDAO();
                    }
                }
                return instance;
            }
        }

        public ICollection<Product> GetProductList()
        {
            var products = new List<Product>();
            try
            {
                FStoreContext _context = new FStoreContext();
                products = _context.Products.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return products;
        }

        public Product? GetProductById(int id)
        {
            Product? product = null;
            try
            {
                FStoreContext _context = new FStoreContext();
                product = _context.Products.SingleOrDefault(x => x.ProductId == id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return product;
        }

        public ICollection<Product> GetProductByName(string name)
        {
            var products = new List<Product>();
            try
            {
                FStoreContext _context = new FStoreContext();
                products = _context.Products.Where(x => x.ProductName.ToLower().Contains(name.Trim().ToLower()))
                                            .ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return products;
        }

        public void AddProduct(Product product)
        {
            try 
            {
                if (this.GetProductById(product.ProductId) == null) 
                {
                    FStoreContext _context = new FStoreContext();
                    _context.Products.Add(product);
                    _context.SaveChanges();
                }
                else
                {
                    throw new Exception("This product has been available");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
    }
        }

        public void UpdateProduct(Product product)
        {
            try
            {
                
                Product? isProduct = this.GetProductById(product.ProductId);
                if (isProduct != null) //Check if the input product is available in DB or not
                {
                    FStoreContext _context = new FStoreContext();
                    _context.Entry<Product>(product).State = EntityState.Modified;
                    _context.SaveChanges();
                }
                else
                {
                    throw new Exception("This product is not avalable yet");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void RemoveProduct(Product product) 
        {
            
            try
            {
                Product? isProduct = this.GetProductById(product.ProductId);
                if (isProduct != null) //Check if the input product is available in DB or not
                {
                    FStoreContext _context = new FStoreContext();
                    _context.Products.Remove(product);
                    _context.SaveChanges();
                }
                else
                {
                    throw new Exception("This product is not avalable yet");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }//end class
}
