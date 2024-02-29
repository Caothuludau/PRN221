using System;
using System.Collections.Generic;

namespace HospitalQMS.Models
{
    public partial class MedicalStaff
    {
        public int StaffId { get; set; }
        public string Msname { get; set; } = null!;
        public string? Title { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Status { get; set; }
        public int? StaffTypeId { get; set; }
        public int? SpecialtyId { get; set; }
        public int? RoomId { get; set; }
        public string? Password { get; set; }

        public virtual Room? Room { get; set; }
        public virtual Specialty? Specialty { get; set; }
        public virtual StaffType? StaffType { get; set; }
    }
}
