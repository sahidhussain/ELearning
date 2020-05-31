using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ELearning.Entities
{
    public class Gender : BaseEntity<int>
    {
        public Gender()
        {
            this.InstructorProfiles = new HashSet<InstructorProfile>();
            this.StudentProfiles = new HashSet<StudentProfile>();
        }

        [Required]
        [Column(TypeName = "varchar(100)")]
        public string Name { get; set; }

        public virtual ICollection<InstructorProfile> InstructorProfiles { get; set; }
        public virtual ICollection<StudentProfile> StudentProfiles { get; set; }

    }
}
