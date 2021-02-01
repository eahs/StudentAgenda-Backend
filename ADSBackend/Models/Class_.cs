using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ADSBackend.Models
{
    public class Class_
    {

        [Key]

        public int Class_Id { get; set; }

        public string Teacher { get; set; }

        [Display(Name = "The name of the class:")]
        public string ClassName { get; set; }

        [Required]
        public int ClassCode { get; set; }

        public List<MemberAssignment> ClassAssignments { get; set; }


    }
}
