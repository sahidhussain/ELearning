using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ELearning.Entities
{
    public class Documents : BaseEntity<int>
    {
        [ForeignKey("LoginDetail")]
        public string UserId { get; set; }
        public ApplicationUser LoginDetail { get; set; }

        [Column( TypeName = "varchar(100)")]
        public string Name { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string DocumentUrl { get; set; }
       
        [Column(TypeName = "varchar(10)")]
        public string FileExtension { get; set; }

        [ForeignKey("DocumentType")]
        public int DocumentTypeID { get; set; }
        public DocumentType DocumentType { get; set; }
    }
}
