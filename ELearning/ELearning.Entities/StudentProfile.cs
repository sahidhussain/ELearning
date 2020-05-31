using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ELearning.Entities
{
    public class StudentProfile
    {
        public StudentProfile()
        {
            this.AssignStudents = new HashSet<AssignStudent>();
        }


        [Key]
        [ForeignKey("LoginDetail")]
        public string StudentID { get; set; }
        public ApplicationUser LoginDetail { get; set; }

        [ForeignKey("Gender")]
        public int GenderID { get; set; }
        public Gender Gender { get; set; }

        public DateTime BirthDate { get; set; }

        [ForeignKey("MaritalStatus")]
        public int MaritalStatusID { get; set; }
        public MaritalStatus MaritalStatus { get; set; }

        [ForeignKey("Category")]
        public int CategoryID { get; set; }
        public Category Category { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string CategoryOther { get; set; }

        public bool IsPhysicallyHandicapped { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string Nationality { get; set; }

        public virtual ICollection<AssignStudent> AssignStudents { get; set; }

    }
}
