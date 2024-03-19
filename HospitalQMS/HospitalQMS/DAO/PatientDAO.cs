using HospitalQMS.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalQMS.DAO
{
    internal class PatientDAO
    {
        private static PatientDAO? instance = null;
        private static readonly object instanceLock = new object();
        private PatientDAO() { }
        public static PatientDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                        instance = new PatientDAO();
                }
                return instance;
            }
        }
        public Patient? GetPatientByCCId(string id)
        {
            Patient? obj = null;
            try
            {
                HospitalQMSContext _context = new HospitalQMSContext();
                obj = _context.Patients
                              .Include(p => p.MedicalRecord)  // Eager loading for MedicalRecord
                              .Include(p => p.PriorityType)   // Eager loading for PriorityType
                              .SingleOrDefault(x => x.Ccnumber.Equals(id));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return obj;
        }
        public ICollection<Patient> GetPatientByName(string name)
        {
            var patients = new List<Patient>();
            try
            {
                HospitalQMSContext _context = new HospitalQMSContext();
                patients = _context.Patients
                            .Where(x => x.Pname.ToLower().Contains(name.Trim().ToLower()))
                            .Include(p => p.MedicalRecord)  // Eager loading for MedicalRecord
                            .Include(p => p.PriorityType)   // Eager loading for PriorityType
                            .ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return patients;
        }

        public ICollection<Patient> GetSmallPatientList()
        {
            var objects = new List<Patient>();
            try
            {
                HospitalQMSContext _context = new HospitalQMSContext();
                objects = _context.Patients
                              .Include(p => p.MedicalRecord)  // Eager loading for MedicalRecord
                              .Include(p => p.PriorityType)   // Eager loading for PriorityType
                              .ToList()
                              .GetRange(1, 5);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return objects;
        }

        public void AddPatient(Patient obj)
        {
            try
            {
                HospitalQMSContext _context = new HospitalQMSContext();
                _context.Patients.Add(obj);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
