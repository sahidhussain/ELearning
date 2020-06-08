using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ELearning.Dto.V1.Request
{
    public class LoginRequest
    {
        [Required(ErrorMessage = "Email cannot be empty.")]
        [EmailAddress(ErrorMessage = "Enter a valid email.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password cannot be empty.")]
        public string Password { get; set; }
    }
}
