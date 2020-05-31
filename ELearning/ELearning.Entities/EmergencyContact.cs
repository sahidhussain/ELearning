using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ELearning.Entities
{
    public class EmergencyContact : BaseEntity<int>
    {
        [ForeignKey("LoginDetail")]
        public string UserId { get; set; }
        public ApplicationUser LoginDetail { get; set; }

        [Required]
        [Column(TypeName = "varchar(100)")]
        public string ContactPerson { get; set; }

        [Required]
        [Column(TypeName = "varchar(15)")]
        public string Mobile1 { get; set; }
        
        [Column(TypeName = "varchar(15)")]
        public string Mobile2 { get; set; }

        [ForeignKey("Relationship")]
        public int RelationshipID { get; set; }
        public Relationship Relationship { get; set; }
    }
}
