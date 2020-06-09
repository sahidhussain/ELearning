using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ELearning.Dto.V1.Request
{
    public class AssignRoleRequest
    {
        public string UserId { get; set; }
        public string RoleName { get; set; }

    }
}
