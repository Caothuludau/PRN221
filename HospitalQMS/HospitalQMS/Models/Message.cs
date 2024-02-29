using System;
using System.Collections.Generic;

namespace HospitalQMS.Models
{
    public partial class Message
    {
        public int MessageId { get; set; }
        public string? Language { get; set; }
        public string? Type { get; set; }
        public string? Content { get; set; }
    }
}
