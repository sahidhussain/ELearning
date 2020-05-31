using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ELearning.Entities
{
    public class Parents
    {
       
        [Key]
        [Column(TypeName = "varchar(100)")]
        public string ParentID { get; set; }

        [ForeignKey("Title")]
        public int TitleID { get; set; }
        public Titles Title { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string FirstName { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string MiddleName { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string LastName { get; set; }

        [Column(TypeName = "varchar(15)")]
        public string Mobile { get; set; }
      
        [Column(TypeName = "varchar(100)")]
        public string Email { get; set; }
       
        [Column(TypeName = "varchar(100)")]
        public string Occupation { get; set; }
        
        [ForeignKey("Relationship")]
        public int RelationshipID { get; set; }
        public Relationship Relationship { get; set; }
    }
}
