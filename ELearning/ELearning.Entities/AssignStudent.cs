using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ELearning.Entities
{
    public class AssignStudent
    {
        [ForeignKey("LoginDetail")]
        public string ParentID { get; set; }
        public LoginDetails LoginDetail { get; set; }

        [ForeignKey("StudentProfile")]
        public string StudentID { get; set; }
        public StudentProfile StudentProfile { get; set; }
    }
}
