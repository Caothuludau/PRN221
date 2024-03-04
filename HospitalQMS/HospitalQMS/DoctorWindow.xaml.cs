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
                button.Height = 50;
                button.Width = 70;
                button.Content = department.Dname.Trim();
                button.Click += (sender, e) =>
                {
                    DisplayRoom(department);
                };

                // Add the button to the wrap panel
                wpDepartment.Children.Add(button);

                // Set margin to create space between buttons
                button.Margin = new Thickness(10);
            }
        }

        private void DisplayRoom(Department d)
        {
            
            RoomDAO roomDAO = new RoomDAO();
            ICollection<Room> roomList = roomDAO.GetRoomListOfDepartment(d);
            //Set floor for cbFloor
            // Extract unique floor numbers
            HashSet<int> floorSet = new HashSet<int>();
            foreach (Room room in roomList)
            {
                floorSet.Add(room.Floor);
            }
            // Convert the HashSet to a sorted list of floor numbers
            List<int> floorList = new List<int>(floorSet);
            floorList.Sort();

            // Set the ItemsSource of the ComboBox to the list of floor numbers
            cbFloor.ItemsSource = floorList;


            // Clear current content
            wpRoom.Children.Clear();
            foreach (var room in roomList)
            {
                Button button = new Button();   
                button.Height = 50;
                button.Width = 350;
                button.HorizontalContentAlignment = HorizontalAlignment.Left;
                button.Content = "   " + room.RoomCode.Trim() + "\n   " + room.Rname.Trim();
                button.Click += (sender, e) =>
                {
                    DisplayQueueTab();
                };

                // Add the button to the wrap panel
                wpRoom.Children.Add(button);

                // Set margin to create space between buttons
                button.Margin = new Thickness(10);
            }
        }

        private void DisplayQueueTab()
        {
            tabPatient.IsSelected = true;
        }
    }
}
