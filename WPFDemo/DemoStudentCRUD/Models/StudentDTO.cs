using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoStudentCRUD.Models
{
    internal class StudentDTO
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; } = null!;
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; } = null!;
        public bool? Male { get; set; }
        public bool? Female { get; set; }
        public string? PhoneNumber { get; set; }
        public int? MajorId { get; set; }
        public virtual Major? Major { get; set; }
    }
}
