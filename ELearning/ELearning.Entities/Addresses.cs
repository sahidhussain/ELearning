using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ELearning.Entities
{
    public class Addresses : BaseEntity<int>
    {
        [ForeignKey("LoginDetail")]
        public string UserId { get; set; }
        public LoginDetails LoginDetail { get; set; }

        [Required]
        [Column(TypeName = "varchar(100)")]
        public string Address { get; set; }

        [Required]
        [Column(TypeName = "varchar(100)")]
        public string City { get; set; } 
        
        [Column(TypeName = "varchar(100)")]
        public string District { get; set; }

        [Required]
        [Column(TypeName = "varchar(100)")]
        public string StateName { get; set; }

        [Required]
        [Column(TypeName = "varchar(100)")]
        public string CountryName { get; set; }

        [Required]
        [Column(TypeName = "varchar(10)")]
        public string Pincode { get; set; }

        [Required]
        [ForeignKey("AddressType")]
        public int AddressTypeID { get; set; }
        public virtual AddressType AddressType { get; set; }
    }
}
