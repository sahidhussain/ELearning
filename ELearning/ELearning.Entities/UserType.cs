using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ELearning.Entities
{
    public class UserType : BaseEntity<int>
    {
        public UserType()
        {
            this.ApplicationUser = new HashSet<ApplicationUser>();
        }

        [Required]
        [Column(TypeName = "varchar(100)")]
        public string Name { get; set; }

        public virtual ICollection<ApplicationUser> ApplicationUser { get; set; }

    }
}
