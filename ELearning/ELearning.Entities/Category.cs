using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ELearning.Entities
{
    public class Category : BaseEntity<int>
    {
        public Category()
        {
            this.StudentProfiles = new HashSet<StudentProfile>();
        }

        [Required]
        [Column(TypeName = "varchar(100)")]
        public string Name { get; set; }
        public virtual ICollection<StudentProfile> StudentProfiles { get; set; }

    }
}
