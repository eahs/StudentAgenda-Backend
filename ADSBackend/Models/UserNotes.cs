using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ADSBackend.Models
{
    public class UserNotes
    {
        public int UserNotesId { get; set; }

        [Display(Name = "Note")]
        public string noteName { get; set; }

        [Display(Name = "Content")]

        public string noteContent { get; set; }
    }
}
