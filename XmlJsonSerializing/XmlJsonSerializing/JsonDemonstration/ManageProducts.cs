using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace JsonDemonstration
{
    //Declaring record Product
    public record Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
    }
    public class ManageProducts
    {
        string fileName = "ProductList.json";
        List<Product> products = new List<Product>();
        public List<Product> GetProducts()
        {
            GetDataFromFile();

            return products;

        }
        public void StoreToFile()
        {
            try
            {
                // Serialize the object graph into a string
                string jsonData = JsonSerializer.Serialize(products,
                new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(fileName, jsonData);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void GetDataFromFile()
        {

            try
            {
                if (File.Exists(fileName))
                {
                    string jsonData = File.ReadAllText(fileName);
                    // Deserialize object graph into a List of Product
                    products = JsonSerializer.Deserialize<List<Product>>(jsonData);

                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void InsertProduct(Product Product)
        {
            try
            {
                Product p = products.SingleOrDefault(p => p.ProductID == Product.ProductID);
                if (p != null)
                {
                    throw new Exception("This product already exists.");
                }
                products.Add(Product);
                StoreToFile();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }//end InsertProduct
        public void UpdateProduct(Product Product)
        {

            try
            {
                Product p = products.SingleOrDefault(p => p.ProductID == Product.ProductID);
                if (p == null)
                {
                    throw new Exception("This product did not exist.");
                }
                else
                {
                    p.ProductName = Product.ProductName;
                    StoreToFile();
                }
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);


            }

        }//end UpdateProduct
        public void DeleteProduct(Product Product)
        {
            try
            {
                Product p = products.SingleOrDefault(p => p.ProductID == Product.ProductID);
                if (p == null)
                {
                    throw new Exception("This product did not exist.");

                }

                else
                {
                    products.Remove(p);
                    StoreToFile();

                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }//end DeleteProduct
    }//end ManageProducts

}