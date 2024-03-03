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
    /// Interaction logic for GetPatientWindow.xaml
    /// </summary>
    public partial class GetPatientWindow : Window
    {
        public GetPatientWindow()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnHSBA_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            string searchContent = txtSearch.Text;
            PatientDAO patientDAO = new PatientDAO();
            ICollection<Patient> list = new List<Patient>();
            if (Int32.TryParse(searchContent, out int num))
            {
                Patient pat = patientDAO.GetPatientById(num);
                if (pat != null)
                {
                    list.Add(pat);
                }
            }
            else
            {
                list = patientDAO.GetPatientByName(searchContent);
            }

            lvPatient.ItemsSource = list;
        }
    }
}
