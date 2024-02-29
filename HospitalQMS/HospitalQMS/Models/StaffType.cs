using System;
using System.Collections.Generic;

namespace HospitalQMS.Models
{
    public partial class StaffType
    {
        public StaffType()
        {
            MedicalStaffs = new HashSet<MedicalStaff>();
        }

        public int StaffTypeId { get; set; }
        public string Stname { get; set; } = null!;

        public virtual ICollection<MedicalStaff> MedicalStaffs { get; set; }
    }
}
