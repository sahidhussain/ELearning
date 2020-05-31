using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ELearning.Entities
{
    public class Relationship : BaseEntity<int>
    {
        public Relationship()
        {
            this.EmergencyContacts = new HashSet<EmergencyContact>();
            this.Parents = new HashSet<Parents>();
        }


        [Column(TypeName = "varchar(100)")]
        [Required]
        public string Name { get; set; }

        public virtual ICollection<EmergencyContact> EmergencyContacts { get; set; }
        public virtual ICollection<Parents> Parents { get; set; }

    }
}
