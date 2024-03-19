using HospitalQMS.DAO;
using HospitalQMS.Models;
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
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class SigninWindow : Window
    {
        public SigninWindow()
        {
            InitializeComponent();
        }

        private void btnSignup_Click(object sender, RoutedEventArgs e)
        {
            string staffId = txtStaffID.Text;
            string password = txtPassword.Password;
            string repassword = txtRePassword.Password;

            //Case blank input
            if (String.IsNullOrEmpty(staffId) || String.IsNullOrEmpty(password) || String.IsNullOrEmpty(repassword))
            {
                MessageBox.Show("Vui lòng điền đầy đủ các trường thông tin.", "Đăng ký thất bại");
            }

            //Case password and repassword not fit
            else if (!password.Equals(repassword)) 
            {
                MessageBox.Show("Mật khẩu nhập lại không khớp.", "Đăng ký thất bại");
            }

            //Case staffId had password (been used) or not available
            else
            {
                MedicalStaffDAO medicalStaffDAO = new MedicalStaffDAO();
                MedicalStaff? ms = medicalStaffDAO.GetMedicalStaffById(Int32.Parse(staffId));
                if (ms == null)
                {
                    MessageBox.Show("Mã nhân viên không tồn tại.", "Đăng ký thất bại");
                }
                else if (ms != null && ms.Password != null) 
                {
                    MessageBox.Show("Mã nhân viên này đã được sử dụng rồi.", "Đăng ký thất bại");
                }
                //Case success
                else
                {
                    medicalStaffDAO.CreateAccount(Int32.Parse(staffId), Password.HashPassword(password));
                    MessageBox.Show("Bạn đã có thể đăng nhập.", "Đăng ký thành công");
                }
            }
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
            this.Close();
        }
    }
}
