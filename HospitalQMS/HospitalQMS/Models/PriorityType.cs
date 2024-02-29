using System;
using System.Collections.Generic;

namespace HospitalQMS.Models
{
    public partial class PriorityType
    {
        public PriorityType()
        {
            Patients = new HashSet<Patient>();
        }

        public int PriorityTypeId { get; set; }
        public string Ptname { get; set; } = null!;
        public string? Description { get; set; }

        public virtual ICollection<Patient> Patients { get; set; }
    }
}
