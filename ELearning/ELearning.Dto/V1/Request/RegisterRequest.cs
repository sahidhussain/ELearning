using System;
using System.Collections.Generic;
using System.Text;

namespace ELearning.Dto.V1.Request
{
    public class RegisterRequest
    {
        public int TitleId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int UserTypeId { get; set; }
        public bool IsAccountActive { get; set; }
    }
}
