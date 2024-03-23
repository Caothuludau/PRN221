using HospitalQMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalQMS.DAO
{
    class DepartmentDAO
    {
        private static DepartmentDAO? instance = null;
        private static readonly object instanceLock = new object();
        private DepartmentDAO() { }
        public static DepartmentDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                        instance = new DepartmentDAO();
                }
                return instance;
            }
        }
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
