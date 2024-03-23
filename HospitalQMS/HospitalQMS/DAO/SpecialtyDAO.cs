using HospitalQMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalQMS.DAO
{
    class SpecialtyDAO
    {
        private static SpecialtyDAO? instance = null;
        private static readonly object instanceLock = new object();
        private SpecialtyDAO() { }
        public static SpecialtyDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                        instance = new SpecialtyDAO();
                }
                return instance;
            }
        }
        public ICollection<Specialty> GetSpecialtyList()
        {
            var objects = new List<Specialty>();
            try
            {

                HospitalQMSContext _context = new HospitalQMSContext();
                objects = _context.Specialties.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return objects;
        }
    }
}
