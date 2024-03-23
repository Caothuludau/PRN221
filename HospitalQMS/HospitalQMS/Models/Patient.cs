using System;
using System.Collections.Generic;

namespace HospitalQMS.Models
{
    public partial class Patient
    {
        public Patient()
        {
            Tickets = new HashSet<Ticket>();
        }

        public int PatientId { get; set; }
        public string Pname { get; set; } = null!;
        public DateTime DateOfBirth { get; set; }
        public string Status { get; set; } = null!;
        public int? PriorityTypeId { get; set; }
        public int? MedicalRecordId { get; set; }
        public string? Ccnumber { get; set; }
        public virtual MedicalRecord? MedicalRecord { get; set; }
        public virtual PriorityType? PriorityType { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
