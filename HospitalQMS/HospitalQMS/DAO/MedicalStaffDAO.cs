using HospitalQMS.Models;
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
    }
}
