using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ELearning.Entities
{
    public class AddressType : BaseEntity<int>
    {
        public AddressType()
        {
            this.Addresses = new HashSet<Addresses>();
        }


        [Required]
        [Column(TypeName = "varchar(100)")]
        public string Name { get; set; }

        public virtual ICollection<Addresses> Addresses { get; set; }
    }
}
