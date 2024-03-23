using HospitalQMS.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
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

        public int GetHighestTicketNumberInRoom(int roomId)
        {
            try
            {
                HospitalQMSContext _context = new HospitalQMSContext();
                var currentDate = DateTime.Now.Date;
                //get the Ticket that is Active and has the nearest register time -> get the TicketNumber
                int highestTKN = _context.Tickets.Where(x => x.Status.Equals("Active") && x.RoomId == roomId && EF.Functions.DateDiffDay(x.RegisterTime, currentDate) == 0)
                                              .OrderByDescending(x => x.RegisterTime)
                                              .Select(x => x.TicketNumber)
                                              .FirstOrDefault();
                return highestTKN;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Patient> GetPatientRegistered(int roomId)
        {
            //Get Patient Registered in Room which has roomId in he same day
            try
            {
                HospitalQMSContext _context = new HospitalQMSContext();
                var currentDate = DateTime.Now.Date;
                List<Patient> activePatients = _context.Tickets
                    .Include(t => t.Patient)
                        .ThenInclude(p => p.MedicalRecord)
                    .Include(t => t.Patient)
                        .ThenInclude(p => p.PriorityType)
                    .Where(t => t.Status == "Active" &&
                                EF.Functions.DateDiffDay(t.RegisterTime, currentDate) == 0 &&
                                t.RoomId == roomId)
                    .OrderBy(t => t.TicketNumber)
                    .Select(t => t.Patient)
                    .ToList();

                return activePatients;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Patient> GetPatientWaiting(int roomId)
        {
            //Get Patient Registered in Room which has roomId in he same day
            try
            {
                HospitalQMSContext _context = new HospitalQMSContext();
                var currentDate = DateTime.Now.Date;
                List<Patient> activePatients = _context.Tickets
                    .Include(t => t.Patient)
                        .ThenInclude(p => p.MedicalRecord)
                    .Include(t => t.Patient)
                        .ThenInclude(p => p.PriorityType)
                    .Where(t => t.Status == "Accepted" &&
                                EF.Functions.DateDiffDay(t.RegisterTime, currentDate) == 0 &&
                                t.RoomId == roomId)
                    .OrderBy(t => t.TicketNumber)
                    .Select(t => t.Patient)
                    .ToList();

                return activePatients;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Patient> GetPatientExamining(int roomId)
        {
            //Get Patient Registered in Room which has roomId in he same day
            try
            {
                HospitalQMSContext _context = new HospitalQMSContext();
                var currentDate = DateTime.Now.Date;
                List<Patient> activePatients = _context.Tickets
                    .Include(t => t.Patient)
                        .ThenInclude(p => p.MedicalRecord)
                    .Include(t => t.Patient)
                        .ThenInclude(p => p.PriorityType)
                    .Where(t => t.Status == "Using" &&
                                EF.Functions.DateDiffDay(t.RegisterTime, currentDate) == 0 &&
                                t.RoomId == roomId)
                    .OrderBy(t => t.TicketNumber)
                    .Select(t => t.Patient)
                    .ToList();

                return activePatients;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Ticket? GetPatientCurrentTicket(int patientId)
        {
            //Get Patient Registered in Room which has roomId in he same day
            try
            {
                HospitalQMSContext _context = new HospitalQMSContext();
                Ticket? patientTicket = _context.Tickets
                    .Where(x => x.PatientId == patientId)
                    .OrderByDescending(t => t.RegisterTime)
                    .FirstOrDefault();
                return patientTicket;
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

        public void ModifyTicket(Ticket obj)
        {
            try
            {
                HospitalQMSContext _context = new HospitalQMSContext();
                _context.Entry<Ticket>(obj).State = EntityState.Modified;
                _context.SaveChanges();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
