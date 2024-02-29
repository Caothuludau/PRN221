using System;
using System.Collections.Generic;

namespace HospitalQMS.Models
{
    public partial class Specialty
    {
        public Specialty()
        {
            MedicalStaffs = new HashSet<MedicalStaff>();
            Rooms = new HashSet<Room>();
        }

        public int SpecialtyId { get; set; }
        public string? Sname { get; set; }

        public virtual ICollection<MedicalStaff> MedicalStaffs { get; set; }
        public virtual ICollection<Room> Rooms { get; set; }
    }
}
