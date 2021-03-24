using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADSBackend.Models
{
    public class UserNotes
    {
        public int UserNotesId { get; set; }

        public string noteName { get; set; }

        public string noteContent { get; set; }
    }
}
