using System;
using System.Collections.Generic;

namespace HospitalQMS.Models
{
    public partial class Room
    {
        public Room()
        {
            MedicalStaffs = new HashSet<MedicalStaff>();
            Tickets = new HashSet<Ticket>();
        }

        public int RoomId { get; set; }
        public string? Rname { get; set; }
        public string? Status { get; set; }
        public int? SpecialtyId { get; set; }
        public int? DepartmentId { get; set; }
        public string? RoomCode { get; set; }

        public virtual Department? Department { get; set; }
        public virtual Specialty? Specialty { get; set; }
        public virtual ICollection<MedicalStaff> MedicalStaffs { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
