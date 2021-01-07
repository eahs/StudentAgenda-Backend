using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ADSBackend.Models
{
    public class AddPersonalEvent
    {
        public int Id { get; set; }

        [Display(Name = "Event:")]
        public string PNameOfEvent { get; set; }


        [DataType(DataType.Date)]

        [Display(Name = "When is this event?")]
        public DateTime dateOfEvent { get; set; }


        //this needs to be not required
        [DataType(DataType.Time)]

        [Display(Name = "Is there a start time needed for this event? (Optional)")]
        public DateTime PDateOfEvent { get; set; }

        //this needs to be not required
        [Display(Name = "Descripiton (Optional)")]
        public string Pdescription {get; set;}
    }
}
