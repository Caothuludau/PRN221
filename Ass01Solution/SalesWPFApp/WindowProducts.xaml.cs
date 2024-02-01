using BusinessObject;
using DataAccess;
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
using System.Windows.Shapes;

namespace SalesWPFApp
{
    /// <summary>
    /// Interaction logic for WindowProducts.xaml
    /// </summary>
    public partial class WindowProducts : Window
    {
        public WindowProducts()
        {
            InitializeComponent();
            _LoadCategoryList();
        }

        public void _LoadCategoryList()
        {
            var _context = new FStoreContext();
            cbCategory.ItemsSource = _context.Categories.ToList();
        }

        private void btnPrdRefresh_Click(object sender, RoutedEventArgs e)
        {
            txtProductName.Clear();
            txtWeight.Clear();
            txtUnitPrice.Clear();
            txtUnitInStock.Clear();
            cbCategory.SelectedIndex = -1;
        }

        private void btnPrdAdd_Click(object sender, RoutedEventArgs e)
        {
            //Check if there are any field null
            if (txtProductName.Text.Trim() != "" && txtWeight.Text.Trim() != ""
                && txtUnitPrice.Text.Trim() != "" && txtUnitInStock.Text.Trim() != "" 
                && cbCategory.SelectedValue != null)
            {
                try
                {
                    Product prd = new Product(txtProductName.Text, txtWeight.Text, Convert.ToDecimal(txtUnitPrice.Text), Convert.ToInt32(txtUnitInStock.Text), Convert.ToInt32(cbCategory.SelectedValue));
                    var _context = ProductDAO.Instance;
                    _context.AddProduct(prd);
                    MessageBox.Show($"\"{txtProductName.Text}\" added successfully!", "Add Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    this.Close();
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
