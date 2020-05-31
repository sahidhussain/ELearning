using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ELearning.Entities
{
    public class InstructorProfile
    {
        [Key]
        [ForeignKey("LoginDetail")]
        public string InstructorID { get; set; }
        public LoginDetails LoginDetail { get; set; }
        public DateTime BirthDate { get; set; }

        [ForeignKey("ID")]
        public int GenderID { get; set; }
        public Gender Gender { get; set; }

        [ForeignKey("ID")]
        public int MaritalStatusID { get; set; }
        public MaritalStatus MaritalStatus { get; set; }
    }
}
