using HospitalQMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalQMS.DAO
{
    class TicketDAO
    {
        private static TicketDAO? instance = null;
        private static readonly object instanceLock = new object();
        private TicketDAO() { }
        public static TicketDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                        instance = new TicketDAO();
                }
                return instance;
            }
        }

        public int GetNumberOfPatientInRoom(int roomId)
        {
            try
            {
                HospitalQMSContext _context = new HospitalQMSContext();
                int numberOfPatientsInRoom = _context.Tickets
                                                     .Count(ticket => ticket.RoomId == roomId && ticket.RegisterTime.Date == DateTime.Today && ticket.Status.Equals("Active"));
                return numberOfPatientsInRoom;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void AddTicket(Ticket obj)
        {
            try
            {
                HospitalQMSContext _context = new HospitalQMSContext();
                _context.Tickets.Add(obj);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
