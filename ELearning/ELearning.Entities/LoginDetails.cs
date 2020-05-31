using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ELearning.Entities
{
    public class LoginDetails : IdentityUser<string>
    {
        [ForeignKey("Title")]
        public int TitleID { get; set; }
        public virtual Titles Title { get; set; }

        [Column(TypeName = "varchar(100)")]
        [Required]
        public string FirstName { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string MiddleName { get; set; }

        [Required]
        [Column(TypeName = "varchar(100)")]
        public string LastName { get; set; }

        [ForeignKey("UserType")]
        public int UserTypeId { get; set; }
        public virtual UserType UserType { get; set; }
        public bool IsAccountActive { get; set; }
        
        public string CreatedBy { get; set; }
        public string Modified { get; set; }
        public DateTime AccountCreationDate { get; set; }
        public DateTime AccountModificationDate { get; set; }
    }
}
