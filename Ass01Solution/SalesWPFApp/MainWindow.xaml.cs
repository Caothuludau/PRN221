using BusinessObject;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace SalesWPFApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // 3 Login cases and UserRole used to manage the Visibility of Tab
        public enum UserRole
        {
            Customer,
            Admin,
            Unlogged
        }

        public UserRole _currentUserRole = UserRole.Unlogged;

        public MainWindow()
        {
            InitializeComponent();
            _LoadProductList();
            _LoadCategoryList();
        }

        //Code for Member tab

        public void _LoadProductList()
        {
            var _context = ProductDAO.Instance;

            lvProduct.ItemsSource = _context.GetProductList();
            lvOrdProduct.ItemsSource = _context.GetProductList();
        }

        public void _LoadCategoryList()
        {
            var _context = new FStoreContext();
            cbCategory.ItemsSource = _context.Categories.ToList();
        }

        // Code for Order CRUD tab
        private void btnOrdRefresh_Click(object sender, RoutedEventArgs e)
        {
            _LoadProductList();
            txtOrdQuantity.Text = "";
            txtOrdTotalPrice.Text = "";
        }

        //Method auto-generate total price after
        private void txtOrdQuantity_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtOrdUnitPrice.Text != "" && txtOrdQuantity.Text != "")
            {
                double totalPrice = Convert.ToDouble(txtOrdUnitPrice.Text) * Convert.ToDouble(txtOrdQuantity.Text);
                txtOrdTotalPrice.Text = totalPrice.ToString();
            }
        }

        private void btnProdSearch_Click(object sender, RoutedEventArgs e)
        {
            var _context = ProductDAO.Instance;

            //The first time use String.IsNullOrEmpty
            if (!String.IsNullOrEmpty(txtProdSearch.Text))
            {
                int productId;
                if (int.TryParse(txtProdSearch.Text, out productId) && productId != 0)
                {
                    Product? product = _context.GetProductById(productId);
                    //if the product by id is not null -> use it
                    //if not, get list product by that name
                    lvOrdProduct.ItemsSource = product != null
                        ? new List<Product> { product }
                        : _context.GetProductByName(txtProdSearch.Text);
                }
                else
                {
                    lvOrdProduct.ItemsSource = _context.GetProductByName(txtProdSearch.Text);
                }
            }


        }

        private void btnAddToCart_Click(object sender, RoutedEventArgs e)
        {
            if (lvOrdProduct.SelectedItem != null)
            {
                Product? prod = lvOrdProduct.SelectedItem as Product;
                if (prod != null)
                {
                    if (txtProductName.Text.Trim() != "" && txtWeight.Text.Trim() != ""
                    && txtUnitPrice.Text.Trim() != "" && txtUnitInStock.Text.Trim() != ""
                    && cbCategory.SelectedValue != null)
                    {
                        try
                        {
                            Product prodToUpdate = new Product(prod.ProductId, txtProductName.Text, txtWeight.Text, Convert.ToDecimal(txtUnitPrice.Text), Convert.ToInt32(txtUnitInStock.Text), Convert.ToInt32(cbCategory.SelectedValue));
                            var _context = ProductDAO.Instance;
                            _context.UpdateProduct(prodToUpdate);
                            MessageBox.Show($"\"{txtProductName.Text}\" update successfully!", "Update Success", MessageBoxButton.OK, MessageBoxImage.Information);
                            _LoadProductList();
                        }
                        catch
                        {
                            MessageBox.Show("Some fields are not in the right format, please fill in properly.", "Format Field Not Right", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Some fields are left blank, please fill in properly.", "Blank Field", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
        }

        private void btnViewCart_Click(object sender, RoutedEventArgs e)
        {
            Window ordWindow = new WindowOrders();
            ordWindow.Show();
        }

        private void btnOrdDelete_Click(object sender, RoutedEventArgs e)
        {
            if (lvProduct.SelectedItem != null)
            {
                Product? prod = lvProduct.SelectedItem as Product;
                if (prod != null)
                {
                    var _context = ProductDAO.Instance;
                    _context.RemoveProduct(prod);
                    MessageBox.Show("Delete item successfully", "Delete Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    _LoadProductList();
                }
            }
            else
            {
                MessageBox.Show("No product is selected!", "Error", MessageBoxButton.OK);
            }
        }


        // Code for Product CRUD tab

        private void btnPrdRefresh_Click(object sender, RoutedEventArgs e)
        {
            _LoadProductList();
        }

        private void btnPrdAdd_Click(object sender, RoutedEventArgs e)
        {
            Window prodWindow = new WindowProducts();
            prodWindow.Show();
        }

        private void btnPrdEdit_Click(object sender, RoutedEventArgs e)
        {
            if (lvProduct.SelectedItem != null)
            {
                Product? prod = lvProduct.SelectedItem as Product;
                if (prod != null)
                {
                    if (txtProductName.Text.Trim() != "" && txtWeight.Text.Trim() != ""
                    && txtUnitPrice.Text.Trim() != "" && txtUnitInStock.Text.Trim() != ""
                    && cbCategory.SelectedValue != null)
                    {
                        try
                        {
                            Product prodToUpdate = new Product(prod.ProductId, txtProductName.Text, txtWeight.Text, Convert.ToDecimal(txtUnitPrice.Text), Convert.ToInt32(txtUnitInStock.Text), Convert.ToInt32(cbCategory.SelectedValue));
                            var _context = ProductDAO.Instance;
                            _context.UpdateProduct(prodToUpdate);
                            MessageBox.Show($"\"{txtProductName.Text}\" update successfully!", "Update Success", MessageBoxButton.OK, MessageBoxImage.Information);
                            _LoadProductList();
                        }
                        catch
                        {
                            MessageBox.Show("Some fields are not in the right format, please fill in properly.", "Format Field Not Right", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Some fields are left blank, please fill in properly.", "Blank Field", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
        }

        private void btnPrdDelete_Click(object sender, RoutedEventArgs e)
        {
            if (lvProduct.SelectedItem != null)
            {
                Product? prod = lvProduct.SelectedItem as Product;
                if (prod != null)
                {
                    var _context = ProductDAO.Instance;
                    _context.RemoveProduct(prod);
                    MessageBox.Show("Delete item successfully", "Delete Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    _LoadProductList();
                }
            }
            else
            {
                MessageBox.Show("No product is selected!", "Error", MessageBoxButton.OK);
            }
        }

        private void lvProduct_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

        }

    }
}
