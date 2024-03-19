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
    /// Interaction logic for MedicalRecordWindow.xaml
    /// </summary>
    public partial class MedicalRecordWindow : Window
    {
        public MedicalRecordWindow()
        {
            InitializeComponent();
        }

        public MedicalRecordWindow(Patient p)
        {
            InitializeComponent();
            if (p.MedicalRecord != null )
            {
                MedicalRecord mr = p.MedicalRecord;
                txtName.Text = mr.FullName;
                dpDOB.SelectedDate = mr.DateOfBirth;
                txtGender.Text = mr.Gender;
                txtEthnicity.Text = mr.Ethnicity;
                txtBHYT.Text = mr.SocialInsuranceCode;
                txtOccupation.Text = mr.Occupation;
                txtCompany.Text = mr.Company;
                txtAddress.Text = mr.Address;
                dpAdmitted.SelectedDate = mr.DateAdmitted;
                dpDischarged.SelectedDate = mr.DateDischarged;
                txtDiagnosis.Text = mr.Diagnosis;
                txtNote.Text = mr.Note;
            }
        }
    }
}
