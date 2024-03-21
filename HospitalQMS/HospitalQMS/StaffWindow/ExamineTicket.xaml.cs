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

namespace HospitalQMS.StaffWindow
{
    /// <summary>
    /// Interaction logic for ExamineTicket.xaml
    /// </summary>
    public partial class ExamineTicket : Window
    {
        //Basically first room
        private int clinicalRoomId = 1;
        public ExamineTicket()
        {
            InitializeComponent();
        }

        public ExamineTicket(Patient? p)
        {
            InitializeComponent();
            LoadPatientData(p);
            Ticket t = CreateNewTicket(p);
            LoadTicketData(t);
        }

        private void LoadPatientData(Patient? p)
        {
            if (p != null)
            {
                lbName.Content = "Họ và tên: " + p.Pname;
                lbAddress.Content = "Địa chỉ: " + p.MedicalRecord.Address;
                lbGender.Content = "Giới tính: " + p.MedicalRecord.Gender;
                lbBirthYear.Content = "Năm sinh: " + p.DateOfBirth.Year;
                lbPriority.Content = "Đối tượng: " + p.PriorityType.Ptname;
                lbDate.Content = "Ngày khám: " + DateTime.Now;
            }
        }

        private Ticket CreateNewTicket(Patient? p)
        {
            Ticket ticket = new Ticket
            {
                TicketNumber = GetPatientPosition(),
                PatientId = p.PatientId,
                RoomId = clinicalRoomId,
                RegisterTime = DateTime.Now
            };

            TicketDAO.Instance.AddTicket(ticket);
            return ticket;
        }

        private int GetPatientPosition()
        {
            return TicketDAO.Instance.GetNumberOfPatientInRoom(clinicalRoomId) + 1;
        }

        private void LoadTicketData(Ticket ticket)
        {
            lbSTT.Content = ticket.TicketNumber.ToString();
            lbRoom.Content = clinicalRoomId.ToString();
        }
    }
}
