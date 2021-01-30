using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ADSBackend.Models.MemberViewModels
{
    public class MemberViewModel
    {
        [Key]
        public int MemberId { get; set; }

        [Required]
        [StringLength(32, MinimumLength = 1, ErrorMessage = "First name is required")]  // Max 32 characters, min 1 character
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(32, MinimumLength = 1, ErrorMessage = "Last name is required")]  // Max 32 characters, min 1 character
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required, DataType(DataType.EmailAddress, ErrorMessage = "Enter a valid email address")]
        public string Email { get; set; }

        
        [JsonIgnore]
        
        public string Password { get; set; }

        [JsonIgnore]
        public string PasswordSalt { get; set; }

        public List<MemberAssignment> Assignments { get; set; }

        public MemberViewModel(Member member)
        {
            this.MemberId = member.MemberId;
            this.FirstName = member.FirstName;
            this.LastName = member.LastName;
            this.Email = member.Email;
            this.Password = member.Password;
            this.PasswordSalt = member.PasswordSalt;
            
            
            //this.Assignments = member.Assignments?.Select(ma => ma.MemberId = (MemberId of current user)).ToList();
            
            //m.memberid
        }

    }
}
