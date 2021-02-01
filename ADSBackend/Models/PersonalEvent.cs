using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ADSBackend.Models
{
    public class PersonalEvent
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Event:")]
        public string PNameOfEvent { get; set; }


        [DataType(DataType.Date)]

        [Display(Name = "When is this event?")]
        public DateTime DateOfEvent { get; set; }


        //question marks make things not required

        //this needs to be not required
        [DataType(DataType.Time)]

        [Display(Name = "Is there a start time needed for this event? (Optional)")]
        public DateTime PTimeOfEvent { get; set; }

        [Display(Name = "Amount Of Time Needed:")]
        public int PTimeNeeded { get; set; }

        //this needs to be not required
        [Display(Name = "Description (Optional)")]
        public string Pdescription {get; set;}
    }
}
