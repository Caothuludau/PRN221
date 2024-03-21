using HospitalQMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalQMS.DAO
{
    class PriorityTypeDAO
    {
        private static PriorityTypeDAO? instance = null;
        private static readonly object instanceLock = new object();
        private PriorityTypeDAO() { }
        public static PriorityTypeDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                        instance = new PriorityTypeDAO();
                }
                return instance;
            }
        }
        public ICollection<PriorityType> GetPriorityTypeList()
        {
            try
            {
                HospitalQMSContext _context = new HospitalQMSContext();
                return _context.PriorityTypes.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
