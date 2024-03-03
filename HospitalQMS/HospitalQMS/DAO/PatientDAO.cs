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
        public Patient? GetPatientById(int id)
        {
            Patient? obj = null;
            try
            {
                HospitalQMSContext _context = new HospitalQMSContext();
                obj = _context.Patients.SingleOrDefault(x => x.PatientId == id);
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
                            .ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return patients;
        }
    }
}
