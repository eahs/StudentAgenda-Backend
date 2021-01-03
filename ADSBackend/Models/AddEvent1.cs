using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

/*this file is no longer used - its use is now in add assignment, please refer to there for further understanding of the intention of
this file*/

namespace ADSBackend.Models
{
    public class AddEvent1
    {

        public int Id { get; set; }

        public string Event { get; set; }

        public string Description { get; set; }

        //not sure what this does yet
        [DataType(DataType.Date)]
        public DateTime dateOfEvent { get; set; }





    }
}
