using System;
using System.Collections.Generic;

namespace HospitalQMS.Models
{
    public partial class Department
    {
        public Department()
        {
            Rooms = new HashSet<Room>();
        }

        public int DepartmentId { get; set; }
        public string? Dname { get; set; }
        public string? Description { get; set; }

        public virtual ICollection<Room> Rooms { get; set; }
    }
}
