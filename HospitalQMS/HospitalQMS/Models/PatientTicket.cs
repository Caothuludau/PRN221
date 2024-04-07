using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalQMS.Models
{
    class PatientTicket
    {
        public int TicketNumber { get; set; }
        public string? Pname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool? IsPriority { get; set; }
        public string? Ccnumber { get; set; }
    }
}
