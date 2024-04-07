using HospitalQMS.DAO;
using HospitalQMS.Models;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HospitalQMS
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class DisplayWindow : Window
    {
        int currentRoomId;
        public DisplayWindow(int id)
        {
            InitializeComponent();
            currentRoomId = id;
            LoadDataComponent();
        }
        public void LoadDataComponent()
        {
            if (currentRoomId > 0)
            {
                try
                {
                    LoadWaitingPatient();
                    LoadExaminingPatient();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }


        private void LoadWaitingPatient()
        {
            List<Patient> waitingPs = TicketDAO.Instance.GetPatientWaiting(currentRoomId);
            List<PatientTicket> pts = new List<PatientTicket>();
            foreach (Patient p in waitingPs)
            {
                Ticket? tk = TicketDAO.Instance.GetPatientCurrentTicket(p.PatientId);
                if (tk != null && p.MedicalRecord != null)
                {
                    PatientTicket patientTicket = new PatientTicket
                    {
                        TicketNumber = tk.TicketNumber,
                        Pname = p.Pname,
                        DateOfBirth = p.MedicalRecord.DateOfBirth,
                        IsPriority = p.PriorityTypeId != null,
                        Ccnumber = p.Ccnumber
                    };
                    pts.Add(patientTicket);
                }
            }
            lvOutRoom.ItemsSource = pts;
        }
        private void LoadExaminingPatient()
        {
            List<Patient> examPs = TicketDAO.Instance.GetPatientExamining(currentRoomId);
            List<PatientTicket> pts = new List<PatientTicket>();
            foreach (Patient p in examPs)
            {
                Ticket? tk = TicketDAO.Instance.GetPatientCurrentTicket(p.PatientId);
                if (tk != null && p.MedicalRecord != null)
                {
                    PatientTicket patientTicket = new PatientTicket
                    {
                        TicketNumber = tk.TicketNumber,
                        Pname = p.Pname,
                        DateOfBirth = p.MedicalRecord.DateOfBirth,
                        IsPriority = p.PriorityTypeId != null,
                        Ccnumber = p.Ccnumber
                    };
                    pts.Add(patientTicket);
                }
            }
            lvInRoom.ItemsSource = pts;
        }
    }
}