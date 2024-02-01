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
    /// Interaction logic for WindowMembers.xaml
    /// </summary>
    public partial class WindowMembers : Window
    {
        public WindowMembers()
        {
            InitializeComponent();
        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            txtCity.Clear();
            txtCompanyName.Clear();
            txtEmail.Clear();
            txtPassword.Clear();
            txtCountry.Clear();
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            //Check if there are any field null
            if (txtEmail.Text.Trim() != "" && txtCompanyName.Text.Trim() != ""
                && txtCity.Text.Trim() != "" && txtCountry.Text.Trim() != ""
                && txtPassword.Text.Trim() != "")
            {
                if (txtPassword.Text.Trim().Length < 8)
                {
                    MessageBox.Show("Password must length more than 8 characters", "Password Format", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else
                {
                    try
                    {
                        Member mem = new Member(txtEmail.Text, txtCompanyName.Text, txtCity.Text, txtCountry.Text, txtPassword.Text);
                        var _context = MemberDAO.Instance;
                        _context.AddNew(mem);
                        MessageBox.Show($"\"Register successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                        this.Close();
                    }
                    catch
                    {
                        MessageBox.Show("This email has been used. Please use another one", "Email Not Right", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Some fields are left blank, please fill in properly.", "Blank Field", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
