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

namespace HospitalQMS
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            string staffId = txtStaffID.Text;
            string password = txtPassword.Password;

            if (!String.IsNullOrEmpty(staffId) && !String.IsNullOrEmpty(password) 
                && Password.CheckAccount(staffId, password) )
            {
                //Open Manage Window for each case of StaffType
                MessageBox.Show("SS.", "Đăng nhập SS");
            }
            else
            {
                //Display Error Message
                MessageBox.Show("Sai mã nhân viên hoặc mật khẩu.", "Đăng nhập thất bại");
            }
        }

        private void btnSignup_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(Password.HashPassword(txtStaffID.Text));
        }
    }
}
