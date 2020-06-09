using System;
using System.Collections.Generic;
using System.Text;

namespace ELearning.Dto.V1.Response
{
    public class UsersResponse
    {
        public string ID { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string UserType { get; set; }
        public bool IsAccountActive { get; set; }
    }
}
