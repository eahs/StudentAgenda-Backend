using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADSBackend.Models
{
    public class MemberAssignment
    {
        public int MemberId { get; set; }
        public Member Member { get; set; }

        public int AssignmentId { get; set;}
        public Assignment Assignment { get; set; }

    }
}
