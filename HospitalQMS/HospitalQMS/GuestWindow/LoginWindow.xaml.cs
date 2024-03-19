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

            /*MedicalStaffDAO medicalStaf = new MedicalStaffDAO();
            MedicalStaff? msao = medicalStaf.GetMedicalStaffById(176726);
            DoctorWindow doctorWindo = new DoctorWindow(msao); //ms will not null
            doctorWindo.Show();
            this.Close();*/
            AdminWindow adminWindow1 = new AdminWindow();
            adminWindow1.Show();
            this.Close();

            string staffId = txtStaffID.Text;
            string password = txtPassword.Password;

            if (!String.IsNullOrEmpty(staffId) && !String.IsNullOrEmpty(password) 
                && Password.CheckAccount(staffId, password) )
            {
                //Open Manage Window for each case of StaffType
                MessageBox.Show("SS.", "Đăng nhập SS");
                try
                {
                    MedicalStaffDAO medicalStaffDAO = new MedicalStaffDAO();
                    MedicalStaff? ms = medicalStaffDAO.GetMedicalStaffById(Int32.Parse(staffId));
                    int? staffType = -1;
                    if (ms != null && ms.StaffTypeId != null) staffType = ms.StaffTypeId;

                    if (staffType == 1 || staffType == 2) //Doctor = 1, Nurse = 2
                    {
                        DoctorWindow doctorWindow = new DoctorWindow(ms); //ms will not null
                        doctorWindow.Show();
                        this.Close();
                    }
                    else if (staffType == 3) //Admin Staff = 3
                    {
                        AdminWindow adminWindow = new AdminWindow();
                        adminWindow.Show();
                        this.Close();
                    }
                    else if (staffType == 4) //Tech = 4
                    {

                    }
                    else
                    {
                        MessageBox.Show("Tài khoản của bạn chưa đủ quyền truy cập vào hệ thống.", "Không đủ quyền hạn");
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            
            }   
            else
            {
                //Display Error Message
                MessageBox.Show("Sai mã nhân viên hoặc mật khẩu.", "Đăng nhập thất bại");
            }
        }

        private void btnSignup_Click(object sender, RoutedEventArgs e)
        {
            SigninWindow signinWindow = new SigninWindow();
            signinWindow.Show();
            this.Close();
        }
    }
}
