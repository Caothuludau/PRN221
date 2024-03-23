using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalQMS.Models
{
    public partial class ServiceOrder
    {
        public string? serviceName { get; set; }
        public int roomId { get; set; }
        public string? roomName { get; set; }
        public int ticketId { get; set; }
        public int ticketNumber { get; set; }

    }
}
