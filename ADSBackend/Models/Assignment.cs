using ADSBackend.Models.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

//making a whole new model is easier than trying to delete the other parts from the databse.

namespace ADSBackend.Models
{

    public class Assignment
    {
        [Key]
        public int AssignmentId { get; set; }

        public int UserId { get; set; }
        public ApplicationUser User { get; set; }

        [Display(Name = "Class")]
        public string Class { get; set; }

        [Display(Name = "Event")]
        public string Event { get; set; }

        [Display(Name = "Difficulty")]
        public string Difficulty { get; set; }

        [Display(Name = "Materials Needed")]
        public string Materials { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }


        [Display(Name = "Estimated Time Needed (hours)")]
        public double TimeNeeded { get; set; }


        [DataType(DataType.Date)]

        [Display(Name = "Due Date")]

        public DateTime DateOfEvent { get; set; }


        [DataType(DataType.Date)]
        [Display(Name = "Specific Date (Optional)")]

        public DateTime? DateChoice { get; set; }
        

        [DataType(DataType.Time)]

        [Display(Name = "Specific Time (Optional)")]

        public DateTime? TimeChoice { get; set; }

    }
}