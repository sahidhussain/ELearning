using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ELearning.Entities
{
    public class Titles : BaseEntity<int>
    {
        public Titles()
        {
            this.ApplicationUser = new HashSet<ApplicationUser>();
            this.Parents = new HashSet<Parents>();
        }

        [Required]
        [Column(TypeName = "varchar(100)")]
        public string Name { get; set; }

        public virtual ICollection<ApplicationUser> ApplicationUser { get; set; }
        public virtual ICollection<Parents> Parents { get; set; }

    }
}
