using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ELearning.Entities
{
    public class ApplicationUser : IdentityUser<string>
    {
        public ApplicationUser()
        {
            this.Addresses = new HashSet<Addresses>();
            this.AssignParents = new HashSet<AssignParent>();
            this.AssignStudents = new HashSet<AssignStudent>();
            this.Documents = new HashSet<Documents>();
            this.EmergencyContacts = new HashSet<EmergencyContact>();
        }


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

        public virtual ICollection<Addresses> Addresses { get; set; }
        public virtual ICollection<AssignParent> AssignParents { get; set; }
        public virtual ICollection<AssignStudent> AssignStudents { get; set; }
        public virtual ICollection<Documents> Documents { get; set; }
        public virtual ICollection<EmergencyContact> EmergencyContacts { get; set; }
        public virtual InstructorProfile InstructorProfile { get; set; }
        public virtual StudentProfile StudentProfile { get; set; }

    }
}
