using HospitalQMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalQMS.DAO
{
    internal class DepartmentDAO
    {

        public ICollection<Department> GetDepartmentList()
        {
            var departments = new List<Department>();
            try
            {
                HospitalQMSContext _context = new HospitalQMSContext();
                departments = _context.Departments.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return departments;
        }
    }
}
