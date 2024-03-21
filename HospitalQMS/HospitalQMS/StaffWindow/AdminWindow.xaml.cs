using HospitalQMS.DAO;
using HospitalQMS.Models;
using HospitalQMS.StaffWindow;
using System;
using System.Collections.Generic;
using System.DirectoryServices;
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
    /// Interaction logic for AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        public AdminWindow()
        {
            InitializeComponent();
        }

        private void btnOldPatient_Click(object sender, RoutedEventArgs e)
        {
            GetPatientWindow getPatientWindow = new GetPatientWindow();
            getPatientWindow.ShowDialog();
        }

        private void btnNewPatient_Click(object sender, RoutedEventArgs e)
        {
            AddPatientWindow addPatientWindow = new AddPatientWindow();
            addPatientWindow.ShowDialog();

        }
    }
}
