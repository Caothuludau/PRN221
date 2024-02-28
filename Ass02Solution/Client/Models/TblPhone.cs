using System;
using System.Collections.Generic;

namespace Client.Models
{
    public partial class TblPhone
    {
        public int Id { get; set; }
        public string? Branch { get; set; }
        public string Name { get; set; } = null!;
        public DateTime? DateOfManufacture { get; set; }
        public bool? StopManufacture { get; set; }
    }
}
