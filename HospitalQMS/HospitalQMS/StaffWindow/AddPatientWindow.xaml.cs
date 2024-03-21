using HospitalQMS.DAO;
using HospitalQMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
            PriorityTypeLoad();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateData())
            {
                Patient newPatient = CreateNewPatient();
                MedicalRecord newMedicalRecord = CreateMedicalRecord(newPatient);

                // Add Medical Record
                MedicalRecordDAO.Instance.AddMedicalRecord(newMedicalRecord);

                // Retrieve the newest Medical Record
                MedicalRecord? newestMedicalRecord = MedicalRecordDAO.Instance.GetNewestMedicalRecord();

                if (newestMedicalRecord != null)
                {
                    // Assign Medical Record ID to the new Patient
                    newPatient.MedicalRecordId = newestMedicalRecord.MedicalRecordId;

                    // Add Patient
                    PatientDAO.Instance.AddPatient(newPatient);

                    MessageBox.Show("Thêm bệnh nhân thành công!");
                    RedirectToGetPatientWindow();
                }
            }
        }

        private Patient CreateNewPatient()
        {

            PriorityType? selectedPriority = cbPriority.SelectedItem as PriorityType;
            Patient newPatient = new Patient
            {
                Pname = txtName.Text.Trim(),
                Ccnumber = txtCC.Text.Trim(),
                DateOfBirth = dpDOB.SelectedDate ?? DateTime.MinValue,
                PriorityTypeId = selectedPriority.PriorityTypeId,
                Status = "Hospitalized" // Assuming this is the default status for a new patient
            };

            return newPatient;
        }

        private MedicalRecord CreateMedicalRecord(Patient patient)
        {
            MedicalRecord newMedicalRecord = new MedicalRecord
            {
                FullName = patient.Pname,
                Gender = (rbFemale.IsChecked == true) ? "Nữ" : "Nam",
                DateOfBirth = patient.DateOfBirth,
                DateAdmitted = DateTime.Now,
                Address = txtAddress.Text,
                SocialInsuranceCode = txtBHYT.Text.Trim()
            };

            return newMedicalRecord;
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

        public bool ValidateData()
        {
            // Regular expression pattern to match only digits
            string digitPattern = @"^\d+$";
            Regex digitNumber = new Regex(digitPattern);

            //validate format
            if (String.IsNullOrWhiteSpace(txtName.Text) || cbPriority.SelectedItem == null || dpDOB.SelectedDate == null || String.IsNullOrWhiteSpace(txtAddress.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ các trường thông tin cần thiết!");
                return false;
            }
            else if (dpDOB.SelectedDate.Value > DateTime.Now)
            {
                MessageBox.Show("Ngày sinh không được lớn hơn ngày hiện tại!");
                return false;
            }
            else if (txtCC.Text.Trim().Length != 12 || !digitNumber.IsMatch(txtCC.Text.Trim()))
            {
                MessageBox.Show("Số căn cước phải là một dãy số gồm đủ 12 chữ số!" + txtCC.Text.Trim().Length);
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

        public void PriorityTypeLoad()
        {
            cbPriority.ItemsSource = PriorityTypeDAO.Instance.GetPriorityTypeList();
        }

        public void RedirectToGetPatientWindow()
        {
            var nw = new GetPatientWindow(true);
            nw.Show();
            this.Close();
        }
    }
}
