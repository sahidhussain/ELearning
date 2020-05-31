using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ELearning.Entities
{
    public class MaritalStatus : BaseEntity<int>
    {
        [Required]
        [Column(TypeName = "varchar(100)")]
        public string Name { get; set; }
    }
}
