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

namespace HospitalQMS.StaffWindow
{
    /// <summary>
    /// Interaction logic for AddPatientWindow.xaml
    /// </summary>
    public partial class AddPatientWindow : Window
    {
        public AddPatientWindow()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            //validate data
            if (validateData())
            {
                Patient newP = new Patient();
                newP.Pname = txtName.Text.Trim();
                if (!String.IsNullOrWhiteSpace(txtCC.Text)) newP.Ccnumber = txtCC.Text.Trim();
                if (dpDOB.SelectedDate != null) newP.DateOfBirth = dpDOB.SelectedDate.Value;
                newP.Status = "Hospitalized"; //nhap vien

                //For Medical Record
                MedicalRecord newMR = new MedicalRecord();
                newMR.FullName = newP.Pname;
                if (rbFemale.IsChecked == true) newMR.Gender = "Nữ";
                else newMR.Gender = "Nam";
                newMR.DateOfBirth = newP.DateOfBirth;
                newMR.DateAdmitted = DateTime.Now;
                MedicalRecordDAO.Instance.AddMedicalRecord(newMR);

                newP.MedicalRecordId = MedicalRecordDAO.Instance.GetNewestMedicalRecord().MedicalRecordId;
                PatientDAO.Instance.AddPatient(newP);
            }
        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            txtCC.Clear();
            txtBHYT.Clear();
            txtName.Clear();
            cbPriority.SelectedValue = null;
            dpDOB.SelectedDate = null;
            rbMale.IsChecked = true;
        }

        public bool validateData()
        {
            int temp;
            //validate format
            if (String.IsNullOrWhiteSpace(txtName.Text) || cbPriority.SelectedItem == null || dpDOB.SelectedDate == null)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ các trường thông tin cần thiết!");
                return false;
            }
            else if (dpDOB.SelectedDate.Value > DateTime.Now)
            {
                MessageBox.Show("Ngày sinh không được lớn hơn ngày hiện tại!");
                return false;
            }
            else if (txtCC.Text.Length != 12 || !Int32.TryParse(txtCC.Text, out temp))
            {
                MessageBox.Show("Số căn cước phải là một dãy số gồm đủ 12 chữ số!");
                return false;
            }
            //validate data
            if (String.IsNullOrWhiteSpace(txtCC.Text))
            {
                DateTime birthDate = dpDOB.SelectedDate.Value;
                DateTime currentDate = DateTime.Now;
                // Calculate the target date (14 years and 1 month from the selected date)
                DateTime targetDate = birthDate.AddYears(14).AddMonths(1);

                // Calculate the difference between the current date and the selected date
                TimeSpan difference = currentDate - birthDate;
                if (difference >= targetDate - birthDate)
                {
                    MessageBox.Show("Bệnh nhân trên 14 tuổi cần điền số căn cước!");
                    return false;
                }
            }
            else if (PatientDAO.Instance.GetPatientByCCId(txtCC.Text) != null)
            {
                MessageBox.Show("Số căn cước này đã được đăng ký trong hệ thống!");
                return false;
            }
            return true;
        }
    }
}
