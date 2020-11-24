using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ADSBackend.Models
{
    public class EventInfo
    {
        [Key]

        public int EventId { get; set; }
        //[Required]
        //[DataType(DataType.Password)]
        //[Display(Name = "Event")]

        public string Name { get; set; }

    }
}
