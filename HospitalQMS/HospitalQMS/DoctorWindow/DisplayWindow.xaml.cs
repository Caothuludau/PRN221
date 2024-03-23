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
                catch(Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }


        private void LoadWaitingPatient()
        {
            List<Patient> waitingPs = TicketDAO.Instance.GetPatientWaiting(currentRoomId);
            lvOutRoom.ItemsSource = waitingPs;
        }
        private void LoadExaminingPatient()
        {
            List<Patient> examPs = TicketDAO.Instance.GetPatientExamining(currentRoomId);
            lvInRoom.ItemsSource = examPs;
        }
    }
}