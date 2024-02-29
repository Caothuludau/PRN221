using System;
using System.Collections.Generic;

namespace HospitalQMS.Models
{
    public partial class Ticket
    {
        public int TicketId { get; set; }
        public int TicketNumber { get; set; }
        public DateTime RegisterTime { get; set; }
        public int PatientId { get; set; }
        public int? RoomId { get; set; }

        public virtual Patient Patient { get; set; } = null!;
        public virtual Room? Room { get; set; }
    }
}
