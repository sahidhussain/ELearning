using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ELearning.Entities
{
    public class Relationship : BaseEntity<int>
    {
        [Column(TypeName = "varchar(100)")]
        [Required]
        public string Name { get; set; }
    }
}
