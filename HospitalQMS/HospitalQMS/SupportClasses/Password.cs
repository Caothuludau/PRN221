using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Text;
using HospitalQMS.DAO;
using HospitalQMS.Models;
using System.Windows;

namespace HospitalQMS
{
    class Password
    {

        public static bool CheckAccount(string account, string password)
        {
            MedicalStaffDAO medicalStaffDAO = new MedicalStaffDAO();
            MedicalStaff? ms = medicalStaffDAO.GetMedicalStaffById(Int32.Parse(account));
            if (ms == null || String.IsNullOrEmpty(ms.Password))
            {
                return false;
            }
            else if (ms.Password.Trim().Equals(HashPassword(password)))
            {
                return true;
            }
            return false;
        }

        public static string HashPassword(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // Compute hash from the password bytes
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));

                // Convert byte array to a string
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}
