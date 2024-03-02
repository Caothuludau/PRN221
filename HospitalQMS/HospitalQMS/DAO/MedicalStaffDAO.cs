using HospitalQMS.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalQMS.DAO
{
    class MedicalStaffDAO
    {
        public MedicalStaff? GetMedicalStaffById(int id)
        {
            MedicalStaff? obj = null;
            try
            {
                HospitalQMSContext _context = new HospitalQMSContext();
                obj = _context.MedicalStaffs.SingleOrDefault(x => x.StaffId == id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return obj;
        }
        public void CreateAccount(int id, string password)
        {
            try
            {
                MedicalStaff? existingObj = this.GetMedicalStaffById(id);
                if (existingObj != null) // Check if the input object is available in the DB
                {
                    HospitalQMSContext _context = new HospitalQMSContext();
                    existingObj.Password = password;
                    _context.Entry<Object>(existingObj).State = EntityState.Modified;
                    _context.SaveChanges();
                }
                else
                {
                    throw new Exception("This object is not available yet");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
