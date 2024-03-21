using HospitalQMS.DAO;
using HospitalQMS.Models;
using HospitalQMS.StaffWindow;
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
    /// Interaction logic for GetPatientWindow.xaml
    /// </summary>
    public partial class GetPatientWindow : Window
    {
        private Patient? _newestPatient;
        public GetPatientWindow()
        {
            InitializeComponent();
            loadPatient();
        }
        public GetPatientWindow(bool newPatientAdded)
        {
            InitializeComponent();
            loadPatient();
            loadNewPatient();
        }

        public void loadPatient()
        {
            PatientDAO patientDAO = PatientDAO.Instance;
            lvPatient.ItemsSource = patientDAO.GetSmallPatientList();
        }
        
        private void loadNewPatient()
        {
            _newestPatient = PatientDAO.Instance.GetNewestPatient();
            List<Patient> patients = new List<Patient>();

            if (_newestPatient != null)
            {
                patients.Add(_newestPatient);
            }

            lvPatient.ItemsSource = patients;
            lvPatient.SelectedItem = _newestPatient;
        }

        private void btnHSBA_Click(object sender, RoutedEventArgs e)
        {
            Patient? selectedP = lvPatient.SelectedItem as Patient;
            if (selectedP != null)
            {
                MedicalRecordWindow mrw = new MedicalRecordWindow(selectedP);
                mrw.Show();
            }
            else
            {
                MessageBox.Show("Please select a patient first.");
            }

        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            string searchContent = txtSearch.Text;
            PatientDAO patientDAO = PatientDAO.Instance;
            ICollection<Patient> list = new List<Patient>();
            if (!String.IsNullOrEmpty(searchContent))
            {
                Patient pat = patientDAO.GetPatientByCCId(searchContent);
                if (pat != null)
                {
                    list.Add(pat);
                }
                else
                {
                    list = patientDAO.GetPatientByName(searchContent);
                }
            }

            lvPatient.ItemsSource = list;
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            ExamineTicket ex = new ExamineTicket(_newestPatient);
            ex.ShowDialog();
        }
    }
}
