using System;
using System.Collections.Generic;

namespace DemoSan.Models
{
    public partial class Student
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; } = null!;
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; } = null!;
        public string? PhoneNumber { get; set; }
        public int? MajorId { get; set; }

        public virtual Major? Major { get; set; }
    }
}
