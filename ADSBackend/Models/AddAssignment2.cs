using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

//making a whole new model is easier than trying to delete the other parts from the databse.

namespace ADSBackend.Models
{

    public class AddAssignment2
    {

        public int Id { get; set; }

        [Display(Name = "Class")]
        public string Class2 { get; set; }

        [Display(Name = "Event")]
        public string Event2 { get; set; }

        [Display(Name = "Difficulty")]
        public string Difficulty2 { get; set; }

        [Display(Name = "Materials Needed")]
        public string Materials2 { get; set; }

        [Display(Name = "Discription")]
        public string Description2 { get; set; }


        [Display(Name = "Estimated Amount of Time Needed (hours)")]
        public double timeNeeded2 { get; set; }


        [DataType(DataType.Date)]

        [Display(Name = "Due Date")]

        public DateTime dateOfEvent2 { get; set; }


        [DataType(DataType.Date)]
        [Display(Name = "Is there a specific Date on which you'd like to complete this assignment?")]

        public DateTime? dateChoice { get; set; }
        

        [DataType(DataType.Time)]

        [Display(Name = "Is there a specific time on which you'd like to complete this assignment?")]

        public DateTime? timeChoice { get; set; }

    }
}