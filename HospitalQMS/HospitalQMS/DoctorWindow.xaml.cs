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
    /// Interaction logic for DoctorWindow.xaml
    /// </summary>
    public partial class DoctorWindow : Window
    {
        public DoctorWindow()
        {
            InitializeComponent();
        }

        public DoctorWindow(MedicalStaff user)
        {
            InitializeComponent();

            //Display username
            if (user.Title != null) txtUsername.Text = "Người dùng: " + user.Title.Trim().ToString() + user.Msname.Trim().ToString(); 
            else txtUsername.Text = "Người dùng: " + user.Msname.Trim().ToString();

            //Display available departments
            DepartmentDAO departmentDAO = new DepartmentDAO();

            foreach (var department in departmentDAO.GetDepartmentList())
            {
                Button button = new Button();
                button.Content = "Display " + department.Dname.Trim();
                button.Click += (sender, e) =>
                {
                    MessageBox.Show(department.Description);
                };

                // Add the button to the wrap panel
                wrapPanel.Children.Add(button);

                // Set margin to create space between buttons
                button.Margin = new Thickness(5);
            }
        }

    }
}
