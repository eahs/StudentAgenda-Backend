using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ADSBackend.Models
{

    public class AddAssignment
    {

        public int Id { get; set; }

        //not sure how to make a choice of classes but to be integrated in future version
        //Need to add field for optional neccesarry time.

        public string Class { get; set; }

        public string Event { get; set; }

        public string Difficulty { get; set; }

        [Display(Name = "Materials Needed")]
        public string Materials { get; set; }

        public string Description { get; set; }


        [Display(Name = "Estimated Amount of Time Needed (hours)")]
        public double timeNeeded { get; set; }


        [DataType(DataType.Date)]

        [Display(Name = "Due Date")]

        public DateTime dateOfEvent { get; set; }
    }
}
