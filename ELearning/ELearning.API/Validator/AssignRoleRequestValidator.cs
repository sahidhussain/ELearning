using ELearning.Dto.V1.Request;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ELearning.API.Validator
{
    public class AssignRoleRequestValidator : AbstractValidator<AssignRoleRequest>
    {
        public AssignRoleRequestValidator()
        {
            RuleFor(x => x.UserId)
                .NotEmpty()
                .WithMessage("UserId cannot be empty.");

            RuleFor(r => r.RoleName)
                .NotEmpty()
                .Matches(expression: "^[a-zA-Z]*$")
                .WithMessage("Role name cannot be empty.");
        }
    }
}
