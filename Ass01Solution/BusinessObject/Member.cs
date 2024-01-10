using System;
using System.Collections.Generic;

namespace BusinessObject
{
    public partial class Member
    {

        public int MemberId { get; set; }
        public string Email { get; set; } = null!;
        public string CompanyName { get; set; } = null!;
        public string City { get; set; } = null!;
        public string Country { get; set; } = null!;
        public string Password { get; set; } = null!;
        public Member()
        {
            Orders = new HashSet<Order>();
        }
        public virtual ICollection<Order> Orders { get; set; }

    }
}