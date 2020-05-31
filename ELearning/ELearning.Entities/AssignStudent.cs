using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ELearning.Entities
{
    public class AssignStudent
    {
        public string ParentID { get; set; }
        public string StudentID { get; set; }
    }
}
