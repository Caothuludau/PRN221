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
    /// Interaction logic for WindowLogin.xaml
    /// </summary>
    public partial class WindowLogin : Window
    {

        public WindowLogin()
        {
            InitializeComponent();
        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            txtEmail.Clear();
            txtPassword.Clear();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            //Check if there are any field null
            if (txtEmail.Text.Trim() != "" && txtPassword.Text.Trim() != "")
            {
                var _context = MemberDAO.Instance;
                //Check for admin role
                if (BusinessRules.MemberRules.IsAdmin(txtEmail.Text, txtPassword.Text))
                {
                    MainWindow mainWindow = new MainWindow();
                    mainWindow.Show();
                    mainWindow._currentUserRole = MainWindow.UserRole.Admin;
                    mainWindow.txtUserInfor.Text = $"Admin: {txtEmail.Text}";
                    MessageBox.Show("Logged in as admin successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    this.Close();
                }
                else
                {
                    //Check for customer role
                    bool isLogged = _context.Login(txtEmail.Text, txtPassword.Text);
                    if (isLogged)
                    {
                        MainWindow mainWindow = new MainWindow();
                        mainWindow.Show();
                        mainWindow._currentUserRole = MainWindow.UserRole.Customer;
                        mainWindow.txtUserInfor.Text = $"User: {txtEmail.Text}";
                        MessageBox.Show("Logged in successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Your email or password is incorrect!", "Unsuccess", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }

            }
            else
            {
                MessageBox.Show("Some fields are left blank, please fill in properly.", "Blank Field", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            Window regWindow = new WindowMembers();
            regWindow.Show();
        }
    }
}
