using BusinessObject;
using Microsoft.EntityFrameworkCore;
using System;
using System.Runtime.ConstrainedExecution;

namespace DataAccess
{
    public class ProductDAO
    {
        //Using Singleton Pattern
        private static ProductDAO? instance = null;
        private static readonly object instanceLock = new object();
        private ProductDAO() { }
        public static ProductDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                        instance = new ProductDAO();
                }
                return instance;
            }
        }

        public IEnumerable<Product> GetProductList()
        {
            List<Product> Products;
            try
            {
                var fStoreDB = new BusinessObject.FStoreContext();
                Products = fStoreDB.Products.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return Products;
        }
        public Product GetProductByID(int ProductID)
        {
            Product? Product = null;
            try
            {
                var fStoreDB = new FStoreContext();
                Product = fStoreDB.Products.SingleOrDefault(Product => Product.ProductId == ProductID);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return Product;
        }
        public void AddNew(Product Product)
        {
            try
            {
                Product _Product = GetProductByID(Product.ProductId);
                if (_Product == null)
                {
                    var fStoreDB = new FStoreContext();
                    fStoreDB.Products.Add(Product);
                    fStoreDB.SaveChanges();
                }
                else
                {
                    throw new Exception("The Product is already exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }
        public void Update(Product Product)
        {
            try
            {
                Product c = GetProductByID(Product.ProductId);
                if (c != null)
                {
                    var fStoreDB = new FStoreContext();
                    fStoreDB.Entry<Product>(Product).State = EntityState.Modified;
                    fStoreDB.SaveChanges();
                }
                else
                {
                    throw new Exception("The Product does not already exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Remove(Product Product)
        {
            try
            {
                Product _Product = GetProductByID(Product.ProductId);
                if (_Product != null)
                {
                    var fStoreDB = new FStoreContext();
                    fStoreDB.Products.Remove(Product);
                    fStoreDB.SaveChanges();
                }

                else
                {
                    throw new Exception("The Product does not already exist");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        } // end Remove
    }//end class
}
