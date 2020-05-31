using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ELearning.Entities
{
    public class DocumentType : BaseEntity<int>
    {
        public DocumentType()
        {
            this.Documents = new HashSet<Documents>();
        }

        [Required]
        [Column(TypeName = "varchar(100)")]
        public string Name { get; set; }

        public virtual ICollection<Documents> Documents { get; set; }

    }
}
