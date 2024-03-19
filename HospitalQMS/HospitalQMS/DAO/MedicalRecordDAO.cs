using HospitalQMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalQMS.DAO
{
    internal class MedicalRecordDAO
    {
        private static MedicalRecordDAO? instance = null;
        private static readonly object instanceLock = new object();
        private MedicalRecordDAO() { }
        public static MedicalRecordDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                        instance = new MedicalRecordDAO();
                }
                return instance;
            }
        }

        public void AddMedicalRecord(MedicalRecord obj)
        {
            try
            {

                HospitalQMSContext _context = new HospitalQMSContext();
                _context.MedicalRecords.Add(obj);
                _context.SaveChanges();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
       
        public MedicalRecord GetNewestMedicalRecord()
        {
            try
            {

                HospitalQMSContext _context = new HospitalQMSContext();
                return _context.MedicalRecords.Last();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
