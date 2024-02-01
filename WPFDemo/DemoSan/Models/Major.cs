using System;
using System.Collections.Generic;

namespace DemoSan.Models
{
    public partial class Major
    {
        public Major()
        {
            Students = new HashSet<Student>();
        }

        public int MajorId { get; set; }
        public string MajorName { get; set; } = null!;

        public virtual ICollection<Student> Students { get; set; }
    }
}
