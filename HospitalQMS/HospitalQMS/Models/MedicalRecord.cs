using System;
using System.Collections.Generic;

namespace HospitalQMS.Models
{
    public partial class MedicalRecord
    {
        public MedicalRecord()
        {
            Patients = new HashSet<Patient>();
        }

        public int MedicalRecordId { get; set; }
        public string FullName { get; set; } = null!;
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; } = null!;
        public string Diagnosis { get; set; } = null!;
        public string File { get; set; } = null!;
        public string? SocialInsuranceCode { get; set; }
        public DateTime? DateAdmitted { get; set; }
        public DateTime? DateDischarged { get; set; }
        public string? Note { get; set; }
        public string? Occupation { get; set; }
        public string? Company { get; set; }
        public string? TreatmentForm { get; set; }
        public string? Ethnicity { get; set; }
        public string? Address { get; set; }

        public virtual ICollection<Patient> Patients { get; set; }
    }
}
