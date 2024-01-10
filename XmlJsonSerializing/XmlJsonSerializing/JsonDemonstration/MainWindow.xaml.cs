using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace JsonDemonstration
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        ManageProducts products = new ManageProducts();
        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var Product = new Product
                {
                    ProductID = int.Parse(txtProductID.Text),
                    ProductName = txtProductName.Text
                };
                products.InsertProduct(Product);
                LoadProducts();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Insert Product");

            }

        }
        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var Product = new Product
                {
                    ProductID = int.Parse(txtProductID.Text),
                    ProductName = txtProductName.Text
                };
                products.UpdateProduct(Product);
                LoadProducts();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Update Product");
            }
        }
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var Product = new Product
                {
                    ProductID = int.Parse(txtProductID.Text)
                };
                products.DeleteProduct(Product);
                LoadProducts();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Delete Product");
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e) => LoadProducts();
        public void LoadProducts()
        {
            lvProducts.ItemsSource = products.GetProducts();
        }
    }//End Class
}
    
