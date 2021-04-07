using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADSBackend.Models
{
    public class UserAssignments
    {
        public int UserAssignmentsId { get; set; }
        
        public string AssignmentName {get; set;}


        //dd is for due date
        public string AssignmentDD { get; set; }

        public string? timeChoice { get; set; }

        public string? optionalDate { get; set; }

    }
}
