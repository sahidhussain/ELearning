using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ELearning.Entities
{
    public class AssignParent
    {

        [ForeignKey("LoginDetail")]
        public string AssigneeID { get; set; }
        public LoginDetails LoginDetail { get; set; }
        
        [ForeignKey("Parent")]
        public string ParentID { get; set; }
        public Parents Parent { get; set; }
    }
}
