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

        public int AssignmentId { get; set; }

        [Display(Name = "Class")]
        public string Class { get; set; }

        [Display(Name = "Event")]
        public string Event { get; set; }

        [Display(Name = "Difficulty")]
        public string Difficulty { get; set; }

        [Display(Name = "Materials Needed")]
        public string Materials { get; set; }

        [Display(Name = "Discription")]
        public string Description { get; set; }


        [Display(Name = "Estimated Amount of Time Needed (hours)")]
        public double TimeNeeded { get; set; }


        [DataType(DataType.Date)]

        [Display(Name = "Due Date")]

        public DateTime DateOfEvent { get; set; }


        [DataType(DataType.Date)]
        [Display(Name = "Is there a specific Date on which you'd like to complete this assignment? (leave blank if not)")]

        public DateTime? DateChoice { get; set; }
        

        [DataType(DataType.Time)]

        [Display(Name = "Is there a specific time on which you'd like to complete this assignment? (leave blank if not)")]

        public DateTime? TimeChoice { get; set; }

    }
}