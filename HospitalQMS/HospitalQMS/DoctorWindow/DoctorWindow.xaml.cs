using HospitalQMS.DAO;
using HospitalQMS.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        private int currentRoomId;
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
            foreach (var department in DepartmentDAO.Instance.GetDepartmentList())
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

            ICollection<Room> roomList = RoomDAO.Instance.GetRoomListOfDepartment(d);
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
                    currentRoomId = room.RoomId;
                    DisplayPatientTab();
                    DisplayDisplayWindow();
                };

                // Add the button to the wrap panel
                wpRoom.Children.Add(button);

                // Set margin to create space between buttons
                button.Margin = new Thickness(10);
            }
        }


        //Xu ly patient tab
        private void DisplayPatientTab()
        {
            tabPatient.IsSelected = true;
            LoadHospitalizedPatient();
            LoadWaitingPatient();
        }

        private void btnSendOut_Click(object sender, RoutedEventArgs e)
        {
            List<Patient>? patientsChoosen = lvWaitingPatient.SelectedItems.Cast<Patient>().ToList();
            if (patientsChoosen != null)
            {
                DrawbackStatusSendOut(patientsChoosen);
                UpdateDisplayWindow();
            }
        }

        private void btnSendIn_Click(object sender, RoutedEventArgs e)
        {
            List<Patient>? patientsChoosen = lvHospitalizedPatient.SelectedItems.Cast<Patient>().ToList();
            if (patientsChoosen != null)
            {
                ModifyStatusSendIn(patientsChoosen);
                UpdateDisplayWindow();
            }
        }

        private void ModifyStatusSendIn(List<Patient> patientsChoosen)
        {
            foreach (Patient p in patientsChoosen)
            {
                if (p != null)
                {
                    p.Status = "Waiting";
                    PatientDAO.Instance.ModifyPatient(p);
                    Ticket? t = TicketDAO.Instance.GetPatientCurrentTicket(p.PatientId);
                    if (t != null)
                    {
                        t.Status = "Accepted";
                        TicketDAO.Instance.ModifyTicket(t);
                        LoadHospitalizedPatient();
                        LoadWaitingPatient();
                    }
                }
            }
        }

        private void DrawbackStatusSendOut(List<Patient> patientsChoosen)
        {
            foreach (Patient p in patientsChoosen)
            {
                if (p != null)
                {
                    p.Status = "Hospitalized";
                    PatientDAO.Instance.ModifyPatient(p);
                    Ticket? t = TicketDAO.Instance.GetPatientCurrentTicket(p.PatientId);
                    if (t != null)
                    {
                        t.Status = "Active";
                        TicketDAO.Instance.ModifyTicket(t);
                        LoadHospitalizedPatient();
                        LoadWaitingPatient();
                    }
                }
            }
        }

        private void LoadHospitalizedPatient()
        {
            lvHospitalizedPatient.ItemsSource = TicketDAO.Instance.GetPatientRegistered(currentRoomId);
        }

        private void LoadWaitingPatient()
        {
            lvWaitingPatient.ItemsSource = TicketDAO.Instance.GetPatientWaiting(currentRoomId);
        }


        //Xu ly tao phieu chi dinh tab

        private Patient _currentPatient;
        private ObservableCollection<ServiceOrder> _serviceOrder = new ObservableCollection<ServiceOrder>();
        private void btnCallIn_Click(object sender, RoutedEventArgs e)
        {
            if (currentRoomId == 15) //Phong kham dau
            {
                SelectTabPCD(sender, e);
            }
            else
            {
                SelectTabNormalRoom(sender, e);
            }

        }

        private void SelectTabPCD(object sender, RoutedEventArgs e)
        {
            List<Patient>? patientsChoosen = lvWaitingPatient.SelectedItems.Cast<Patient>().ToList();
            if (patientsChoosen != null)
            {
                if (patientsChoosen.Count > 1)
                {
                    MessageBox.Show("Chỉ có thể chọn một bệnh nhân trong một lần khám");
                }
                else
                {
                    tabPCD.IsSelected = true;
                    ModifyStatusCallIn(patientsChoosen);
                    LoadSpecialty();
                    LoadDepartment();
                    lbPCD.Content = "Phiếu chỉ định - " + _currentPatient.Pname;
                    UpdateDisplayWindow();
                }
            }
        }

        private void LoadSpecialty()
        {
            cbSpecialty.ItemsSource = SpecialtyDAO.Instance.GetSpecialtyList();
        }

        private void LoadDepartment()
        {
            cbDepartment.ItemsSource = DepartmentDAO.Instance.GetDepartmentList();
        }
        private void ModifyStatusCallIn(List<Patient> patientsChoosen)
        {
            foreach (Patient p in patientsChoosen)
            {
                if (p != null)
                {
                    p.Status = "Examining";
                    PatientDAO.Instance.ModifyPatient(p);
                    Ticket? t = TicketDAO.Instance.GetPatientCurrentTicket(p.PatientId);
                    if (t != null)
                    {
                        t.Status = "Using";
                        TicketDAO.Instance.ModifyTicket(t);
                        LoadHospitalizedPatient();
                        LoadWaitingPatient();
                    }

                    _currentPatient = p;
                }
            }
        }
        private void LoadRoom(Department d)
        {
            cbRoom.ItemsSource = RoomDAO.Instance.GetRoomListOfDepartment(d);
        }

        private void cbDepartment_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Department? d = cbDepartment.SelectedItem as Department;
            if (d != null)
            {
                LoadRoom(d);
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            Specialty? s = cbSpecialty.SelectedItem as Specialty;
            if (s != null && !String.IsNullOrEmpty(s.Sname)) cdSpecialty.Text = s.Sname;
            cdDiagnosis.Text = txtDiagnosis.Text;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Room? r = cbRoom.SelectedItem as Room;
            if (r == null)
            {
                MessageBox.Show("Vui long nhap day du thong tin truoc khi them");
            }
            else if (r != null)
            {
                int nextTicketNumber = TicketDAO.Instance.GetHighestTicketNumberInRoom(r.RoomId) + 1;
                ServiceOrder so = new ServiceOrder
                {
                    serviceName = txtService.Text,
                    roomName = r.Rname + " - " + r.RoomCode,
                    ticketNumber = nextTicketNumber,
                    roomId = r.RoomId
                };

                _serviceOrder.Add(so);
                LoadCD();
                UpdateDisplayWindow();
            }
        }

        private void LoadCD()
        {
            lvCD.ItemsSource = _serviceOrder;
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            ServiceOrder? so = lvCD.SelectedItem as ServiceOrder;
            if (so != null)
            {
                _serviceOrder.Remove(so);
                LoadCD();
            }
        }

        private void btnCreatePCD_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(cdDiagnosis.Text) || String.IsNullOrWhiteSpace(cdSpecialty.Text) || _serviceOrder.Count() == 0)
            {
                MessageBox.Show("Vui long dien day du cac truong thong tin truoc khi tao chi dinh!");
            }
            else
            {
                ModifyStatusCreatePCD(_currentPatient);
                CreateTicketsForPCD();
                tabPatient.IsSelected = true;
                UpdateDisplayWindow();
            }
        }

        private void ModifyStatusCreatePCD(Patient? p)
        {
            if (p != null)
            {
                p.Status = "ChangeRoom";
                PatientDAO.Instance.ModifyPatient(p);
                Ticket? t = TicketDAO.Instance.GetPatientCurrentTicket(p.PatientId);
                if (t != null)
                {
                    t.Status = "Used";
                    TicketDAO.Instance.ModifyTicket(t);
                    LoadHospitalizedPatient();
                    LoadWaitingPatient();
                }
            }

        }

        private void CreateTicketsForPCD()
        {
            foreach (ServiceOrder so in _serviceOrder)
            {
                Ticket t = new Ticket
                {
                    TicketNumber = so.ticketNumber,
                    RegisterTime = DateTime.Now,
                    PatientId = _currentPatient.PatientId,
                    RoomId = so.roomId,
                    Status = "Active"
                };
                TicketDAO.Instance.AddTicket(t);
            }
        }

        private void btnCancelPCD_Click(object sender, RoutedEventArgs e)
        {
            Patient? p = _currentPatient;
            if (p != null)
            {
                p.Status = "Waiting";
                PatientDAO.Instance.ModifyPatient(p);
                Ticket? t = TicketDAO.Instance.GetPatientCurrentTicket(p.PatientId);
                if (t != null)
                {
                    t.Status = "Accepted";
                    TicketDAO.Instance.ModifyTicket(t);
                    LoadHospitalizedPatient();
                    LoadWaitingPatient();
                    UpdateDisplayWindow();
                    tabPatient.IsSelected = true;
                }
            }
        }


        //Manage Display Window
        private DisplayWindow displayWindow;
        private void DisplayDisplayWindow()
        {
            displayWindow = new DisplayWindow(currentRoomId);
            displayWindow.Show();
        }

        private void UpdateDisplayWindow()
        {
            displayWindow.LoadDataComponent();
        }


        //Manage Normal Room

        private void SelectTabNormalRoom(object sender, RoutedEventArgs e)
        {
            List<Patient>? patientsChoosen = lvWaitingPatient.SelectedItems.Cast<Patient>().ToList();
            if (patientsChoosen != null)
            {
                if (patientsChoosen.Count > 1)
                {
                    MessageBox.Show("Chỉ có thể chọn một bệnh nhân trong một lần khám");
                }
                else
                {
                    tabNormalRoom.IsSelected = true;
                    ModifyStatusCallIn(patientsChoosen);
                    UpdateDisplayWindow();
                }
            }
        }
        private void btnChangeRoom_Click(object sender, RoutedEventArgs e)
        {
            Patient? p = _currentPatient;
            if (p != null)
            {
                p.Status = "ChangeRoom";
                PatientDAO.Instance.ModifyPatient(p);
                Ticket? t = TicketDAO.Instance.GetPatientCurrentTicket(p.PatientId);
                if (t != null)
                {
                    t.Status = "Used";
                    TicketDAO.Instance.ModifyTicket(t);
                    LoadHospitalizedPatient();
                    LoadWaitingPatient();
                    UpdateDisplayWindow();
                }
            }
        }

        private void btnCancelNR_Click(object sender, RoutedEventArgs e)
        {
            Patient? p = _currentPatient;
            if (p != null)
            {
                p.Status = "Waiting";
                PatientDAO.Instance.ModifyPatient(p);
                Ticket? t = TicketDAO.Instance.GetPatientCurrentTicket(p.PatientId);
                if (t != null)
                {
                    t.Status = "Accepted";
                    TicketDAO.Instance.ModifyTicket(t);
                    LoadHospitalizedPatient();
                    LoadWaitingPatient();
                    UpdateDisplayWindow();
                }
            }
        }
    }
}